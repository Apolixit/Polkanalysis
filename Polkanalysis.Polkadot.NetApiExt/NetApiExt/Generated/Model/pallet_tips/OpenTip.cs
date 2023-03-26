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


namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_tips
{
    
    
    /// <summary>
    /// >> 599 - Composite[pallet_tips.OpenTip]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class OpenTip : BaseType
    {
        
        /// <summary>
        /// >> reason
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 _reason;
        
        /// <summary>
        /// >> who
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _who;
        
        /// <summary>
        /// >> finder
        /// </summary>
        private Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _finder;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _deposit;
        
        /// <summary>
        /// >> closes
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> _closes;
        
        /// <summary>
        /// >> tips
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>> _tips;
        
        /// <summary>
        /// >> finders_fee
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.Bool _findersFee;
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256 Reason
        {
            get
            {
                return this._reason;
            }
            set
            {
                this._reason = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Who
        {
            get
            {
                return this._who;
            }
            set
            {
                this._who = value;
            }
        }
        
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Finder
        {
            get
            {
                return this._finder;
            }
            set
            {
                this._finder = value;
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
        
        public Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32> Closes
        {
            get
            {
                return this._closes;
            }
            set
            {
                this._closes = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>> Tips
        {
            get
            {
                return this._tips;
            }
            set
            {
                this._tips = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.Bool FindersFee
        {
            get
            {
                return this._findersFee;
            }
            set
            {
                this._findersFee = value;
            }
        }
        
        public override string TypeName()
        {
            return "OpenTip";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Reason.Encode());
            result.AddRange(Who.Encode());
            result.AddRange(Finder.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Closes.Encode());
            result.AddRange(Tips.Encode());
            result.AddRange(FindersFee.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Reason = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.primitive_types.H256();
            Reason.Decode(byteArray, ref p);
            Who = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Finder = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Finder.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Closes = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U32>();
            Closes.Decode(byteArray, ref p);
            Tips = new Ajuna.NetApi.Model.Types.Base.BaseVec<Ajuna.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Ajuna.NetApi.Model.Types.Primitive.U128>>();
            Tips.Decode(byteArray, ref p);
            FindersFee = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            FindersFee.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
