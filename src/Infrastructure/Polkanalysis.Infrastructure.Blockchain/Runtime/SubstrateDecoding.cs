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
using Polkanalysis.Domain.Contracts.Service;
using System.Threading;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;

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

        private async Task<MetaData> metadataFromBlocHashAsync(Hash? blockHash = null)
        {
            blockHash = blockHash ?? await _substrateRepository.Rpc.Chain.GetBlockHashAsync();
            Guard.Against.Null(blockHash);

            var metadata = await _substrateRepository.At(blockHash).GetMetadataAsync(CancellationToken.None);
            Guard.Against.Null(metadata);

            return metadata;
        }

        public INode Decode(IType elem, Hash? blockHash = null)
        {
            GenericNode node = new GenericNode();
            VisitNode(node, elem, metadataFromBlocHashAsync(blockHash).Result);

            return node;
        }

        public IEventNode DecodeEvent(string hex, Hash? blockHash = null)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)}");

            blockHash = blockHash ?? _substrateRepository.Rpc.Chain.GetBlockHashAsync().Result;

            var ev = new EventRecord();
            try
            {
                ev.Create(Utils.HexToByteArray(hex));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{nameof(ev)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
            }

            return DecodeEvent(ev, blockHash);
        }

        public IEventNode DecodeEvent(EventRecord ev, Hash? blockHash = null)
            => DecodeEvent(ev, metadataFromBlocHashAsync(blockHash).Result);

        public IEventNode DecodeEvent(EventRecord ev, MetaData metadata)
        {
            var eventNode = new EventNode();

            VisitNode(eventNode, ev, metadata);

            _logger.LogTrace("Node created from EventRecord");
            return eventNode;
        }

        //public async Task<(string callModule, string callEvent)> GetCallFromExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken cancellationToken)
        //{
        //    string callModule = string.Empty;
        //    string callEvent = string.Empty;

        //    var metadata = await _substrateRepository.At(blockHash).GetMetadataAsync(cancellationToken);
        //    var pallet = metadata.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];
        //    callModule = pallet.Name;
        //    var palletType = _metaData.GetPalletType(pallet.Calls.TypeId);

        //    if (palletType is NodeTypeVariant nodeTypeVariant)
        //    {
        //        callEvent = nodeTypeVariant.Variants[extrinsic.Method.CallIndex].Name;
        //        return (callModule, callEvent);
        //    }

        //    throw new InvalidOperationException();
        //}

        public async Task<INode> DecodeExtrinsicAsync(string hex, Hash blockHash, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException($"{nameof(hex)}");

            var extrinsic = new Extrinsic(hex, ChargeTransactionPayment.Default());

            _logger.LogInformation($"Extrinsic {hex} has been converted to a valid extrinsic");
            return await DecodeExtrinsicAsync(extrinsic, blockHash, cancellationToken);
        }

        public async Task<INode> DecodeExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken cancellationToken)
        {
            return DecodeExtrinsic(extrinsic, await metadataFromBlocHashAsync(blockHash));
        }

        public INode DecodeExtrinsic(Extrinsic extrinsic, MetaData metadata)
        {
            var pallet = metadata.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];

            var extrinsicCall = _palletBuilder.BuildCall(metadata, pallet.Name, extrinsic.Method);

#if DEBUG
            if (extrinsicCall is not null)
            {
                var isEqual = Utils.Bytes2HexString(extrinsic.Method.Encode().Skip(1).ToArray()) == Utils.Bytes2HexString(extrinsicCall.Encode());
            }
