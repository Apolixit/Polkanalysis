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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan
{
    
    
    /// <summary>
    /// >> 712 - Composite[polkadot_runtime_common.crowdloan.FundInfo]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class FundInfo : BaseType
    {
        
        /// <summary>
        /// >> depositor
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _depositor;
        
        /// <summary>
        /// >> verifier
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseOpt<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.EnumMultiSigner> _verifier;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _deposit;
        
        /// <summary>
        /// >> raised
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _raised;
        
        /// <summary>
        /// >> end
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _end;
        
        /// <summary>
        /// >> cap
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _cap;
        
        /// <summary>
        /// >> last_contribution
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.EnumLastContribution _lastContribution;
        
        /// <summary>
        /// >> first_period
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _firstPeriod;
        
        /// <summary>
        /// >> last_period
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _lastPeriod;
        
        /// <summary>
        /// >> fund_index
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _fundIndex;
        
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
        
        public Ajuna.NetApi.Model.Types.Base.BaseOpt<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.EnumMultiSigner> Verifier
        {
            get
            {
                return this._verifier;
            }
            set
            {
                this._verifier = value;
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
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Raised
        {
            get
            {
                return this._raised;
            }
            set
            {
                this._raised = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 End
        {
            get
            {
                return this._end;
            }
            set
            {
                this._end = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Cap
        {
            get
            {
                return this._cap;
            }
            set
            {
                this._cap = value;
            }
        }
        
        public Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.EnumLastContribution LastContribution
        {
            get
            {
                return this._lastContribution;
            }
            set
            {
                this._lastContribution = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 FirstPeriod
        {
            get
            {
                return this._firstPeriod;
            }
            set
            {
                this._firstPeriod = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 LastPeriod
        {
            get
            {
                return this._lastPeriod;
            }
            set
            {
                this._lastPeriod = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 FundIndex
        {
            get
            {
                return this._fundIndex;
            }
            set
            {
                this._fundIndex = value;
            }
        }
        
        public override string TypeName()
        {
            return "FundInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Depositor.Encode());
            result.AddRange(Verifier.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Raised.Encode());
            result.AddRange(End.Encode());
            result.AddRange(Cap.Encode());
            result.AddRange(LastContribution.Encode());
            result.AddRange(FirstPeriod.Encode());
            result.AddRange(LastPeriod.Encode());
            result.AddRange(FundIndex.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Depositor = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Depositor.Decode(byteArray, ref p);
            Verifier = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.EnumMultiSigner>();
            Verifier.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Raised = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Raised.Decode(byteArray, ref p);
            End = new Ajuna.NetApi.Model.Types.Primitive.U32();
            End.Decode(byteArray, ref p);
            Cap = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Cap.Decode(byteArray, ref p);
            LastContribution = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.crowdloan.EnumLastContribution();
            LastContribution.Decode(byteArray, ref p);
            FirstPeriod = new Ajuna.NetApi.Model.Types.Primitive.U32();
            FirstPeriod.Decode(byteArray, ref p);
            LastPeriod = new Ajuna.NetApi.Model.Types.Primitive.U32();
            LastPeriod.Decode(byteArray, ref p);
            FundIndex = new Ajuna.NetApi.Model.Types.Primitive.U32();
            FundIndex.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
