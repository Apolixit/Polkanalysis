using Substrate.NetApi.Model.Meta;
using Polkanalysis.Domain.Contracts.Dto.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;

namespace Polkanalysis.Domain.Contracts.Runtime.Module
{
    public interface IModuleInformation
    {
        public ModuleDetailDto GetModuleDetail(string palletName);
        public ModuleDetailDto GetModuleDetail(PalletModule palletModule);

        #region Details
        public List<ModuleCallsDto> GetModuleCalls(string palletName);
        public List<ModuleCallsDto> GetModuleCalls(PalletModule palletModule);

        public List<ModuleEventsDto> GetModuleEvents(string palletName);
        public List<ModuleEventsDto> GetModuleEvents(PalletModule palletModule);

        public List<ModuleConstantsDto> GetModuleConstants(string palletName);
        public List<ModuleConstantsDto> GetModuleConstants(PalletModule palletModule);

        public List<ModuleStorageDto> GetModuleStorage(string palletName);
        public List<ModuleStorageDto> GetModuleStorage(PalletModule palletModule);

        public List<ModuleErrorsDto> GetModuleErrors(string palletName);
        public List<ModuleErrorsDto> GetModuleErrors(PalletModule palletModule);
        #endregion

        /// <summary>
        /// Number of call to this module between two date
        /// </summary>
        /// <param name="moduleId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> GetNbCallAsync(string moduleId, DateTime from, DateTime to, CancellationToken cancellationToken);

        public Task<IEnumerable<SpecVersionDto>> GetRuntimeVersionsAsync(CancellationToken cancellationToken);
    }
}
