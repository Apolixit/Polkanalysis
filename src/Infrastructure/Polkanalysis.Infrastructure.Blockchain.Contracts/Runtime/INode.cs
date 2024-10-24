using Substrate.NetApi.Model.Types;
using Newtonsoft.Json;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime
{
    /// <summary>
    /// Build a tree from Substrate extrinsic, event or log
    /// </summary>
    public interface INode
    {
        INode this[int index] { get; }
        INode? this[string name] { get; }

        /// <summary>
        /// Is this current has been mapped ?
        /// </summary>
        [JsonIgnore]
        bool IsIdentified { get; set; }

        /// <summary>
        /// Type of current element
        /// </summary>
        [JsonIgnore]
        Type? DataType { get; set; }

        /// <summary>
        /// Unmodified data from Ajuna SDK
        /// </summary>
        IType? Data { get; set; }

        /// <summary>
        /// Current property name
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Current decoded data more C# friendly
        /// </summary>
        public dynamic? HumanData { get; set; }

        /// <summary>
        /// Custom component use with front app to display this current node
        /// </summary>
        [JsonIgnore]
        string ComponentName { get; set; }

        /// <summary>
        /// The Rust documentation of current element
        /// </summary>
        string Documentation { get; set; }

        /// <summary>
        /// Node sub children
        /// </summary>
        IList<INode> Children { get; set; }

        [JsonIgnore]
        public bool IsEmpty { get; }

        [JsonIgnore]
        public bool IsLeaf { get; }

        /// <summary>
        /// Create a new node
        /// </summary>
        /// <returns></returns>
        INode Create();

        /// <summary>
        /// Add Ajuna type Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        INode AddData(IType data);

        /// <summary>
        /// A property name to the node
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        INode AddName(string name);

        /// <summary>
        /// Add parsed data
        /// </summary>
        /// <param name="humanData"></param>
        /// <returns></returns>
        INode AddHumanData(dynamic humanData);

        /// <summary>
        /// Add context useful for front end
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        INode AddContext(IMappingElement mapping);

        /// <summary>
        /// Add documentation to the node
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        INode AddDocumentation(string doc);
        INode AddDocumentation(string[] doc);

        /// <summary>
        /// Add child to the node
        /// </summary>
        /// <param name="eventNode"></param>
        void AddChild(INode eventNode);

        /// <summary>
        /// Check if the current node or his children has this data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        bool Has(dynamic data);

        /// <summary>
        /// Return node and children if given data found
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        IEnumerable<INode> Find(object obj);
        IEnumerable<INode> Find(IType obj);
        IEnumerable<INode> Find(Type obj);

        /// <summary>
        /// Convert current node to json string
        /// </summary>
        /// <returns></returns>
        string ToJson();

        /// <summary>
        /// Convert current node to a compact json string
        /// </summary>
        /// <returns></returns>
        string ToJsonCompact();

        /// <summary>
        /// Convert current node to list of dictionnary
        /// </summary>
        /// <returns></returns>
        Dictionary<string, object> ToDictionnary();
        KeyValuePair<string, object> ToKeyValuePair();
        Dictionary<string, object> ToDictionnaryFlatten();
    }
}
