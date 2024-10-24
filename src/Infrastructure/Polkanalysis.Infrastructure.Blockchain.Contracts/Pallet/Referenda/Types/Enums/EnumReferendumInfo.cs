using Polkanalysis.Infrastructure.Blockchain.Contracts.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Types.Enums
{
    [DomainMapping("pallet_referenda/types")]
    public enum ReferendumInfo
    {
        Ongoing = 0,
        Approved = 1,
        Rejected = 2,
        Cancelled = 3,
        TimedOut = 4,
        Killed = 5
    }

    /// <summary>
    /// >> 14513 - Variant[pallet_referenda.types.ReferendumInfo]
    /// </summary>
    public sealed class EnumReferendumInfo : BaseEnumExt<ReferendumInfo, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.ReferendumStatus, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>>, BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>, Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.pallet_referenda.types.Deposit>>, Substrate.NetApi.Model.Types.Primitive.U32>
    {
    }
}
