using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    [DomainMapping("pallet_nomination_pools/pallet")]
    public enum FreezeReason
    {
        PoolMinBalance
    }

    public sealed class EnumFreezeReason : BaseEnum<FreezeReason>
    {
    }
}
