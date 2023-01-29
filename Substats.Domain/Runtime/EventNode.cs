using Ajuna.NetApi.Model.Types;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Runtime.Mapping;
using System.Dynamic;
using System.Reflection.Emit;
using System.Reflection;
using System.Text.Json;

namespace Substats.Domain.Runtime
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
        public bool IsEmpty => Data == null;

        public bool IsLeaf => Children == null || Children.Count == 0;

        public string Documentation { get; set; }
        #endregion

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

        public INode AddDocumentation(string[] doc)
        {
            if (doc == null)
                throw new ArgumentNullException($"{nameof(doc)}");

            return AddDocumentation(string.Join("\n", doc));
        }

        public string ToJson()
        {
            var res = JsonSerializer.Serialize(ToDictionnary());
            return res;
        }

        public Dictionary<string, object> ToDictionnary()
        {
            var dictionnary = new Dictionary<string, object>();

            if (Children.Count > 0)
            {
                dictionnary.Add(
                    Name, 
                    Children.Select(x => x.ToDictionnary()));
            }
            else
            {
                dictionnary.Add(Name, HumanData);
            }

            return dictionnary;
        }

        public KeyValuePair<string, object> ToKeyValuePair()
        {
            return new KeyValuePair<string, object>(
                Name,
                Children.Count > 0 
                    ? Children.Select(x => x.ToKeyValuePair()) 
                    : HumanData
            );
        }

        public INode Create()
        {
            return new EventNode();
        }

        public bool Has(object data)
        {
            return Find(data).Count() > 0;
        }

        private IEnumerable<INode> FindInner(List<INode> list, object data)
        {
            if (HumanData != null && HumanData?.Equals(data))
            {
                list.Add(this);
            }

            if (Children == null) return list;

            foreach (var child in Children)
            {
                list.AddRange(child.Find(data));
            }

            return list;
        }

        public IEnumerable<INode> Find(object data)
        {
            var nodesFounded = new List<INode>();
            return FindInner(nodesFounded, data);
        }
    }
}
