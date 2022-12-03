using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Event
{
    public class EventNode
    {
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
    }
}
