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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_nomination_pools
{
    
    
    /// <summary>
    /// >> 743 - Composite[pallet_nomination_pools.SubPools]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class SubPools : BaseType
    {
        
        /// <summary>
        /// >> no_era
        /// </summary>
        private Substats.Kusama.NetApiExt.Generated.Model.pallet_nomination_pools.UnbondPool _noEra;
        
        /// <summary>
        /// >> with_era
        /// </summary>
        private Substats.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2 _withEra;
        
        public Substats.Kusama.NetApiExt.Generated.Model.pallet_nomination_pools.UnbondPool NoEra
        {
            get
            {
                return this._noEra;
            }
            set
            {
                this._noEra = value;
            }
        }
        
        public Substats.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2 WithEra
        {
            get
            {
                return this._withEra;
            }
            set
            {
                this._withEra = value;
            }
        }
        
        public override string TypeName()
        {
            return "SubPools";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(NoEra.Encode());
            result.AddRange(WithEra.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            NoEra = new Substats.Kusama.NetApiExt.Generated.Model.pallet_nomination_pools.UnbondPool();
            NoEra.Decode(byteArray, ref p);
            WithEra = new Substats.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_btree_map.BoundedBTreeMapT2();
            WithEra.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
