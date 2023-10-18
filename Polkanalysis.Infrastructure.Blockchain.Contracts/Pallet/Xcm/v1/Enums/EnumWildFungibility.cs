using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v1.Enums
{
    public enum WildFungibility
    {

        Fungible = 0,

        NonFungible = 1,
    }

    /// <summary>
    /// >> 147 - Variant[xcm.v1.multiasset.WildFungibility]
    /// </summary>
    public sealed class EnumWildFungibility : BaseEnum<WildFungibility>
    {
    }
}
