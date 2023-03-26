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


namespace Substats.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation
{
    
    
    /// <summary>
    /// >> 125 - Composite[xcm.v1.multilocation.MultiLocation]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class MultiLocation : BaseType
    {
        
        /// <summary>
        /// >> parents
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U8 _parents;
        
        /// <summary>
        /// >> interior
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.EnumJunctions _interior;
        
        public Ajuna.NetApi.Model.Types.Primitive.U8 Parents
        {
            get
            {
                return this._parents;
            }
            set
            {
                this._parents = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.EnumJunctions Interior
        {
            get
            {
                return this._interior;
            }
            set
            {
                this._interior = value;
            }
        }
        
        public override string TypeName()
        {
            return "MultiLocation";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Parents.Encode());
            result.AddRange(Interior.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Parents = new Ajuna.NetApi.Model.Types.Primitive.U8();
            Parents.Decode(byteArray, ref p);
            Interior = new Substats.Polkadot.NetApiExt.Generated.Model.xcm.v1.multilocation.EnumJunctions();
            Interior.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
