using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums
{
    public enum FreezeReason
    {
        PoolMinBalance
    }

    public sealed class EnumFreezeReason : BaseEnum<FreezeReason>
    {
    }
}
