using Substrate.NetApi;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NET.Utils;
using Microsoft.Extensions.Logging;
using Ardalis.GuardClauses;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Substrate.NetApi.Model.Meta;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;
using Microsoft.VisualStudio.Threading;

namespace Polkanalysis.Infrastructure.Blockchain.Runtime
{
    public class SubstrateDecoding : ISubstrateDecoding
    {
        private readonly INodeMapping _mapping;
        private readonly ISubstrateService _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;
        private readonly ILogger<SubstrateDecoding> _logger;

        public SubstrateDecoding(
            INodeMapping mapping,
            ISubstrateService substrateRepository,
            IPalletBuilder palletBuilder,
            ILogger<SubstrateDecoding> logger)
        {
            _mapping = mapping;
            _substrateRepository = substrateRepository;
            _palletBuilder = palletBuilder;
            _logger = logger;
        }

        private async Task<MetaData> metadataFromBlocHashAsync(Hash? blockHash, CancellationToken cancellationToken)
        {
            blockHash ??= await _substrateRepository.Rpc.Chain.GetBlockHashAsync();
            Guard.Against.Null(blockHash);

            var metadata = await _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None);
            Guard.Against.Null(metadata);

            return metadata;
        }

        public async Task<INode> DecodeAsync(IType elem, CancellationToken cancellationToken, Hash? blockHash = null)
        {
            GenericNode node = new GenericNode();
            await VisitNodeAsync(
                node, 
                elem, 
                await metadataFromBlocHashAsync(blockHash, cancellationToken), 
                cancellationToken);

            return node;
        }

        public async Task<IEventNode> DecodeEventAsync(string hex, CancellationToken cancellationToken, Hash? blockHash = null)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)}");

            blockHash = blockHash ?? await _substrateRepository.Rpc.Chain.GetBlockHashAsync();

            var ev = new EventRecord();
            try
            {
                ev.Create(Utils.HexToByteArray(hex));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{nameof(ev)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
            }

            return await DecodeEventAsync(ev, cancellationToken, blockHash);
        }

        public async Task<IEventNode> DecodeEventAsync(EventRecord ev, CancellationToken cancellationToken, Hash? blockHash = null)
            => await DecodeEventAsync(
                ev, 
                await metadataFromBlocHashAsync(blockHash, cancellationToken), 
                cancellationToken);

        public async Task<IEventNode> DecodeEventAsync(EventRecord ev, MetaData metadata, CancellationToken cancellationToken)
        {
            var eventNode = new EventNode();

            await VisitNodeAsync(eventNode, ev, metadata, cancellationToken);
            _logger.LogTrace("Node created from EventRecord");
            return eventNode;
        }

        public async Task<INode> DecodeExtrinsicAsync(string hex, Hash blockHash, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException($"{nameof(hex)}");

            var extrinsic = new Extrinsic(hex, ChargeTransactionPayment.Default());

            _logger.LogInformation($"Extrinsic {hex} has been converted to a valid extrinsic");
            return await DecodeExtrinsicAsync(extrinsic, blockHash, cancellationToken).ConfigureAwait(false);
        }

        public async Task<INode> DecodeExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken cancellationToken)
        {
            return await DecodeExtrinsicAsync(extrinsic, await metadataFromBlocHashAsync(blockHash, cancellationToken), cancellationToken);
        }

        public async Task<INode> DecodeExtrinsicAsync(Extrinsic extrinsic, MetaData metadata, CancellationToken cancellationToken)
        {
            var pallet = metadata.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];

            var extrinsicCall = _palletBuilder.BuildCall(metadata, pallet.Name, extrinsic.Method);

#if DEBUG
            if (extrinsicCall is not null)
            {
                var isEqual = Utils.Bytes2HexString(extrinsic.Method.Encode().ToArray()) == Utils.Bytes2HexString(extrinsicCall.Encode());
            }
