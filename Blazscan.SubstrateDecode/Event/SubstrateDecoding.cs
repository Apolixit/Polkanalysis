using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using Ajuna.NetApi.Model.Types.Primitive;
using Blazscan.AjunaExtension;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.NetApiExt.Generated.Model.frame_system;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;

namespace Blazscan.SubstrateDecode
{
    public class SubstrateDecoding : ISubstrateDecoding
    {
        private readonly IMapping _mapping;
        private readonly ISubstrateNodeRepository _substrateRepository;

        public SubstrateDecoding(IMapping mapping, ISubstrateNodeRepository substrateRepository)
        {
            _mapping = mapping;
            _substrateRepository = substrateRepository;
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
                throw new ArgumentNullException($"{nameof(hex)} is not set");

            var eventReceived = new EventRecord();
            eventReceived.Create(Utils.HexToByteArray(hex));

            if (eventReceived == null)
                throw new ArgumentNullException($"{nameof(eventReceived)} has not been instanciate properly, maybe due to invalid hex parameter");

            var eventCore = eventReceived.Event;
            var eventPhase = eventReceived.Phase;
            var eventTopic = eventReceived.Topics;

            var eventNode = EventNode.Empty;
            VisitNode(eventNode, eventCore);

            //EventNode eventPhaseNode = EventNode.Empty;
            //VisitNode(eventPhaseNode, eventPhase);

            //EventNode eventTopicNode = EventNode.Empty;
            //VisitNode(eventTopicNode, eventTopic);

            return eventNode;
        }

        public INode DecodeEvent(IType ev)
        {
            EventNode node = EventNode.Empty;
            VisitNode(node, ev);

            return node;
        }

        private void VisitNode(INode node, IType? value)
        {
            if (!(value is BaseEnumType))
            {
                VisitNodePrimitive(node, value);
            }
            else
            {
                var val = value.GetValue();
                var childNode = EventNode.Create().AddData(value).AddHumanData(val);
                if (node.IsEmpty)
                {
                    node.AddData(value).AddHumanData(val);
                    VisitNode(node, ((BaseEnumType)value).GetValue2());
                }
                else
                {
                    VisitNode(childNode, ((BaseEnumType)value).GetValue2());
                    node.AddChild(childNode);
                }

                
            }
        }

        private void VisitNodePrimitive(INode node, IType? value)
        {
            var mapper = _mapping.Search(value.GetType());
            if (!mapper.IsIdentified && value.GetType().IsGenericType)
            {
                    VisitNodeGeneric(node, value);
            } else if(!mapper.IsIdentified && HasComplexeField(value))
            {
                var properties = value.GetType().GetProperties();
                foreach(var property in properties)
                {
                    var prp = value.GetValue(property.Name);
                    if(prp is IType prpType)
                    {
                        var childNode = EventNode.Create()
                                                .AddData(prpType)
                                                .AddName(property.Name);
                        node.AddChild(childNode);

                        VisitNode(childNode, prpType);
                    }
                }
            }
            else
            {
                if(node.IsEmpty)
                    node.AddContext(mapper)
                        .AddHumanData(mapper.ToHuman(value));
                else
                    node.AddChild(EventNode.Create()
                                        .AddData(value)
                                        .AddContext(mapper)
                                        .AddHumanData(mapper.ToHuman(value)));
            }
        }

        private bool HasComplexeField(IType? value)
        {
            var customAttributes = value.GetType().CustomAttributes;
            if(customAttributes != null && customAttributes.Count() > 0)
            {
                var hasCompositeAttribute = customAttributes.Any(attr => attr.AttributeType.Name == "AjunaNodeTypeAttribute" && attr.ConstructorArguments.Any(constr => (int)constr.Value == (int)Ajuna.NetApi.Model.Types.Metadata.V14.TypeDefEnum.Composite));
                return hasCompositeAttribute;
            }

            return false;
        }

        private void VisitNodeGeneric(INode node, IType? value)
        {
            var genericArgs = value.GetType().GenericTypeArguments;
            for (int i = 0; i < genericArgs.Length; i++)
            {
                
                IType? currentValue = null;
                if (value.GetValue().GetType().IsArray)
                    currentValue = (IType)value.GetValueArray()[i];
                else
                    currentValue = (IType)value.GetValue();

                if (genericArgs[i].IsGenericType)
                {
                    var childNode = EventNode.Create().AddData(currentValue);
                    node.AddChild(childNode);

                    VisitNode(childNode, currentValue);
                } else
                {
                    VisitNode(node, currentValue);
                }
            }
        }

