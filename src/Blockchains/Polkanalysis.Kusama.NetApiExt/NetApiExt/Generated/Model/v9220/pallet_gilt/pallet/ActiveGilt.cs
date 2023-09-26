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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.pallet_gilt.pallet;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.pallet_gilt.pallet
{
    /// <summary>
    /// >> 12983 - Composite[pallet_gilt.pallet.ActiveGilt]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ActiveGilt : ActiveGiltBase
    {
        public override System.String TypeName()
        {
            return "ActiveGilt";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Proportion.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(Who.Encode());
            result.AddRange(Expiry.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Proportion = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_arithmetic.per_things.Perquintill();
            Proportion.Decode(byteArray, ref p);
            Amount = new Substrate.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            Who = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9220.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Expiry = new Substrate.NetApi.Model.Types.Primitive.U32();
            Expiry.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}