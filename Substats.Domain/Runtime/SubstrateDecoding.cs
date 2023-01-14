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

namespace Substats.Domain.Runtime
{
    public class SubstrateDecoding : ISubstrateDecoding
    {
        private readonly IMapping _mapping;
        private readonly ISubstrateNodeRepository _substrateRepository;
        private readonly IPalletBuilder _palletBuilder;
        private readonly ILogger<SubstrateDecoding> _logger;

        public SubstrateDecoding(
            IMapping mapping, 
            ISubstrateNodeRepository substrateRepository, 
            IPalletBuilder palletBuilder,
            ILogger<SubstrateDecoding> logger)
        {
            _mapping = mapping;
            _substrateRepository = substrateRepository;
            _palletBuilder = palletBuilder;
            _logger = logger;
        }

        /// <summary>
        /// Parse the hexadecimal event to a "friendly" tree structure
        /// </summary>
        /// <param name="hex">Event hexa</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Event hexa is empty</exception>
        /// <exception cref="NullReferenceException"></exception>
        public INode DecodeEvent(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)}");

            var eventReceived = new EventRecord();
            try
            {
                eventReceived.Create(Utils.HexToByteArray(hex));
            } catch(Exception ex)
            {
                throw new InvalidOperationException($"{nameof(eventReceived)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
            }

            _logger.LogInformation($"Event hex ({hex}) has been successfully converted to EventRecord");

            var eventNode = new EventNode();
            VisitNode(eventNode, eventReceived);

            _logger.LogTrace("Node created from EventRecord");
            return eventNode;
        }

        public INode DecodeEvent(IType ev)
        {
            EventNode node = new EventNode();
            VisitNode(node, ev);

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

        public INode DecodeBlock(Block block)
        {
            throw new NotImplementedException();
        }

        public INode DecodeBlock(BlockData blockData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get pallet module from name
        /// </summary>
        /// <param name="palletName"></param>
        /// <returns></returns>
        public PalletModule GetPalletModule(string palletName)
        {
            var module = _substrateRepository.Client.MetaData.NodeMetadata.Modules.FirstOrDefault(p => p.Value.Name.ToLower() == palletName.ToLower()).Value;

            if (module == null)
                throw new ArgumentException($"{nameof(palletName)} (= {palletName}) is not found in Metadata");

            return module;
        }

        /// <summary>
        /// Get pallet module from index
        /// </summary>
        /// <param name="palletIndex"></param>
        /// <returns></returns>
        public PalletModule GetPalletModule(byte palletIndex)
        {
            var module = _substrateRepository.Client.MetaData.NodeMetadata.Modules[palletIndex];
            if (module == null)
                throw new ArgumentException($"{nameof(palletIndex)} (= {palletIndex}) is not found in Metadata");

            return module;
        }

        public NodeType GetDocumentationFromTypeId(uint TypeId)
        {
            var doc = _substrateRepository.Client.MetaData.NodeMetadata.Types[TypeId];
            if (doc == null)
                throw new ArgumentException($"{nameof(TypeId)} (= {TypeId}) is not found in Metadata");

            return doc;
        }

        public INode DecodeExtrinsic(Ajuna.NetApi.Model.Extrinsics.Extrinsic extrinsic)
        {
            //nodeMetadata.Types.Where(x => x.Value.Path != null && x.Value.Path.Count() > 2 && x.Value.Path[0] == "pallet_balances")
            var nodeMetadata = _substrateRepository.Client.MetaData.NodeMetadata;
            var metadataModules = _substrateRepository.Client.MetaData.NodeMetadata.Modules;
            var metadataExtrinsic = _substrateRepository.Client.MetaData.NodeMetadata.Extrinsic;
            //var moduleName = metadataModules.FirstOrDefault(x => x.Value.Index == extrinsic.Method.ModuleIndex);

            var pallet = _substrateRepository.Client.MetaData.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];
            var palletCall = nodeMetadata.Types[pallet.Calls.TypeId];

            var realCallNew = _palletBuilder.BuildCall(pallet.Name, extrinsic.Method);
            var nodeResultNew = DecodeEvent(realCallNew);

            return nodeResultNew;
        }

        private int DecodeNodeType(NodeType nodeType, int callIndex)
        {
            // Si palletCall.Typedef == Variant => Accès aux enum Variants
            //case TypeDefEnum.Composite: new NodeTypeComposite
            //TypeDefEnum.Variant => new NodeTypeVariant
            //TypeDefEnum.Sequence => new NodeTypeSequence
            //TypeDefEnum.Array => new NodeTypeArray
            //TypeDefEnum.Tuple => new NodeTypeTuple
            //TypeDefEnum.Primitive => new NodeTypePrimitive
            //TypeDefEnum.Compact => new NodeTypeCompact
            //TypeDefEnum.BitSequence => new NodeTypeBitSequence

            int i = nodeType.TypeDef switch
            {
                TypeDefEnum.Variant => 1,
                _ => 2,
            };

            if (nodeType is NodeTypeVariant nodeVariant)
            {
                var variant = nodeVariant.Variants[callIndex];

            }

            return i;
        }

        public INode DecodeLog(IList<string> logs)
        {
            throw new NotImplementedException();
        }
    }
}
