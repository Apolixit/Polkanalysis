using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Runtime.Module
{
    public interface IPalletBuilder
    {
        /// <summary>
        /// Build a dynamic call in the pallet
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        IType BuildCall(string palletName, Method method);

        /// <summary>
        /// Build a dynamic event in the pallet
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        IType BuildEvent(string palletName, Method method);

        /// <summary>
        /// Build a dynamic error to the given method in the pallet
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        IType BuildError(string palletName, Method method);

        /// <summary>
        /// Generate dynamic namespace base
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string GenerateDynamicNamespaceBase(IEnumerable<string> nodeTypePath);

        /// <summary>
        /// Try to find the associated NodeType in current Metadata for the given generic type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public NodeType? FindNodeType(Type type);

        /// <summary>
        /// Try to find the associated NodeType in current Metadata for the given Ajuna IType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public NodeType? FindNodeType(IType type);

        /// <summary>
        /// Return documentation associated to node type
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string? FindDocumentation(NodeType nodeType);

        /// <summary>
        /// Try to find the documentation in current Metadata for the given generic type
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string? FindDocumentation(Type type);

        /// <summary>
        /// Try to find the documentation in current Metadata for the given Ajuna IType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string? FindDocumentation(IType type);

        /// <summary>
        /// Try to find the documentation in current Metadata for the given enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public string? FindDocumentation(Enum type);
    }
}
