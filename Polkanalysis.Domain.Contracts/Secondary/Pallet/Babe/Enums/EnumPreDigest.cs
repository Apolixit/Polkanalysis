using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe.Enums
{
    public enum PreDigest
    {

        Primary = 1,

        SecondaryPlain = 2,

        SecondaryVRF = 3,
    }

    public sealed class EnumPreDigest : BaseEnumExt<PreDigest, BaseVoid, PrimaryPreDigest, SecondaryPlainPreDigest, SecondaryVRFPreDigest>
    {
    }
}
