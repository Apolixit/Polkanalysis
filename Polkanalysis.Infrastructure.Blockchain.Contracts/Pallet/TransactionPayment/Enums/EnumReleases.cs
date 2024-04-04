using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.TransactionPayment.Enums
{
    [DomainMapping("pallet_transaction_payment")]
    public enum Releases
    {

        V1Ancient = 0,

        V2 = 1,
    }

    /// <summary>
    /// >> 479 - Variant[pallet_transaction_payment.Releases]
    /// </summary>
    public sealed class EnumReleases : BaseEnum<Releases>
    {
    }
}
