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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.pallet_gilt.pallet
{
    /// <summary>
    /// >> 12206 - Composite[pallet_gilt.pallet.ActiveGiltsTotal]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ActiveGiltsTotal : ActiveGiltsTotalBase
    {
        public override System.String TypeName()
        {
            return "ActiveGiltsTotal";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Frozen.Encode());
            result.AddRange(Proportion.Encode());
            result.AddRange(Index.Encode());
            result.AddRange(Target.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Frozen = new Substrate.NetApi.Model.Types.Primitive.U128();
            Frozen.Decode(byteArray, ref p);
            Proportion = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.sp_arithmetic.per_things.Perquintill();
            Proportion.Decode(byteArray, ref p);
            Index = new Substrate.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            Target = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9230.sp_arithmetic.per_things.Perquintill();
            Target.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}