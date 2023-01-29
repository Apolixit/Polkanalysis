using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Runtime.Mapping;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_system;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using Substats.Domain.Contracts.Runtime.Module;
using Serilog;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest;

namespace Substats.Domain.Runtime
{
    public class SubstrateDecoding : ISubstrateDecoding
    {
        private readonly IMapping _mapping;
        private readonly ISubstrateRepository _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;
        private readonly ICurrentMetaData _metaData;
        private readonly ILogger<SubstrateDecoding> _logger;

        public SubstrateDecoding(
            IMapping mapping, 
            ISubstrateRepository substrateRepository, 
            IPalletBuilder palletBuilder,
            ICurrentMetaData metaData,
            ILogger<SubstrateDecoding> logger)
        {
            _mapping = mapping;
            _substrateRepository = substrateRepository;
            _palletBuilder = palletBuilder;
            _metaData = metaData;
            _logger = logger;
        }

        public INode Decode(IType elem)
        {
            EventNode node = new EventNode();
            VisitNode(node, elem);

            return node;
        }

        public INode DecodeEvent(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)}");

            var ev = new EventRecord();
            try
            {
                ev.Create(Utils.HexToByteArray(hex));
            } catch(Exception ex)
            {
                throw new InvalidOperationException($"{nameof(ev)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
            }

            _logger.LogInformation($"Event hex ({hex}) has been successfully converted to EventRecord");
            return DecodeEvent(ev);
        }

        public INode DecodeEvent(EventRecord ev)
        {
            var eventNode = new EventNode();
            VisitNode(eventNode, ev);

            _logger.LogTrace("Node created from EventRecord");
            return eventNode;
        }

        public INode DecodeExtrinsic(string hex)
        {
            if(string.IsNullOrWhiteSpace(hex)) throw new ArgumentNullException($"{nameof(hex)}");

            var extrinsic = new Extrinsic(hex, ChargeTransactionPayment.Default());

            _logger.LogInformation($"Extrinsic {hex} has been converted to a valid extrinsic");
            return DecodeExtrinsic(extrinsic);
        }

        public INode DecodeExtrinsic(Extrinsic extrinsic)
        {
            var pallet = _metaData.GetCurrentMetadata().Modules[extrinsic.Method.ModuleIndex];

            var extrinsicCall = _palletBuilder.BuildCall(pallet.Name, extrinsic.Method);
            return Decode(extrinsicCall);
        }

        public INode DecodeLog(IEnumerable<string> logs)
        {
            if (logs == null)
                throw new ArgumentNullException($"{nameof(logs)}");

            return DecodeLog(logs.Select(log =>
            {
                var buildLogs = new EnumDigestItem();
                buildLogs.Create(log);

                return buildLogs;
            }));
        }

        public INode DecodeLog(IEnumerable<EnumDigestItem> logs)
        {
            if (logs == null)
                throw new ArgumentNullException($"{nameof(logs)}");

            EventNode node = new EventNode();
            foreach (var log in logs)
            {
                node.AddChild(VisitNode(log));
            }

            return node;
        }

        #region Internal visit tree
        private INode VisitNode(IType value)
        {
            EventNode node = new EventNode();
            VisitNode(node, value);
            return node;
        }

        /// <summary>
        /// Visit the current value
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <exception cref="ArgumentNullException"></exception>
        private void VisitNode(INode node, IType value)
        {
            if (value is BaseEnumType baseEnumValue)
            {
                var val = baseEnumValue.GetValue();

                if (val == null) throw new ArgumentNullException($"The value element (enum) from {baseEnumValue.TypeName} is null while visiting node");

                var doc = _palletBuilder.FindDocumentation(val);
                var AddDataToNode = (INode node) =>
                {
                    node
                        .AddData(value)
                        .AddName(val.ToString())
                        .AddHumanData(val);

                    if (doc != null)
                        node.AddDocumentation(doc);

                    return node;
                };

                var childNode = AddDataToNode(new EventNode());

                var enumValue2 = baseEnumValue.GetValue2();
                if (enumValue2 == null)
                    throw new ArgumentNullException($"{baseEnumValue}.GetValue2() is null");

                if (node.IsEmpty)
                {
                    node = AddDataToNode(node);
                    VisitNode(node, enumValue2);
                }
                else
                {
                    VisitNode(childNode, enumValue2);
                    node.AddChild(childNode);
                }
            }
            else
            {
                VisitNodePrimitive(node, value);
            }
        }

        /// <summary>
        /// Visit node which is not an enum
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void VisitNodePrimitive(INode node, IType value)
        {
            if (value is BaseVoid) return;

            var mapper = _mapping.Search(value.GetType());
            if (!mapper.IsIdentified && value.GetType().IsGenericType)
            {
                VisitNodeGeneric(node, value);
            }
            else if (!mapper.IsIdentified && HasComplexeField(value))
            {
                var properties = value.GetType().GetProperties();
                foreach (var property in properties)
                {
                    var prp = value.GetValue(property.Name);
                    if (prp is IType prpType)
                    {
                        var childNode = new EventNode()
                                                .AddData(prpType)
                                                .AddName(property.Name);
                        node.AddChild(childNode);

                        VisitNode(childNode, prpType);
                    }
                }
            }
            else
            {
                var doc = _palletBuilder.FindDocumentation(value.GetType());
                var AddDataToNode = (INode node) =>
                {
                    node
                        .AddData(value)
                        .AddContext(mapper)
                        .AddHumanData(mapper.ToHuman(value));

                    if (doc != null)
                        node.AddDocumentation(doc);

                    return node;
                };

                //node = AddDataToNode(node);
                if (node.IsEmpty)
                    node = AddDataToNode(node);
                else
                    node.AddChild(AddDataToNode(new EventNode()));
            }
        }

        private void VisitNodeGeneric(INode node, IType value)
        {
            //var genericArgs = value.GetValue().GetType().IsArray;
            var valueArray = value.GetValueArray();
            if (valueArray == null)
                throw new ArgumentNullException($"{nameof(valueArray)}GetValueArray() is null");

            foreach (IType currentValue in valueArray)
            {
                if (currentValue.GetType().IsGenericType)
                {
                    var childNode = new EventNode().AddData(currentValue);
                    node.AddChild(childNode);

                    VisitNode(childNode, currentValue);
                }
                else
                {
                    VisitNode(node, currentValue);
                }
            }
        }

        /// <summary>
        /// Check if type contain TypeDefEnum.Composite attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool HasComplexeField(IType value)
        {
            var customAttributes = value.GetType().CustomAttributes;
            if (customAttributes != null && customAttributes.Count() > 0)
            {
                var hasCompositeAttribute =
                    customAttributes.Any(attr => attr.AttributeType.Name == "AjunaNodeTypeAttribute" && attr.ConstructorArguments.Any(
                        constr => constr.Value != null &&
                        (int)constr.Value == (int)Ajuna.NetApi.Model.Types.Metadata.V14.TypeDefEnum.Composite));
                return hasCompositeAttribute;
            }

            return false;
        }
        #endregion
    }
}
