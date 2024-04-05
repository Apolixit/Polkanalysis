using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Democracy.Enums
{
    [DomainMapping("pallet_democracy")]
    public enum Releases
    {

        V1 = 0,
    }

    /// <summary>
    /// >> 541 - Variant[pallet_democracy.Releases]
    /// </summary>
    public sealed class EnumReleases : BaseEnum<Releases>
    {
    }
}
