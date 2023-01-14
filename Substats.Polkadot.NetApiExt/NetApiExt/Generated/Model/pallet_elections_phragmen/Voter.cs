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


namespace Substats.Polkadot.NetApiExt.Generated.Model.pallet_elections_phragmen
{
    
    
    /// <summary>
    /// >> 550 - Composite[pallet_elections_phragmen.Voter]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class Voter : BaseType
    {
        
        /// <summary>
        /// >> votes
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> _votes;
        
        /// <summary>
        /// >> stake
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _stake;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _deposit;
        
        public Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> Votes
        {
            get
            {
                return this._votes;
            }
            set
            {
                this._votes = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Stake
        {
            get
            {
                return this._stake;
            }
            set
            {
                this._stake = value;
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
            return "Voter";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Votes.Encode());
            result.AddRange(Stake.Encode());
            result.AddRange(Deposit.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Votes = new Ajuna.NetApi.Model.Types.Base.BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32>();
            Votes.Decode(byteArray, ref p);
            Stake = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Stake.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
