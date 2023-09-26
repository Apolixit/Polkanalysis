//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_scheduler;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.pallet_scheduler
{
    /// <summary>
    /// >> 4032 - Composite[pallet_scheduler.ScheduledV3]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ScheduledV3 : ScheduledV3Base
    {
        public override System.String TypeName()
        {
            return "ScheduledV3";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaybeId.Encode());
            result.AddRange(Priority.Encode());
            result.AddRange(Call.Encode());
            result.AddRange(MaybePeriodic.Encode());
            result.AddRange(Origin.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaybeId = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>();
            MaybeId.Decode(byteArray, ref p);
            Priority = new Substrate.NetApi.Model.Types.Primitive.U8();
            Priority.Decode(byteArray, ref p);
            Call = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.frame_support.traits.schedule.EnumMaybeHashed();
            Call.Decode(byteArray, ref p);
            MaybePeriodic = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Primitive.U32, Substrate.NetApi.Model.Types.Primitive.U32>>();
            MaybePeriodic.Decode(byteArray, ref p);
            Origin = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_runtime.EnumOriginCaller();
            Origin.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}