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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_balances
{
    
    
    /// <summary>
    /// >> 518 - Composite[pallet_balances.BalanceLock]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class BalanceLock : BaseType
    {
        
        /// <summary>
        /// >> id
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr8U8 _id;
        
        /// <summary>
        /// >> amount
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _amount;
        
        /// <summary>
        /// >> reasons
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_balances.EnumReasons _reasons;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr8U8 Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Amount
        {
            get
            {
                return this._amount;
            }
            set
            {
                this._amount = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_balances.EnumReasons Reasons
        {
            get
            {
                return this._reasons;
            }
            set
            {
                this._reasons = value;
            }
        }
        
        public override string TypeName()
        {
            return "BalanceLock";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Id.Encode());
            result.AddRange(Amount.Encode());
            result.AddRange(Reasons.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Id = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr8U8();
            Id.Decode(byteArray, ref p);
            Amount = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Amount.Decode(byteArray, ref p);
            Reasons = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_balances.EnumReasons();
            Reasons.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
