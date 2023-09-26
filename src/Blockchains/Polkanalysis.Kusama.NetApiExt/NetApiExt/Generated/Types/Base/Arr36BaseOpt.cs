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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Types.Base
{
    /// <summary>
    /// >> 20350 - Array
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Array)]
    public sealed class Arr36BaseOpt : BaseType
    {
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>>[] Value { get; set; }

        public override int TypeSize
        {
            get
            {
                return 36;
            }
        }

        public override string TypeName()
        {
            return string.Format("[{0}; {1}]", new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>>().TypeName(), TypeSize);
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            foreach (var v in Value)
            {
                result.AddRange(v.Encode());
            }

            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            var array = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>>[TypeSize];
            for (var i = 0; i < array.Length; i++)
            {
                var t = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>>();
                t.Decode(byteArray, ref p);
                array[i] = t;
            }

            var bytesLength = p - start;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
            Value = array;
        }

        public void Create(Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.sp_core.crypto.AccountId32, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9111.polkadot_parachain.primitives.Id, Substrate.NetApi.Model.Types.Primitive.U128>>[] array)
        {
            Value = array;
            Bytes = Encode();
        }
    }
}