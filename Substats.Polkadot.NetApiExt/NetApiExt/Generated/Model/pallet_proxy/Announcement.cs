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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_proxy
{
    
    
    /// <summary>
    /// >> 584 - Composite[pallet_proxy.Announcement]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Announcement : BaseType
    {
        
        /// <summary>
        /// >> real
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _real;
        
        /// <summary>
        /// >> call_hash
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _callHash;
        
        /// <summary>
        /// >> height
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _height;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Real
        {
            get
            {
                return this._real;
            }
            set
            {
                this._real = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 CallHash
        {
            get
            {
                return this._callHash;
            }
            set
            {
                this._callHash = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 Height
        {
            get
            {
                return this._height;
            }
            set
            {
                this._height = value;
            }
        }
        
        public override string TypeName()
        {
            return "Announcement";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Real.Encode());
            result.AddRange(CallHash.Encode());
            result.AddRange(Height.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Real = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Real.Decode(byteArray, ref p);
            CallHash = new Substats.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            CallHash.Decode(byteArray, ref p);
            Height = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Height.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