#endif

            var palletNode = new GenericNode();
            palletNode.Name = pallet.Name;
            palletNode.AddHumanData(pallet.Name);

            if (extrinsicCall is not null)
                palletNode.AddChild(Decode(extrinsicCall));

            return palletNode;
        }


        public INode DecodeLog(IEnumerable<string> logs, Hash? blockHash = null)
        {
            if (logs == null)
                throw new ArgumentNullException($"{nameof(logs)}");

            return DecodeLog(logs.Select(log =>
            {
                var buildLogs = new EnumDigestItem();
                buildLogs.Create(log);

                return buildLogs;
            }), blockHash);
        }

        public INode DecodeLog(IEnumerable<EnumDigestItem> logs, Hash? blockHash = null)
        {
            if (logs == null)
                throw new ArgumentNullException($"{nameof(logs)}");

            var metadata = metadataFromBlocHashAsync(blockHash).Result;
            GenericNode node = new GenericNode();
            foreach (var log in logs)
            {
                node.AddChild(VisitNode(log, metadata));
            }

            return node;
        }

        #region Internal visit tree
        private INode VisitNode(IType value, MetaData metadata)
        {
            GenericNode node = new GenericNode();
            VisitNode(node, value, metadata);
            return node;
        }

        /// <summary>
        /// Visit the current value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void VisitNode(INode node, IType value, MetaData metadata)
        {
            if (value is BaseEnumType || IsEnumRust(value))
            //if (IsEnumRust(value))
            {
                var val = value.GetEnumValue();

                if (val == null) throw new ArgumentNullException($"The value element (enum) from {value.TypeName()} is null while visiting node");

                var doc = _palletBuilder.FindDocumentation(val, metadata);

                var AddDataToNode = (INode node) =>
                {
                    node
                        .AddData(value)
                        .AddName(val.ToString())
                        .AddHumanData(val);

                    if (!string.IsNullOrEmpty(doc))
                        node.AddDocumentation(doc);

                    return node;
                };

                var childNode = AddDataToNode(new GenericNode());

                var enumValue2 = value.GetValue2();
                //if (enumValue2.GetBytes() == null)
                if (enumValue2 is null)
                    return;
                //throw new ArgumentNullException($"{baseEnumValue}.GetValue2() is null");

                if (node.IsEmpty)
                {
                    node = AddDataToNode(node);
                    VisitNode(node, enumValue2, metadata);
                }
                else
                {
                    VisitNode(childNode, enumValue2, metadata);

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
            }
            else if(IsBaseEnum(value))
            {
                node.AddHumanData(value.GetEnumValue());
            }
            else
            {
                VisitNodePrimitive(node, value, metadata);
            }
        }

        /// <summary>
        /// Check if the current value is an enum with associated data
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private static bool IsEnumRust(IType value)
        {
            return value.GetType().BaseType is not null && value.GetType().BaseType!.Name.StartsWith("BaseEnumRust");
        }

        private static bool IsBaseEnum(IType value)
        {
            return value.GetType().BaseType is not null && value.GetType().BaseType!.Name.StartsWith("BaseEnum");
        }

        /// <summary>
        /// Visit node which is not an enum
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void VisitNodePrimitive(INode node, IType value, MetaData metaData)
        {
            if (value is BaseVoid) return;

            var mapper = _mapping.Search(value.GetType());
            if (!mapper.IsIdentified && value.GetType().IsGenericType)
            {
                VisitNodeGeneric(node, value, metaData);
            }
            else if (!mapper.IsIdentified)
            {
                var properties = value.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var prp = value.GetValue(property.Name);
                    if (prp is IType prpType)
                    {
                        var childNode = new GenericNode()
                                                .AddData(prpType)
                                                .AddName(property.Name);
                        node.AddChild(childNode);

                        VisitNode(childNode, prpType, metaData);
                    }
                }
            }
            else
            {
                //var doc = _palletBuilder.FindDocumentation(value.GetType());
                var AddDataToNode = (INode node) =>
                {
                    node
                        .AddData(value)
                        .AddContext(mapper)
                        .AddHumanData(mapper.ToHuman(value));

                    //if (doc != null)
                    //    node.AddDocumentation(doc);

                    return node;
                };

                //node = AddDataToNode(node);
                node = AddDataToNode(node);
                //if (node.IsEmpty)
                //    node = AddDataToNode(node);
                //else
                //    node.AddChild(AddDataToNode(new GenericNode()));
            }
        }

        private void VisitNodeGeneric(INode node, IType value, MetaData metaData)
        {
            // We try to get Value or Core
            var data = value.GetValue("Value") ?? value.GetValue("Core");
            if (data is null) return;

            var isArray = data.GetType().IsArray;

            if (isArray)
            {
                var valueArray = value.GetValueArray();

                if (valueArray == null)
                    throw new ArgumentException($"{nameof(valueArray)} GetValueArray() is null");

                string name = value.GetType().Name;
                if (value.GetType().Name.StartsWith("BaseVec")) name = "Vec";
                else if (value.GetType().Name.StartsWith("BaseTuple")) name = "Tuple";
                node.AddName($"{name}<{string.Join(", ", valueArray.Select(x => x.GetType().Name))}>");
                node.AddData(value);

                foreach (IType currentValue in valueArray)
                {
                    var childNode = new GenericNode().AddData(currentValue);
                    node.AddChild(childNode);

                    VisitNode(childNode, currentValue, metaData);

                    //if (currentValue.GetType().IsGenericType)
                    //{
                    //    var childNode = new GenericNode().AddData(currentValue);
                    //    node.AddChild(childNode);

                    //    VisitNode(childNode, currentValue, blockHash);
                    //}
                    //else
                    //{
                    //    VisitNode(node, currentValue, blockHash);
                    //}
                }
            }
            else
            {
                //var currentValue = (IType?)value.GetValue();
                //var objectValue = value.GetValue();
                if (data is IType currentValue)
                {
                    Guard.Against.Null(currentValue, nameof(currentValue));

                    if (currentValue.GetType().IsGenericType)
                    {
                        var childNode = new GenericNode().AddData(currentValue);
                        node.AddChild(childNode);

                        VisitNode(childNode, currentValue, metaData);
                    }
                    else
                    {
                        VisitNode(node, currentValue, metaData);
                    }
                }
            }

        }

        //public async Task<(string callModule, string callEvent)> GetCallFromExtrinsicAsync(Extrinsic extrinsic, Hash blockHash, CancellationToken token)
        //{
        //    var metadata = await _substrateRepository.At(blockHash).GetMetadataAsync(token);
        //    return (metadata.NodeMetadata.Modules[extrinsic.Method.ModuleIndex], metadata.NodeMetadata.Modules[extrinsic.Method.ModuleIndex]);
        //}
        #endregion
    }
}
