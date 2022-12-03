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


namespace Blazscan.NetApiExt.Generated.Model.pallet_fast_unstake.types
{
    
    
    /// <summary>
    /// >> 633 - Composite[pallet_fast_unstake.types.UnstakeRequest]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class UnstakeRequest : BaseType
    {
        
        /// <summary>
        /// >> stash
        /// </summary>
        private Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _stash;
        
        /// <summary>
        /// >> checked
        /// </summary>
        private Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT21 _checked;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _deposit;
        
        public Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Stash
        {
            get
            {
                return this._stash;
            }
            set
            {
                this._stash = value;
            }
        }
        
        public Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT21 Checked
        {
            get
            {
                return this._checked;
            }
            set
            {
                this._checked = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Deposit
        {
            get
            {
                return this._deposit;
            }
            set
            {
                this._deposit = value;
            }
        }
        
        public override string TypeName()
        {
            return "UnstakeRequest";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Stash.Encode());
            result.AddRange(Checked.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Stash = new Blazscan.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Stash.Decode(byteArray, ref p);
            Checked = new Blazscan.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT21();
            Checked.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
