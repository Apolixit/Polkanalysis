using Ajuna.NetApi;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.AjunaExtension;
using Blazscan.NetApiExt.Generated.Model.frame_system;
using System.Reflection;

namespace Blazscan.SubstrateDecode.Event
{
    public class EventListener : IEventListener
    {
        protected EventMapping mapping;

        public EventListener()
        {
            mapping = new EventMapping();
        }

        public EventListener(MetaData metaData)
        {
            mapping = new EventMapping(metaData);
        }

        /// <summary>
        /// Parse the hexadecimal event to a "friendly" event structure
        /// </summary>
        /// <param name="hex">Event hexa</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Event hexa is empty</exception>
        /// <exception cref="NullReferenceException"></exception>
        public EventNode Read(string hex)
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

            EventNode eventNode = EventNode.Empty;
            VisitNode(eventNode, eventCore);

            EventNode eventPhaseNode = EventNode.Empty;
            VisitNode(eventPhaseNode, eventPhase);

            //EventNode eventTopicNode = EventNode.Empty;
            //VisitNode(eventTopicNode, eventTopic);

            return eventNode;
        }

        public EventNode Read(IType ev)
        {
            EventNode node = EventNode.Empty;
            VisitNode(node, ev);

            return node;
        }

        private void VisitNode(EventNode node, IType? value)
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

        private void VisitNodePrimitive(EventNode node, IType? value)
        {
            var mapper = mapping.Search(value.GetType());
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

        private void VisitNodeGeneric(EventNode node, IType? value)
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
        
    }
}
