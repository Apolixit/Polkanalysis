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


namespace Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map
{
    
    
    /// <summary>
    /// >> 605 - Composite[sp_core.bounded.bounded_btree_map.BoundedBTreeMapT1]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class BoundedBTreeMapT1 : BaseType
    {
        
        /// <summary>
        /// >> value
        /// </summary>
        private Blazscan.Polkadot.NetApiExt.Generated.Types.Base.BTreeMapT2 _value;
        
        public Blazscan.Polkadot.NetApiExt.Generated.Types.Base.BTreeMapT2 Value
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
            return "BoundedBTreeMapT1";
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
            Value = new Blazscan.Polkadot.NetApiExt.Generated.Types.Base.BTreeMapT2();
            Value.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}