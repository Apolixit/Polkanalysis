using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;

namespace Polkanalysis.Domain.Repository
{
    public class ParachainRepository : IParachainRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IExplorerRepository _explorerRepository;

        public ParachainRepository(
            ISubstrateRepository substrateNodeRepository,
            IAccountRepository accountRepository,
            IExplorerRepository explorerRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
            _accountRepository = accountRepository;
            _explorerRepository = explorerRepository;
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

            //Storage.Slots.LeasesAsync()
            foreach (var parachainId in parachainsId.Value)
            {
                var registerStatus = await _substrateNodeRepository.Storage.Paras.ParaLifecyclesAsync(parachainId, cancellationToken);

                var parachainDto = new ParachainLightDto()
                {
                    ParachainId = parachainId.Value.Value,
                    RegisterStatus = DisplayParachainRegisterStatus(registerStatus)
                };

                parachainsDto.Add(parachainDto);
            }

            return parachainsDto;
        }
        public async Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken)
        {
            //if(_substrateNodeRepository.Api.Storage.ParasStorage == null)

            var paraId = new Contracts.Core.Id(new U32(parachainId));
            var accountRegistar = await _substrateNodeRepository.Storage.Registrar.ParasAsync(paraId, cancellationToken);

            var owner = await _accountRepository.GetAccountIdentityAsync(accountRegistar.Manager, cancellationToken);
            //var fundAccount = accountRegistar.
            var registerStatus = await _substrateNodeRepository.Storage.Paras.ParaLifecyclesAsync(paraId, cancellationToken);

            var parachainDto = new ParachainDto();
            parachainDto.OwnerAccount = owner;
            parachainDto.RegisterStatus = DisplayParachainRegisterStatus(registerStatus);




            //var accountRegistar = await _substrateNodeRepository.Client.RegistrarStorage.PendingSwap(paraId, cancellationToken);

            return parachainDto;
        }

        public Task<IEnumerable<AuctionLightDto>> GetAuctionsAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<AuctionDto> GetAuctionDetailAsync(uint auctionId, CancellationToken cancellationToken)
        {
            //var ajunaParaId = new Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            //var ajunaIdU32 = new U32();
            //ajunaIdU32.Create(2051);

            //    ajunaParaId.Value = ajunaIdU32;

            //    var baseTuplePara = new BaseTuple<AccountId32, Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>();
            //baseTuplePara.Create(accountId32, ajunaParaId);

            //    var apoBidAjunaAction = await _substrateNodeRepository.Client.AuctionsStorage.ReservedAmounts(baseTuplePara, cancellationToken);
            //var xx = await _substrateNodeRepository.Client.AuctionsStorage.AuctionInfo(cancellationToken);
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CrowdloanLightDto>> GetCrowdloansAsync(CancellationToken cancellationToken)
        {
            var crowdloans = await _substrateNodeRepository.Storage.Crowdloan.FundsQuery().ExecuteAsync(cancellationToken);

            var crowdloansDto = new List<CrowdloanLightDto>();
            if (crowdloans == null) return crowdloansDto;

            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            foreach (var crowdloan in crowdloans)
            {
                var fundTarget = crowdloan.Item2.Cap.Value.ToDouble(chainInfo.TokenDecimals);
                var fundRaised = crowdloan.Item2.Raised.Value.ToDouble(chainInfo.TokenDecimals);
                var blockStart = await _explorerRepository.GetBlockLightAsync(crowdloan.Item2.FirstPeriod.Value, cancellationToken);
                var blockEnd = await _explorerRepository.GetBlockLightAsync(crowdloan.Item2.LastPeriod.Value, cancellationToken);

                crowdloansDto.Add(new CrowdloanLightDto()
                {
                    CrowdloanId = crowdloan.Item1.Value.Value,
                    FundRaised = fundRaised,
                    FundTarget = fundTarget,
                    Lease = new LeaseDto()
                    {
                        BlockStart = blockStart,
                        BlockEnd = blockEnd,
                    },
                });
            }

            return crowdloansDto;
        }

        public async Task<CrowdloanDto> GetCrowdloanDetailAsync(uint crowdloanId, CancellationToken cancellationToken)
        {
            //var ids = _modelBuilder.CreateTuppleIndex(crowdloanId);
            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            var crowdloanDetail = await _substrateNodeRepository.Storage.Crowdloan.FundsAsync(new Contracts.Core.Id(crowdloanId), cancellationToken);

            BlockLightDto? lastBlockContribution = crowdloanDetail.LastContribution.Value switch
            {
                LastContribution.Never => null,
                LastContribution.PreEnding => await _explorerRepository.GetBlockLightAsync(((U32)crowdloanDetail.LastContribution.Value2).Value, cancellationToken),
                LastContribution.Ending => await _explorerRepository.GetBlockLightAsync(((U32)crowdloanDetail.LastContribution.Value2).Value, cancellationToken),
                _ => throw new InvalidOperationException("Unknown crowdloan LastContribution")
            };

            var depositorAccount = await _accountRepository.GetAccountIdentityAsync(crowdloanDetail.Depositor, cancellationToken);
            var fundTarget = crowdloanDetail.Cap.Value.ToDouble(chainInfo.TokenDecimals);
            var fundRaised = crowdloanDetail.Raised.Value.ToDouble(chainInfo.TokenDecimals);

            var blockStart = await _explorerRepository.GetBlockLightAsync(crowdloanDetail.FirstPeriod.Value, cancellationToken);
            var blockEnd = await _explorerRepository.GetBlockLightAsync(crowdloanDetail.LastPeriod.Value, cancellationToken);

            var crowdloanDto = new CrowdloanDto()
            {
                CrowdloanId = crowdloanId,
                LastBlockContribution = lastBlockContribution,
                Depositor = depositorAccount,
                FundTarget = fundTarget,
                FundRaised = fundRaised,
                Lease = new LeaseDto()
                {
                    BlockStart = blockStart,
                    BlockEnd = blockEnd,
                },
                FundIndex = crowdloanDetail.FundIndex.Value,
                Verifier = crowdloanDetail.Verifier.AsNullable(),
            };

            return crowdloanDto;
        }
    }
}
