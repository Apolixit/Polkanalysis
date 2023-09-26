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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_staking;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.pallet_staking
{
    /// <summary>
    /// >> 557 - Composite[pallet_staking.Nominations]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Nominations : NominationsBase
    {
        public override System.String TypeName()
        {
            return "Nominations";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Targets.Encode());
            result.AddRange(SubmittedIn.Encode());
            result.AddRange(Suppressed.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Targets = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9430.sp_core.crypto.AccountId32>();
            Targets.Decode(byteArray, ref p);
            SubmittedIn = new Substrate.NetApi.Model.Types.Primitive.U32();
            SubmittedIn.Decode(byteArray, ref p);
            Suppressed = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Suppressed.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}