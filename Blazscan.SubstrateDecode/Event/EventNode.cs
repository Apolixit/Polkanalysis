using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.AjunaExtension;
using Blazscan.NetApiExt.Generated.Model.frame_system;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Event
{
    public class EventNode
    {
        protected EventMapping mapping = new EventMapping();

        public string ComponentName { get; set; } = string.Empty;
        public bool IsIdentified { get; set; }
        public Type? DataType { get; set; } = null;
        public IType? Data { get; set; } = null;

        private dynamic? _humanData = null;
        public dynamic? HumanData {
            get
            {
                if (_humanData == null && Children.Count > 0)
                {
                    _humanData = Children.Select(x => x.HumanData).ToList();
                }
                return _humanData;
            }
            set
            {
                _humanData = value;
            }
        }
        public LinkedList<EventNode> Children { get; set; } = new LinkedList<EventNode>();

        #region Tree props
        public static EventNode Empty => Create();
        public bool IsEmpty => Data == null;
        public bool IsLeaf => Children == null || Children.Count == 0;
        #endregion
        
        protected EventNode() { }

        public static EventNode Create()
        {
            return new EventNode();
        }

        /// <summary>
        /// Add Ajuna type Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public EventNode AddData(IType data)
        {
            Data = data;
            DataType = data.GetType();
            return this;
        }

        /// <summary>
        /// Add parsed data
        /// </summary>
        /// <param name="humanData"></param>
        /// <returns></returns>
        public EventNode AddHumanData(dynamic humanData)
        {
            HumanData = humanData;
            return this;
        }

        /// <summary>
        /// Add context useful for front end
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public EventNode AddContext(IMappingElement mapping)
        {
            ComponentName = $"Component_{mapping.ObjectType.Name}";
            IsIdentified = mapping.IsIdentified;

            return this;
        }

        /// <summary>
        /// Add child to the node
        /// </summary>
        /// <param name="eventNode"></param>
        public void AddChild(EventNode eventNode)
        {
            Children.AddLast(eventNode);
        }

        public EventNode BuildExtrinsic(Ajuna.NetApi.Model.Extrinsics.Extrinsic extrinsic)
        {
            var parameters = extrinsic.Method.Parameters;
            return null;
        }

        public EventNode BuildLogs()
        {
            return null;
        }

        public EventNode BuildEvent(string hex)
        {
            if (string.IsNullOrEmpty(hex))
                throw new ArgumentNullException($"{nameof(hex)} is not set");

            var eventReceived = new EventRecord();
            eventReceived.Create(Utils.HexToByteArray(hex));

            return BuildEvent(eventReceived);
        }

        public EventNode BuildEvent(EventRecord eventReceived)
        {
            if (eventReceived == null)
                throw new ArgumentNullException($"{nameof(eventReceived)} has not been instanciate properly, maybe due to invalid hex parameter");

            var eventCore = eventReceived.Event;
            //var eventPhase = eventReceived.Phase;
            //var eventTopic = eventReceived.Topics;

            EventNode eventNode = EventNode.Empty;
            VisitNode(eventNode, eventCore);

            return eventNode;
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
            }
            else
            {
                node.AddChild(EventNode.Create()
                                    .AddData(value)
                                    .AddContext(mapper)
                                    .AddHumanData(mapper.ToHuman(value)));
            }
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
                }
                else
                {
                    VisitNode(node, currentValue);
                }
            }
        }

    }
}
