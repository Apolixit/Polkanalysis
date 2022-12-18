using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Abstract
{
    /// <summary>
    /// Build a tree from Substrate extrinsic, event or log
    /// </summary>
    public interface INode
    {
        /// <summary>
        /// Is this current has been mapped ?
        /// </summary>
        bool IsIdentified { get; set; }

        /// <summary>
        /// Type of current element
        /// </summary>
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
        string ComponentName { get; set; }

        /// <summary>
        /// Node sub children
        /// </summary>
        LinkedList<INode> Children { get; set; }

        public bool IsEmpty { get; }
        public bool IsLeaf { get; }

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
        /// Add child to the node
        /// </summary>
        /// <param name="eventNode"></param>
        void AddChild(INode eventNode);
    }
}
