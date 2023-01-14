//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Attributes;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset
{
    
    
    /// <summary>
    /// >> 72 - Composite[xcm.v1.multiasset.MultiAsset]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class MultiAsset : BaseType
    {
        
        /// <summary>
        /// >> id
        /// </summary>
        private Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumAssetId _id;
        
        /// <summary>
        /// >> fun
        /// </summary>
        private Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumFungibility _fun;
        
        public Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumAssetId Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        
        public Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumFungibility Fun
        {
            get
            {
                return this._fun;
            }
            set
            {
                this._fun = value;
            }
        }
        
        public override string TypeName()
        {
            return "MultiAsset";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Fun.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumAssetId();
            Id.Decode(byteArray, ref p);
            Fun = new Substats.Bajun.NetApiExt.Generated.Model.xcm.v1.multiasset.EnumFungibility();
            Fun.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
