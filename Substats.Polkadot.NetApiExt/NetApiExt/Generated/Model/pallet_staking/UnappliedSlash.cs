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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_staking
{
    
    
    /// <summary>
    /// >> 502 - Composite[pallet_staking.UnappliedSlash]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class UnappliedSlash : BaseType
    {
        
        /// <summary>
        /// >> validator
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _validator;
        
        /// <summary>
        /// >> own
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _own;
        
        /// <summary>
        /// >> others
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>> _others;
        
        /// <summary>
        /// >> reporters
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> _reporters;
        
        /// <summary>
        /// >> payout
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _payout;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Validator
        {
            get
            {
                return this._validator;
            }
            set
            {
                this._validator = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Own
        {
            get
            {
                return this._own;
            }
            set
            {
                this._own = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>> Others
        {
            get
            {
                return this._others;
            }
            set
            {
                this._others = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Reporters
        {
            get
            {
                return this._reporters;
            }
            set
            {
                this._reporters = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Payout
        {
            get
            {
                return this._payout;
            }
            set
            {
                this._payout = value;
            }
        }
        
        public override string TypeName()
        {
            return "UnappliedSlash";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Validator.Encode());
            result.AddRange(Own.Encode());
            result.AddRange(Others.Encode());
            result.AddRange(Reporters.Encode());
            result.AddRange(Payout.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Validator = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Validator.Decode(byteArray, ref p);
            Own = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Own.Decode(byteArray, ref p);
            Others = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>();
            Others.Decode(byteArray, ref p);
            Reporters = new Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>();
            Reporters.Decode(byteArray, ref p);
            Payout = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Payout.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
