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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_collator_selection.pallet
{
    
    
    /// <summary>
    /// >> 329 - Composite[pallet_collator_selection.pallet.CandidateInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateInfo : BaseType
    {
        
        /// <summary>
        /// >> who
        /// </summary>
        private Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _who;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U128 _deposit;
        
        public Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Who
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
        
        public Substrate.NetApi.Model.Types.Primitive.U128 Deposit
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
            return "CandidateInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Who.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Who = new Polkanalysis.Bajun.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Who.Decode(byteArray, ref p);
            Deposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
