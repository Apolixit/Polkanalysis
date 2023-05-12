using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Crowdloan;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;

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

        public async Task<CrowdloanDto> GetCrowdloanDetailAsync(string crowdloanId, CancellationToken token)
        {
            var ids = _modelBuilder.CreateTuppleIndex(crowdloanId);
            var chainInfo = await _substrateNodeRepository.Rpc.System.PropertiesAsync(token);

            var crowdloanDetail = await _substrateNodeRepository.Storage.Crowdloan.FundsAsync(new Contracts.Core.Id(ids.subId), token);

            BlockLightDto? lastBlockContribution = crowdloanDetail.LastContribution.Value switch
            {
                LastContribution.Never => null,
                LastContribution.PreEnding => await _explorerRepository.GetBlockLightAsync(((U32)crowdloanDetail.LastContribution.Value2).Value, token),
                LastContribution.Ending => await _explorerRepository.GetBlockLightAsync(((U32)crowdloanDetail.LastContribution.Value2).Value, token),
                _ => throw new InvalidOperationException("Unknown crowdloan LastContribution")
            };

            var depositorAccount = await _accountRepository.GetAccountIdentityAsync(crowdloanDetail.Depositor, token);
            var fundTarget = crowdloanDetail.Cap.Value.ToDouble(chainInfo.TokenDecimals);
            var fundRaised = crowdloanDetail.Raised.Value.ToDouble(chainInfo.TokenDecimals);

            var blockStart = await _explorerRepository.GetBlockLightAsync(crowdloanDetail.FirstPeriod.Value, token);
            var blockEnd = await _explorerRepository.GetBlockLightAsync(crowdloanDetail.LastPeriod.Value, token);

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
