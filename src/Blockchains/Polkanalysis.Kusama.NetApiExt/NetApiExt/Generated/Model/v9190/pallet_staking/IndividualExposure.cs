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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.pallet_staking
{
    /// <summary>
    /// >> 13899 - Composite[pallet_staking.IndividualExposure]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class IndividualExposure : IndividualExposureBase
    {
        public override System.String TypeName()
        {
            return "IndividualExposure";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Value.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9190.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Value = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            Value.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}