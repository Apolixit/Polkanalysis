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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_staking;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.pallet_staking
{
    /// <summary>
    /// >> 2016 - Composite[pallet_staking.ValidatorPrefs]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ValidatorPrefs : ValidatorPrefsBase
    {
        public override System.String TypeName()
        {
            return "ValidatorPrefs";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Commission.Encode());
            result.AddRange(Blocked.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Commission = new Substrate.NetApi.Model.Types.Base.BaseCom<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_arithmetic.per_things.Perbill>();
            Commission.Decode(byteArray, ref p);
            Blocked = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Blocked.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}