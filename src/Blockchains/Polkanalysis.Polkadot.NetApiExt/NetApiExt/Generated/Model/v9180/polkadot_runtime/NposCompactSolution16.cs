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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_runtime
{
    /// <summary>
    /// >> 3474 - Composite[polkadot_runtime.NposCompactSolution16]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class NposCompactSolution16 : NposCompactSolution16Base
    {
        public override System.String TypeName()
        {
            return "NposCompactSolution16";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            result.AddRange(Votes16.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>, Substrate.NetApi.Model.Types.Base.BaseCom<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.sp_arithmetic.per_things.PerU16>>, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr2BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr3BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr4BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr5BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr6BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr7BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr8BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr9BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr10BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr11BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr12BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr13BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr14BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            Votes16 = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>, Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr15BaseTuple, Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U16>>>();
            Votes16.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}