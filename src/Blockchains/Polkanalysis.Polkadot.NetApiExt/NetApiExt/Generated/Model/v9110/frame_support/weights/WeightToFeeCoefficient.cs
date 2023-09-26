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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.frame_support.weights;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.frame_support.weights
{
    /// <summary>
    /// >> 387 - Composite[frame_support.weights.WeightToFeeCoefficient]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class WeightToFeeCoefficient : WeightToFeeCoefficientBase
    {
        public override System.String TypeName()
        {
            return "WeightToFeeCoefficient";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(CoeffInteger.Encode());
            result.AddRange(CoeffFrac.Encode());
            result.AddRange(Negative.Encode());
            result.AddRange(Degree.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            CoeffInteger = new Substrate.NetApi.Model.Types.Primitive.U128();
            CoeffInteger.Decode(byteArray, ref p);
            CoeffFrac = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9110.sp_arithmetic.per_things.Perbill();
            CoeffFrac.Decode(byteArray, ref p);
            Negative = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Negative.Decode(byteArray, ref p);
            Degree = new Substrate.NetApi.Model.Types.Primitive.U8();
            Degree.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}