using Substrate.NetApi.Model.Types;
using System.Dynamic;
using System.Reflection.Emit;
using System.Reflection;
using System.Text.Json;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime;

namespace Polkanalysis.Infrastructure.Blockchain.Runtime
{
    public class GenericNode : INode
    {
        public string ComponentName { get; set; } = string.Empty;
        public bool IsIdentified { get; set; }
        public Type? DataType { get; set; } = null;
        public IType? Data { get; set; } = null;
        public string Name { get; set; } = string.Empty;

        private dynamic? _humanData = null;
        public dynamic? HumanData
        {
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
        public IList<INode> Children { get; set; } = new List<INode>();

        public INode this[int index] => Children[index];
        public INode? this[string name] => Find(name)?.FirstOrDefault();

        #region Tree props
        public bool IsEmpty => Data == null;

        public bool IsLeaf => Children == null || Children.Count == 0;

        public string Documentation { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
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
            Children.Add(eventNode);
        }

        public INode AddDocumentation(string doc)
        {
            Documentation = doc;
            return this;
        }

        public string ToJson()
            => JsonSerializer.Serialize(ToDictionnary(), DefaultSerializer());

        private static JsonSerializerOptions DefaultSerializer()
        {
            return new JsonSerializerOptions
            {
                WriteIndented = true
            };
        }

        public Dictionary<string, object> ToDictionnary()
        {
            var output = new Dictionary<string, object>();
            if (this.HumanData is null) return output;

            if (this.DataType is not null)
            {
                output.Add("type", this.DataType.Name);
                output.Add("documentation", this.Documentation);
                output.Add("name", this.Name);
                output.Add("value", this.HumanData!.ToString());
            }

            if (Children.Count > 0)
            {
                if (Children.Count == 1 && Children[0].HumanData is not null)
                {
                    output["value"] = Children[0].HumanData!.ToString();
                }
                else
                {
                    output.Add("", Children.Select(x => x.ToDictionnary()));
                }
            }

            return output;
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

        public string ToJsonCompact()
            => JsonSerializer.Serialize(ToDictionnaryFlatten(), DefaultSerializer());

        public Dictionary<string, object> ToDictionnaryFlatten()
        {
            if (this.HumanData is null) throw new InvalidOperationException("HumanData is null");

            var output = new Dictionary<string, object>();

            if (Children.Count > 0)
            {
                var childDictionary = new Dictionary<string, object>();
                foreach (var child in Children)
                {
                    childDictionary.Add(child.Name, child.HumanData!.ToString());
                }
                output.Add(Name, childDictionary);
            }
            else
            {
                output.Add(Name, HumanData!.ToString());
            }

            return output;
        }

        public INode Create()
        {
            return new GenericNode();
        }

        public bool Has(object data)
        {
            return Find(data)?.Count() > 0;
        }

        private IEnumerable<INode> FindInner(List<INode> list, object obj)
        {
            if (HumanData is not null)
            {
                if (HumanData.Equals(obj) ||
                    obj is string objString &&
                    HumanData.ToString().ToLower().Equals(objString.ToLower()))
                {
                    list.Add(this);
                }
            }

            if (Children is null) return list;

            foreach (var child in Children)
            {
                list.AddRange(child.Find(obj));
            }

            return list;
        }

        private IEnumerable<INode> FindInner(List<INode> list, Type obj)
        {
            if (DataType != null && DataType.FullName.Equals(obj.FullName))
            {
                list.Add(this);
            }

            if (Children == null) return list;

            foreach (var child in Children)
            {
                list.AddRange(child.Find(obj));
            }

            return list;
        }

        private IEnumerable<INode> FindInner(List<INode> list, IType obj)
        {
            if (Data != null && Data.Equals(obj))
            {
                list.Add(this);
            }

            if (Children == null) return list;

            foreach (var child in Children)
            {
                list.AddRange(child.Find(obj));
            }

            return list;
        }

        public IEnumerable<INode> Find(object obj)
        {
            var nodesFounded = new List<INode>();
            return FindInner(nodesFounded, obj);
        }

        public IEnumerable<INode> Find(Type obj)
        {
            var nodesFounded = new List<INode>();
            return FindInner(nodesFounded, obj);
        }

        public IEnumerable<INode> Find(IType obj)
        {
            var nodesFounded = new List<INode>();
            return FindInner(nodesFounded, obj);
        }


    }
}
