using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Referenda.Types.Enums
{
    [DomainMapping("pallet_referenda/types")]
    public enum Curve
    {
        LinearDecreasing = 0,
        SteppedDecreasing = 1,
        Reciprocal = 2
    }

    /// <summary>
    /// >> 14527 - Variant[pallet_referenda.types.Curve]
    /// </summary>
    public sealed class EnumCurve : BaseEnumExt<Curve, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.per_things.Perbill>, BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.fixed_point.FixedI64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.fixed_point.FixedI64, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9420.sp_arithmetic.fixed_point.FixedI64>>
    {
    }
}
