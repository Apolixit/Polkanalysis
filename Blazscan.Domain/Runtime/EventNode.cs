using Ajuna.NetApi.Model.Types;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Contracts.Runtime.Mapping;

namespace Blazscan.Domain.Runtime
{
    public class EventNode : INode
    {
        public string ComponentName { get; set; } = string.Empty;
        public bool IsIdentified { get; set; }
        public Type? DataType { get; set; } = null;
        public IType? Data { get; set; } = null;
        public string Name { get; set; } = string.Empty;

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
        public LinkedList<INode> Children { get; set; } = new LinkedList<INode>();

        #region Tree props
        public static EventNode Empty => Create();

        bool INode.IsEmpty => Data == null;

        bool INode.IsLeaf => Children == null || Children.Count == 0;

        public string Documentation { get; set; }
        #endregion

        protected EventNode() { }

        public static EventNode Create()
        {
            return new EventNode();
        }

        public INode AddData(IType data)
        {
            Data = data;
            DataType = data.GetType();
            return this;
        }

        public INode AddName(string name)
        {
            Name = name;
            return this;
        }

        public INode AddHumanData(dynamic humanData)
        {
            HumanData = humanData;
            return this;
        }

        public INode AddContext(IMappingElement mapping)
        {
            ComponentName = $"Component_{mapping.ObjectType.Name}";
            IsIdentified = mapping.IsIdentified;

            return this;
        }

        public void AddChild(INode eventNode)
        {
            Children.AddLast(eventNode);
        }

        public INode AddDocumentation(string doc)
        {
            Documentation = doc;
            return this;
        }

        public string ToJson()
        {
            throw new NotImplementedException();
        }
    }
}
