using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using Newtonsoft.Json.Linq;

namespace Polkanalysis.Domain.Repository
{
    public class PolkadotCrowdloanRepository : ICrowdloanRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;
        private readonly IModelBuilder _modelBuilder;
        private readonly IExplorerRepository _explorerRepository;
        private readonly IAccountRepository _accountRepository;

        public PolkadotCrowdloanRepository(
            ISubstrateRepository substrateNodeRepository,
            IModelBuilder modelBuilder,
            IExplorerRepository explorerRepository,
            IAccountRepository accountRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
            _modelBuilder = modelBuilder;
            _explorerRepository = explorerRepository;
            _accountRepository = accountRepository;
        }

        public async Task<IEnumerable<CrowdloanListDto>> GetCrowdloansAsync(CancellationToken cancellationToken)
        {
            var crowdloans = await _substrateNodeRepository.Storage.Crowdloan.FundsAllAsync(cancellationToken);

            var crowdloansDto = new List<CrowdloanListDto>();
            if (crowdloans == null) return crowdloansDto;

            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(cancellationToken);

            foreach (var crowdloan in crowdloans)
            {
                var fundTarget = crowdloan.Item2.Cap.Value.ToDouble(chainInfo.TokenDecimals);
                var fundRaised = crowdloan.Item2.Raised.Value.ToDouble(chainInfo.TokenDecimals);
                var blockStart = await _explorerRepository.GetBlockLightAsync(crowdloan.Item2.FirstPeriod.Value, cancellationToken);
                var blockEnd = await _explorerRepository.GetBlockLightAsync(crowdloan.Item2.LastPeriod.Value, cancellationToken);

                crowdloansDto.Add(new CrowdloanListDto()
                {
                    CrowdloanId = crowdloan.Item1.ToString(),
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
                Lease = new LeaseDto() { 
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
