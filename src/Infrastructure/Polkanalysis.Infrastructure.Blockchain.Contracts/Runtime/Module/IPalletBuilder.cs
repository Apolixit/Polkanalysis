using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Runtime.Module
{
    public interface IPalletBuilder
    {
        /// <summary>
        /// Build a dynamic call in the pallet
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        IType? BuildCall(Hash blockHash, string palletName, Method method);
        IType? BuildCall(MetaData metadata, string palletName, Method method);

        /// <summary>
        /// Build a dynamic event in the pallet
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        IType? BuildEvent(Hash blockHash, string palletName, Method method);
        IType? BuildEvent(MetaData metadata, string palletName, Method method);

        /// <summary>
        /// Build a dynamic error to the given method in the pallet
        /// </summary>
        /// <param name="palletName"></param>
        /// <param name="method"></param>
        /// <returns></returns>
        IType? BuildError(Hash blockHash, string palletName, Method method);
        IType? BuildError(MetaData metadata, string palletName, Method method);

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
        public NodeType? FindNodeType(Type type, Hash? blockHash = null);

        /// <summary>
        /// Try to find the associated NodeType in current Metadata for the given Ajuna IType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public NodeType? FindNodeType(IType type, Hash? blockHash = null);
        public NodeType? FindNodeType(IType type, MetaData metadata);

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
        public string? FindDocumentation(Type type, Hash? blockHash = null);
        public string? FindDocumentation(Type type, MetaData metadata);

        /// <summary>
        /// Try to find the documentation in current Metadata for the given Ajuna IType
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public string? FindDocumentation(IType type, Hash? blockHash = null);
        public string? FindDocumentation(IType type, MetaData metadata);

        /// <summary>
        /// Try to find the documentation in current Metadata for the given enum
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public string? FindDocumentation(Enum type, Hash? blockHash = null);
        public string? FindDocumentation(Enum type, MetaData metadata);

        TypeProperty[]? FindProperty(Enum type, Hash? blockHash = null);
        TypeProperty[]? FindProperty(Enum type, MetaData metadata);
    }
}
