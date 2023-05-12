using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;

namespace Polkanalysis.Domain.Repository
{
    public class PolkadotParachainRepository : IParachainRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;
        private readonly IAccountRepository _accountRepository;

        public PolkadotParachainRepository(ISubstrateRepository substrateNodeRepository, IAccountRepository accountRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
            _accountRepository = accountRepository;
        }

        public string DisplayParachainRegisterStatus(EnumParaLifecycle enumPara)
        {
            if(enumPara == null) throw new ArgumentNullException(nameof(enumPara));

            return enumPara.Value switch
            {
                ParaLifecycle.Onboarding => "Onboarding",
                ParaLifecycle.Parachain => "Parachain",
                ParaLifecycle.Parathread => "Parathread",
                ParaLifecycle.UpgradingParathread => "Upgrading Parathread",
                ParaLifecycle.DowngradingParachain => "Downgrading Parachain",
                ParaLifecycle.OffboardingParachain => "Offboarding Parachain",
                ParaLifecycle.OffboardingParathread => "Offboarding Parathread",
                _ => throw new InvalidOperationException("Unknown para lifecycle type")
            };
        }

        public async Task<IEnumerable<ParachainLightDto>> GetParachainsAsync(CancellationToken cancellationToken)
        {
            var parachainsDto = new List<ParachainLightDto>();
            var parachainsId = await _substrateNodeRepository.Storage.Paras.ParachainsAsync(cancellationToken);

            foreach (var parachainId in parachainsId.Value)
            {
                var registerStatus = await _substrateNodeRepository.Storage.Paras.ParaLifecyclesAsync(parachainId, cancellationToken);

                var parachainDto = new ParachainLightDto()
                {
                    ParachainId = parachainId.Value.Value,
                    RegisterStatus = DisplayParachainRegisterStatus(registerStatus)
                };
            }

            return parachainsDto;
        }
        public async Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken)
        {
            //if(_substrateNodeRepository.Api.Storage.ParasStorage == null)

            var paraId = new Contracts.Core.Id(new U32(parachainId));
            var accountRegistar = await _substrateNodeRepository.Storage.Registrar.ParasAsync(paraId, cancellationToken);

            var owner = await _accountRepository.GetAccountIdentityAsync(accountRegistar.Manager, cancellationToken);

            //var parachainDto = new ParachainDto();




            //var accountRegistar = await _substrateNodeRepository.Client.RegistrarStorage.PendingSwap(paraId, cancellationToken);

            return null;
        }
    }
}
