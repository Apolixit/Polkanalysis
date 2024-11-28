using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.Era;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Eras
{
    public class ErasQuery : IRequest<Result<IEnumerable<EraLightDto>, ErrorResult>>, ICached
    {
        public string? ValidatorAddress { get; set; }

        public int CacheDurationInMinutes => Settings.Constants.Cache.FastCache;

        public string GenerateCacheKey()
        {
            if (ValidatorAddress is not null)
            {
                return $"ErasQuery_{ValidatorAddress}";
            }
            return "ErasQuery_All";
        }
    }
}
