using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.Staking.Nominator;
using Polkanalysis.Domain.Contracts.Primary.Result;
using StreamJsonRpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Staking.Nominators
{
    public class NominatorsQuery : IRequest<Result<IEnumerable<NominatorLightDto>, ErrorResult>>, ICached
    {
        public string? ValidatorAddress { get; set; }

        public int CacheDurationInMinutes => Settings.Constants.Cache.FastCache;

        public string GenerateCacheKey()
        {
            if (ValidatorAddress is not null)
            {
                return $"NominatorsQuery_{ValidatorAddress}";
            }
            return "NominatorsQuery_All";
        }
    }
}
