using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.TransactionPayment.Enums
{
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
