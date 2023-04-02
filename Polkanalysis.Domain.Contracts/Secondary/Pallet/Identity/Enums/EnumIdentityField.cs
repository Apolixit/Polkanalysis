using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity.Enums
{
    public enum IdentityField
    {

        Display = 1,

        Legal = 2,

        Web = 4,

        Riot = 8,

        Email = 16,

        PgpFingerprint = 32,

        Image = 64,

        Twitter = 128,
    }

    /// <summary>
    /// >> 301 - Variant[pallet_identity.types.IdentityField]
    /// </summary>
    public sealed class EnumIdentityField : BaseEnum<IdentityField>
    {
    }
}
