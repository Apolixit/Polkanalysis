using Substrate.NetApi.Model.Meta;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NET.Metadata.V14;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IMetadataService
    {
        public uint NodeVersion { get; }

        public Task<MetadataDto?> GetMetadataAsync(uint specVersion, CancellationToken cancellationToken);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<IEnumerable<MetadataDto>> GetAllMetadataInfoAsync(CancellationToken cancellationToken);

        /// <summary>
        /// Get pallet module from his index
        /// </summary>
        /// <param name="blockHash"></param>
        /// <param name="moduleIndex"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<PalletModule> GetPalletModuleByIndexAsync(Hash blockHash, byte moduleIndex, CancellationToken cancellationToken);
        public Task<PalletModule> GetPalletModuleByIndexAsync(byte moduleIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Get current MetaData pallet module from pallet name
        /// </summary>
        /// <param name="palletName"></param>
        /// <returns></returns>
        public Task<PalletModule> GetPalletModuleByNameAsync(Hash blockHash, string palletName, CancellationToken cancellationToken);
        public Task<PalletModule> GetPalletModuleByNameAsync(string palletName, CancellationToken cancellationToken);
        public PalletModule GetPalletModuleByName(MetaData metadata, string palletName, CancellationToken cancellationToken);

        /// <summary>
        /// Get current MetaData node type from type id
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public NodeType GetPalletType(uint typeId);

        public TypeFieldDto BuildTypeField(NodeTypeField node);

        /// <summary>
        /// Build a "to Rust struct" implementation of given type
        /// </summary>
        /// <param name="typeId"></param>
        /// <returns></returns>
        public string WriteType(uint typeId);

        /// <summary>
        /// Write node variant type
        /// A variant type is a struct which can change data depend of context
        /// For example in Rust : Option enum which can be Option<None> or Option<Some<T>>
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeVariant(NodeTypeVariant nodeType);


        public string WriteNodeCompact(NodeTypeCompact nodeType);

        /// <summary>
        /// The easiest value. Primitive is like U32, I64, Boolean etc
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodePrimitive(NodeTypePrimitive nodeType);


        public string WriteNodeComposite(NodeTypeComposite nodeType);

        /// <summary>
        /// A list of element
        /// In Rust it's Vec<T>
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeSequence(NodeTypeSequence nodeType);

        /// <summary>
        /// A tuple value (A, B)
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeTuple(NodeTypeTuple nodeType);

        /// <summary>
        /// The array type
        /// </summary>
        /// <param name="nodeType"></param>
        /// <returns></returns>
        public string WriteNodeArray(NodeTypeArray nodeType);
    }
}
