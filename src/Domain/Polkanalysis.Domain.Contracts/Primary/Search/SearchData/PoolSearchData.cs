using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Dto.GlobalStatusDto;

namespace Polkanalysis.Domain.Contracts.Primary.Search.SearchData
{
    public record PoolSearchData(uint PoolId, string PoolName, NominationPoolStatusDto Status)
    {
    }
}
