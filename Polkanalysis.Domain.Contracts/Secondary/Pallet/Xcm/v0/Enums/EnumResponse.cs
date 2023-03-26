using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Xcm.v0.Enums
{
    public enum Response
    {

        Assets = 0,
    }

    /// <summary>
    /// >> 429 - Variant[xcm.v0.Response]
    /// </summary>
    public sealed class EnumResponse : BaseEnumExt<Response, BaseVec<EnumMultiAsset>>
    {
    }
}
