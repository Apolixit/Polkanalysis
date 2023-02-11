using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Babe
{
    public enum PreDigest
    {

        Primary = 1,

        SecondaryPlain = 2,

        SecondaryVRF = 3,
    }

    /// <summary>
    /// >> 462 - Variant[sp_consensus_babe.digests.PreDigest]
    /// </summary>
    public sealed class EnumPreDigest : BaseEnumExt<PreDigest, BaseVoid, PrimaryPreDigest, SecondaryPlainPreDigest, SecondaryVRFPreDigest>
    {
    }
}
