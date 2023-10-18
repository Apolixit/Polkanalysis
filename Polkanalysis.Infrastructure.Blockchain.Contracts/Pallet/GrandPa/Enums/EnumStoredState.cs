using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.GrandPa.Enums
{
    public enum StoredState
    {

        Live = 0,

        PendingPause = 1,

        Paused = 2,

        PendingResume = 3,
    }

    /// <summary>
    /// >> 515 - Variant[pallet_grandpa.StoredState]
    /// </summary>
    public sealed class EnumStoredState : BaseEnumExt<StoredState, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>, BaseVoid, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>
    {
    }
}
