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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.xcm.double_encoded
{
    
    
    /// <summary>
    /// >> 259 - Composite[xcm.double_encoded.DoubleEncodedT2]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class DoubleEncodedT2 : BaseType
    {
        
        /// <summary>
        /// >> encoded
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> _encoded;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8> Encoded
        {
            get
            {
                return this._encoded;
            }
            set
            {
                this._encoded = value;
            }
        }
        
        public override string TypeName()
        {
            return "DoubleEncodedT2";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Encoded.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Encoded = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Primitive.U8>();
            Encoded.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
