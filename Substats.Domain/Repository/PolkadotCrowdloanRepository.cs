using Substats.AjunaExtension;
using Substats.Domain.Contracts.Dto;
using Substats.Domain.Contracts.Dto.Parachain;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Repository
{
    public class PolkadotCrowdloanRepository : ICrowdloanRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;
        private readonly IModelBuilder _modelBuilder;

        public PolkadotCrowdloanRepository(
            ISubstrateRepository substrateNodeRepository,
            IModelBuilder modelBuilder)
        {
            _substrateNodeRepository = substrateNodeRepository;
            _modelBuilder = modelBuilder;
        }

        public async Task<CrowdloanDto> GetCrowdloanDetailAsync(string crowdloanId, CancellationToken token)
        {
            var ids = _modelBuilder.CreateTuppleIndex(crowdloanId);

            var crowdloanDetail = await _substrateNodeRepository.Api.Storage.Crowdloan.FundsAsync(new Contracts.Core.Id(ids.subId), token);

            return null;
        }
    }
}
