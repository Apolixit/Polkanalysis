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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_multisig
{
    
    
    /// <summary>
    /// >> 589 - Composite[pallet_multisig.Multisig]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Multisig : BaseType
    {
        
        /// <summary>
        /// >> when
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.pallet_multisig.Timepoint _when;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _deposit;
        
        /// <summary>
        /// >> depositor
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _depositor;
        
        /// <summary>
        /// >> approvals
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT24 _approvals;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.pallet_multisig.Timepoint When
        {
            get
            {
                return this._when;
            }
            set
            {
                this._when = value;
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
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Depositor
        {
            get
            {
                return this._depositor;
            }
            set
            {
                this._depositor = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT24 Approvals
        {
            get
            {
                return this._approvals;
            }
            set
            {
                this._approvals = value;
            }
        }
        
        public override string TypeName()
        {
            return "Multisig";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(When.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Depositor.Encode());
            result.AddRange(Approvals.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            When = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_multisig.Timepoint();
            When.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Depositor = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Depositor.Decode(byteArray, ref p);
            Approvals = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT24();
            Approvals.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
