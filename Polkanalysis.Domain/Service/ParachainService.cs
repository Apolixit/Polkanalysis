using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Paras.Enums;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Configuration.Contracts.Information;
using Ardalis.GuardClauses;
using Polkanalysis.Domain.Contracts.Dto.Informations;
using Newtonsoft.Json.Linq;
using Polkanalysis.Domain.Helper;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Service
{
    public class ParachainService : IParachainService
    {
        private readonly ISubstrateService _substrateNodeRepository;
        private readonly IAccountService _accountRepository;
        private readonly IExplorerService _explorerRepository;
        private readonly IBlockchainInformations _blockchainStaticInformations;

        public ParachainService(
            ISubstrateService substrateNodeRepository,
            IAccountService accountRepository,
            IExplorerService explorerRepository,
            IBlockchainInformations blockchainStaticInformations)
        {
            _substrateNodeRepository = substrateNodeRepository;
            _accountRepository = accountRepository;
            _explorerRepository = explorerRepository;
            _blockchainStaticInformations = blockchainStaticInformations;
        }

        public string DisplayParachainRegisterStatus(EnumParaLifecycle enumPara)
        {
            if (enumPara == null) throw new ArgumentNullException(nameof(enumPara));

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

        public BlockchainProject? GetBlockchainProject(string relayChain, uint parachainId)
        {
            Guard.Against.NullOrEmpty(relayChain);
            Guard.Against.Null(parachainId);

            var infos = _blockchainStaticInformations.RelayChains.SingleOrDefault(x => x.RelayChainName == relayChain);
            if (infos == null)
                return null;

            var details = infos.BlockainInformations.SingleOrDefault(x => x.ParachainId is not null && x.ParachainId == parachainId);

            return details;
        }

        public async Task<BlockchainDetailsDto?> GetCurrentBlockchainDetailProjectAsync(CancellationToken cancellationToken)
        {
            var (properties, health, fullName, version) = await WaiterHelper.WaitAndReturnAsync(
                _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken),
                _substrateNodeRepository.Rpc.System.HealthAsync(cancellationToken),
                _substrateNodeRepository.Rpc.System.NameAsync(cancellationToken),
                _substrateNodeRepository.Rpc.System.VersionAsync(cancellationToken)
            );

            if (_blockchainStaticInformations.RelayChains == null)
                return null;

            var infos = _blockchainStaticInformations.RelayChains
                .SelectMany(x => x.BlockainInformations)
                .SingleOrDefault(x => x.Name == _substrateNodeRepository.BlockchainName);

            return new BlockchainDetailsDto()
            {
                BlockchainInformationDetail = infos ?? new BlockchainProject(),
                IsRelayChain = _blockchainStaticInformations.RelayChains.Any(x => x.RelayChainName == _substrateNodeRepository.BlockchainName),
                FullName = fullName,
                IsAlive = health.ShouldHavePeers,
                TokenDecimal = properties.TokenDecimals,
                TokenSymbol = properties.TokenSymbol,
                Version = version
            };
        }


        public async Task<IEnumerable<ParachainLightDto>> GetParachainsAsync(CancellationToken cancellationToken)
        {
            var parachainsDto = new List<ParachainLightDto>();
            var parachainsId = await _substrateNodeRepository.Storage.Paras.ParachainsAsync(cancellationToken);

            if (parachainsId == null)
                return parachainsDto;

            //Storage.Slots.LeasesAsync()
            foreach (var parachainId in parachainsId.Value)
            {
                var registerStatus = await _substrateNodeRepository.Storage.Paras.ParaLifecyclesAsync(parachainId, cancellationToken);

                //var infos = _blockchainStaticInformations.RelayChains
                //    .SelectMany(x => x.BlockainInformations)
                //    .Where(x => x.ParachainId is not null)
                //    .SingleOrDefault(x => (uint)x.ParachainId.Value == parachainId.Value.Value);
                var infos = GetBlockchainProject(_substrateNodeRepository.BlockchainName, parachainId.Value.Value);
                var parachainDto = new ParachainLightDto()
                {
                    ParachainId = parachainId.Value.Value,
                    RegisterStatus = DisplayParachainRegisterStatus(registerStatus),
                    Name = infos != null ? infos.Name : string.Empty
                };

                parachainsDto.Add(parachainDto);
            }

            return parachainsDto;
        }
        public async Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken)
        {
            var paraId = new Contracts.Core.Id(new U32(parachainId));
            var accountRegistar = await _substrateNodeRepository.Storage.Registrar.ParasAsync(paraId, cancellationToken);

            var owner = await _accountRepository.GetAccountIdentityAsync(accountRegistar.Manager, cancellationToken);
            //var fundAccount = accountRegistar.
            var registerStatus = await _substrateNodeRepository.Storage.Paras.ParaLifecyclesAsync(paraId, cancellationToken);

            var infos = _blockchainStaticInformations.RelayChains?
                    .SelectMany(x => x.BlockainInformations)
                    .Where(x => x.ParachainId is not null)
                    .SingleOrDefault(x => (uint)x.ParachainId.Value == parachainId);

            var parachainDto = new ParachainDto();
            parachainDto.ParachainId = parachainId;
            parachainDto.OwnerAccount = owner;
            parachainDto.RegisterStatus = DisplayParachainRegisterStatus(registerStatus);
            parachainDto.BlockchainInformationDetail = infos;

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
