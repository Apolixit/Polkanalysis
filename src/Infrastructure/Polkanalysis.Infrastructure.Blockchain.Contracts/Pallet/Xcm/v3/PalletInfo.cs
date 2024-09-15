//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Metadata.Base;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Xcm.v3
{
    /// <summary>
    /// >> 16791 - Composite[xcm.v3.PalletInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PalletInfo : BaseType
    {
        /// <summary>
        /// >> index
        /// </summary>
        public BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Index { get; set; }
        /// <summary>
        /// >> name
        /// </summary>
        public BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> Name { get; set; }
        /// <summary>
        /// >> module_name
        /// </summary>
        public BaseVec<Substrate.NetApi.Model.Types.Primitive.U8> ModuleName { get; set; }
        /// <summary>
        /// >> major
        /// </summary>
        public BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Major { get; set; }
        /// <summary>
        /// >> minor
        /// </summary>
        public BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Minor { get; set; }
        /// <summary>
        /// >> patch
        /// </summary>
        public BaseCom<Substrate.NetApi.Model.Types.Primitive.U32> Patch { get; set; }
        public override string TypeName()
        {
            return "PalletInfo";
        }

        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Name.Encode());
            result.AddRange(ModuleName.Encode());
            result.AddRange(Major.Encode());
            result.AddRange(Minor.Encode());
            result.AddRange(Patch.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Index.Decode(byteArray, ref p);
            Name = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            Name.Decode(byteArray, ref p);
            ModuleName = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>();
            ModuleName.Decode(byteArray, ref p);
            Major = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Major.Decode(byteArray, ref p);
            Minor = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Minor.Decode(byteArray, ref p);
            Patch = new Substrate.NetApi.Model.Types.Base.BaseCom<Substrate.NetApi.Model.Types.Primitive.U32>();
            Patch.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}