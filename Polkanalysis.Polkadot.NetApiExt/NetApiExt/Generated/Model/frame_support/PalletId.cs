//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Attributes;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Metadata.V14;
using System.Collections.Generic;


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_support
{
    
    
    /// <summary>
    /// >> 560 - Composite[frame_support.PalletId]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class PalletId : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr8U8 _value;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr8U8 Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value;
            }
        }
        
        public override string TypeName()
        {
            return "PalletId";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Value.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Value = new Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr8U8();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
