using Substrate.NetApi.Model.Meta;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NET.Metadata.V14;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;

namespace Polkanalysis.Domain.Contracts.Service
{
    public interface IMetadataService
    {
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
        public Task<PalletModule> GetPalletModuleByIndexAsync(byte moduleIndex, CancellationToken cancellationToken);

        /// <summary>
        /// Get current MetaData pallet module from pallet name
        /// </summary>
        /// <param name="palletName"></param>
        /// <returns></returns>
        public Task<PalletModule> GetPalletModuleByNameAsync(string palletName, CancellationToken cancellationToken);

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

        /// <summary>
        /// Set the metadata instance to work on
        /// </summary>
        /// <param name="metaData"></param>
        void SetMetadata(MetaData metaData);

        public Task<ModuleDetailDto> GetModuleDetailAsync(string palletName, CancellationToken cancellationToken);
        #region Details
        public Task<List<ModuleCallsDto>> GetModuleCallsAsync(string palletName, CancellationToken cancellationToken);

        public Task<List<ModuleEventsDto>> GetModuleEventsAsync(string palletName, CancellationToken cancellationToken);

        public Task<List<ModuleConstantsDto>> GetModuleConstantsAsync(string palletName, CancellationToken cancellationToken);

        public Task<List<ModuleStorageDto>> GetModuleStorageAsync(string palletName, CancellationToken cancellationToken);

        public Task<List<ModuleErrorsDto>> GetModuleErrorsAsync(string palletName, CancellationToken cancellationToken);
        #endregion

        /// <summary>
        /// Number of call to this module between two date
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> GetNbCallAsync(string moduleName, DateTime from, DateTime to, CancellationToken cancellationToken);

        public Task<IEnumerable<SpecVersionDto>> GetRuntimeVersionsAsync(CancellationToken cancellationToken);
    }
}
