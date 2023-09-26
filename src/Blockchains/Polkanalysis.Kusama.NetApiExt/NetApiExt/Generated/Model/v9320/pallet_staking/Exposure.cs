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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_staking
{
    /// <summary>
    /// >> 6074 - Composite[pallet_staking.Exposure]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Exposure : ExposureBase
    {
        public override System.String TypeName()
        {
            return "Exposure";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Total.Encode());
            result.AddRange(Own.Encode());
            result.AddRange(Others.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Total = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            Total.Decode(byteArray, ref p);
            Own = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U128>();
            Own.Decode(byteArray, ref p);
            Others = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9320.pallet_staking.IndividualExposure>();
            Others.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}