#endif

            var palletNode = new GenericNode();
            palletNode.Name = pallet.Name;
            palletNode.AddHumanData(pallet.Name);

            if (extrinsicCall is not null)
                palletNode.AddChild(await DecodeAsync(extrinsicCall, cancellationToken));

            return palletNode;
        }


        public async Task<INode> DecodeLogAsync(IEnumerable<string> logs, CancellationToken cancellationToken, Hash? blockHash = null)
        {
            Guard.Against.NullOrEmpty(logs, nameof(logs));

            return await DecodeLogAsync(logs.Select(log =>
            {
                var buildLogs = new EnumDigestItem();
                buildLogs.Create(log);

                return buildLogs;
            }), cancellationToken, blockHash);
        }

        public async Task<INode> DecodeLogAsync(IEnumerable<EnumDigestItem> logs, CancellationToken cancellationToken, Hash? blockHash = null)
        {
            Guard.Against.NullOrEmpty(logs, nameof(logs));

            var metadata = await metadataFromBlocHashAsync(blockHash, cancellationToken);
            GenericNode node = new GenericNode();
            foreach (var log in logs)
            {
                node.AddChild(await VisitNodeAsync(log, metadata, cancellationToken));
            }

            return node;
        }

        #region Internal visit tree
        private async Task<INode> VisitNodeAsync(IType value, MetaData metadata, CancellationToken cancellationToken)
        {
            GenericNode node = new GenericNode();
            await VisitNodeAsync(node, value, metadata, cancellationToken);
            return node;
        }

        /// <summary>
        /// Visit the current value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private async Task<bool> VisitNodeAsync(INode node, IType value, MetaData metadata, CancellationToken cancellationToken)
        {
            if (value is BaseEnumType || IsEnumRust(value))
            {
                var val = value.GetEnumValue();
                Guard.Against.Null(val);

                var doc = _palletBuilder.FindDocumentation(val, metadata);

                var childNode = new GenericNode()
                    .AddData(value)
                    .AddName(val.ToString())
                    .AddHumanData(val);

                if (!string.IsNullOrEmpty(doc))
                    childNode.AddDocumentation(doc);

                var enumValue2 = value.GetValue2();
                if (enumValue2 is null)
                    return false;

                await VisitNodeAsync(childNode, enumValue2, metadata, cancellationToken);

                var props = _palletBuilder.FindProperty(val, metadata);
                if (props is not null && props.Length == childNode.Children.Count)
                {
                    for (int i = 0; i < childNode.Children.Count; i++)
                    {
                        childNode.Children[i].AddName(props[i].Name);
                    }
                }

                node.AddChild(childNode);
            }
            else if (IsBaseEnum(value))
            {
                node.AddHumanData(value.GetEnumValue());
            }
            else
            {
                await VisitNodePrimitiveAsync(node, value, metadata, cancellationToken);
            }

            return true;
        }

        private async Task VisitNodePrimitiveAsync(INode node, IType value, MetaData metaData, CancellationToken cancellationToken)
        {
            if (value is BaseVoid)
                return;

            var mapper = _mapping.Search(value.GetType());
            if (!mapper.IsIdentified && value.GetType().IsGenericType)
            {
                await VisitNodeGenericAsync(node, value, metaData, cancellationToken);
            }
            else if (!mapper.IsIdentified)
            {
                var properties = value.GetType().GetProperties();
                List<Task> propsTaks = new List<Task>();
                foreach (var property in properties)
                {
                    var prp = value.GetValue(property.Name);
                    if (prp is IType prpType)
                    {
                        var childNode = new GenericNode()
                            .AddData(prpType)
                            .AddName(property.Name);
                        node.AddChild(childNode);

                        propsTaks.Add(VisitNodeAsync(childNode, prpType, metaData, cancellationToken));
                    }
                }
                await Task.WhenAll(propsTaks);
            }
            else
            {
                node.AddData(value)
                    .AddContext(mapper)
                    .AddHumanData(mapper.ToHuman(value));
            }
        }

        private async Task VisitNodeGenericAsync(INode node, IType value, MetaData metaData, CancellationToken cancellationToken)
        {
            var data = value.GetValue("Value") ?? value.GetValue("Core");
            if (data is null)
                return;

            var isArray = data.GetType().IsArray;

            if (isArray)
            {
                var valueArray = value.GetValueArray();
                if (valueArray is null)
                    throw new ArgumentException($"{nameof(valueArray)} GetValueArray() is null");

                string name = value.GetType().Name;
                if (value.GetType().Name.StartsWith("BaseVec"))
                    name = "Vec";
                else if (value.GetType().Name.StartsWith("BaseTuple"))
                    name = "Tuple";

                node.AddName($"{name}<{string.Join(", ", valueArray.Select(x => x.GetType().Name))}>")
                    .AddData(value);

                List<Task> tasks = new List<Task>();
                foreach (IType currentValue in valueArray)
                {
                    var childNode = new GenericNode().AddData(currentValue);
                    node.AddChild(childNode);

                    tasks.Add(VisitNodeAsync(childNode, currentValue, metaData, cancellationToken));
                }
                await Task.WhenAll(tasks);
            }
            else
            {
                if (data is IType currentValue)
                {
                    if (currentValue.GetType().IsGenericType)
                    {
                        var childNode = new GenericNode().AddData(currentValue);
                        node.AddChild(childNode);

                        await VisitNodeAsync(childNode, currentValue, metaData, cancellationToken);
                    }
                    else
                    {
                        await VisitNodeAsync(node, currentValue, metaData, cancellationToken);
                    }
                }
            }
        }

        private static bool IsEnumRust(IType value)
        {
            return value.GetType().BaseType?.Name.StartsWith("BaseEnumRust") ?? false;
        }

        private static bool IsBaseEnum(IType value)
        {
            return value.GetType().BaseType?.Name.StartsWith("BaseEnum") ?? false;
        }

        #endregion
    }
}