        public INode DecodeBlock(Block block)
        {
            throw new NotImplementedException();
        }

        public INode DecodeBlock(BlockData blockData)
        {
            throw new NotImplementedException();
        }

        public INode DecodeExtrinsic(Ajuna.NetApi.Model.Extrinsics.Extrinsic extrinsic)
        {
            var nodeMetadata = _substrateRepository.Client.MetaData.NodeMetadata;
            var metadataModules = _substrateRepository.Client.MetaData.NodeMetadata.Modules;
            var metadataExtrinsic = _substrateRepository.Client.MetaData.NodeMetadata.Extrinsic;
            //var moduleName = metadataModules.FirstOrDefault(x => x.Value.Index == extrinsic.Method.ModuleIndex);

            var pallet = _substrateRepository.Client.MetaData.NodeMetadata.Modules[extrinsic.Method.ModuleIndex];
            var palletCall = nodeMetadata.Types[pallet.Calls.TypeId];
            
            var _eventDecode = new SubstrateDecoding(new EventMapping(), _substrateRepository);

            var realCallNew = BuildCall(pallet.Name, extrinsic.Method);
            var nodeResultNew = _eventDecode.DecodeEvent(realCallNew);

            return nodeResultNew;
        }

        public byte[] Encode<T>(T enumPallet, byte[] param) where T : Enum
        {
            var result = new List<byte>();
            var r = new byte[] { Convert.ToByte(enumPallet) };
            result.AddRange(r);
            result.AddRange(param);
            return result.ToArray();
        }

        // TODO: refacto and build dynamically
        private IType
            BuildCall(string palletName, Method extrinsicMethod)
        {
            IType? call = null;
            Enum? enumValue = null;
            switch (palletName)
            {
                case "Balances":
                    call = new Blazscan.NetApiExt.Generated.Model.pallet_balances.pallet.EnumCall();
                    enumValue = (NetApiExt.Generated.Model.pallet_balances.pallet.Call)Enum.ToObject(typeof(NetApiExt.Generated.Model.pallet_balances.pallet.Call), extrinsicMethod.CallIndex);
                    call.Create(Encode(enumValue, extrinsicMethod.Parameters));

                    return call;

                case "Timestamp":
                    call = new Blazscan.NetApiExt.Generated.Model.pallet_timestamp.pallet.EnumCall();
                    enumValue = (NetApiExt.Generated.Model.pallet_timestamp.pallet.Call)Enum.ToObject(typeof(NetApiExt.Generated.Model.pallet_balances.pallet.Call), extrinsicMethod.CallIndex);
                    call.Create(Encode(enumValue, extrinsicMethod.Parameters));

                    return call;

                case "System":
                    call = new Blazscan.NetApiExt.Generated.Model.frame_system.pallet.EnumCall();
                    enumValue = (NetApiExt.Generated.Model.frame_system.pallet.Call)Enum.ToObject(typeof(NetApiExt.Generated.Model.pallet_balances.pallet.Call), extrinsicMethod.CallIndex);
                    call.Create(Encode(enumValue, extrinsicMethod.Parameters));

                    return call;

                case "Utility":
                    call = new Blazscan.NetApiExt.Generated.Model.pallet_utility.pallet.EnumCall();
                    enumValue = (NetApiExt.Generated.Model.pallet_utility.pallet.Call)Enum.ToObject(typeof(NetApiExt.Generated.Model.pallet_balances.pallet.Call), extrinsicMethod.CallIndex);
                    call.Create(Encode(enumValue, extrinsicMethod.Parameters));

                    return call;

                case "ParaInherent":
                    call = new Blazscan.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras_inherent.pallet.EnumCall();
                    enumValue = (NetApiExt.Generated.Model.polkadot_runtime_parachains.paras_inherent.pallet.Call)Enum.ToObject(typeof(NetApiExt.Generated.Model.pallet_balances.pallet.Call), extrinsicMethod.CallIndex);
                    call.Create(Encode(enumValue, extrinsicMethod.Parameters));

                    return call;

            }
            
            throw new ArgumentException($"{nameof(palletName)} = {palletName} does not exists");
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

            if(nodeType is NodeTypeVariant nodeVariant)
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
