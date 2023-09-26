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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_staking.offence;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.sp_staking.offence
{
    /// <summary>
    /// >> 7848 - Composite[sp_staking.offence.OffenceDetails]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class OffenceDetails : OffenceDetailsBase
    {
        public override System.String TypeName()
        {
            return "OffenceDetails";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Offender.Encode());
            result.AddRange(Reporters.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Offender = new Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.pallet_staking.Exposure>();
            Offender.Decode(byteArray, ref p);
            Reporters = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32>();
            Reporters.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}