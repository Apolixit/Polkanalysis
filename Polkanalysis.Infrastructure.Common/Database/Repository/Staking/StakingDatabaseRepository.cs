using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Staking;
using Polkanalysis.Domain.Contracts.Core;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;

namespace Polkanalysis.Infrastructure.Common.Database.Repository.Staking
{
    public class StakingDatabaseRepository : IStakingDatabaseRepository
    {
        protected readonly SubstrateDbContext _context;
        protected readonly ILogger<StakingDatabaseRepository> _logger;

        public StakingDatabaseRepository(SubstrateDbContext context, ILogger<StakingDatabaseRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void InsertEraStakers(string blockchainName, U32 eraId, (BaseTuple<U32, SubstrateAccount>, Exposure) eraStakers)
        {
            try
            {
                _context.EraStakersModels.Add(new EraStakersModel(eraStakers, blockchainName, eraId));
                var nbRows = _context.SaveChanges();
                if (nbRows != 1)
                    throw new InvalidOperationException("Inserted rows are inconsistent");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while trying to insert in database");
            }
        }

        public IEnumerable<(BaseTuple<U32, SubstrateAccount>, Exposure)> GetAllEraStackers(int eraId)
        {
            var eraStackersModel = _context.EraStakersModels.Where(x => x.EraId == eraId);
            return eraStackersModel.Select(x => x.ToCore());
        }

        public (BaseTuple<U32, SubstrateAccount>, Exposure)? GetEraValidator(int eraId, SubstrateAccount validatorAccount)
        {
            return _context.EraStakersModels
                .SingleOrDefault(x => x.EraId == eraId && x.ValidatorAddress == validatorAccount.ToPolkadotAddress())?
                .ToCore();
        }
    }
}
