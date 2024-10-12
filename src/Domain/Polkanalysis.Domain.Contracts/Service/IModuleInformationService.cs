//using Substrate.NetApi.Model.Meta;
//using Polkanalysis.Domain.Contracts.Dto.Module;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;

//namespace Polkanalysis.Domain.Contracts.Service
//{
//    public interface IModuleInformationService
//    {
//        public ModuleDetailDto GetModuleDetail(string palletName, MetaData metadata);
//        public ModuleDetailDto GetModuleDetail(PalletModule palletModule, MetaData metadata);

//        #region Details
//        public List<ModuleCallsDto> GetModuleCalls(string palletName, MetaData metadata);
//        public List<ModuleCallsDto> GetModuleCalls(PalletModule palletModule, MetaData metadata);

//        public List<ModuleEventsDto> GetModuleEvents(string palletName, MetaData metadata);
//        public List<ModuleEventsDto> GetModuleEvents(PalletModule palletModule, MetaData metadata);

//        public List<ModuleConstantsDto> GetModuleConstants(string palletName, MetaData metadata);
//        public List<ModuleConstantsDto> GetModuleConstants(PalletModule palletModule, MetaData metadata);

//        public List<ModuleStorageDto> GetModuleStorage(string palletName, MetaData metadata);
//        public List<ModuleStorageDto> GetModuleStorage(PalletModule palletModule, MetaData metadata);

//        public List<ModuleErrorsDto> GetModuleErrors(string palletName, MetaData metadata);
//        public List<ModuleErrorsDto> GetModuleErrors(PalletModule palletModule, MetaData metadata);
//        #endregion

//        /// <summary>
//        /// Number of call to this module between two date
//        /// </summary>
//        /// <param name="moduleId"></param>
//        /// <param name="from"></param>
//        /// <param name="to"></param>
//        /// <param name="cancellationToken"></param>
//        /// <returns></returns>
//        public Task<int> GetNbCallAsync(string moduleId, DateTime from, DateTime to, CancellationToken cancellationToken);

//        public Task<IEnumerable<SpecVersionDto>> GetRuntimeVersionsAsync(CancellationToken cancellationToken);
//    }
//}
