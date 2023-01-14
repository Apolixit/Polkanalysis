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


namespace Substats.Kusama.NetApiExt.Generated.Model.pallet_child_bounties
{
    
    
    /// <summary>
    /// >> 704 - Composite[pallet_child_bounties.ChildBounty]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ChildBounty : BaseType
    {
        
        /// <summary>
        /// >> parent_bounty
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _parentBounty;
        
        /// <summary>
        /// >> value
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _value;
        
        /// <summary>
        /// >> fee
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _fee;
        
        /// <summary>
        /// >> curator_deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _curatorDeposit;
        
        /// <summary>
        /// >> status
        /// </summary>
        private Substats.Kusama.NetApiExt.Generated.Model.pallet_child_bounties.EnumChildBountyStatus _status;
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 ParentBounty
        {
            get
            {
                return this._parentBounty;
            }
            set
            {
                this._parentBounty = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Value
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
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Fee
        {
            get
            {
                return this._fee;
            }
            set
            {
                this._fee = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 CuratorDeposit
        {
            get
            {
                return this._curatorDeposit;
            }
            set
            {
                this._curatorDeposit = value;
            }
        }
        
        public Substats.Kusama.NetApiExt.Generated.Model.pallet_child_bounties.EnumChildBountyStatus Status
        {
            get
            {
                return this._status;
            }
            set
            {
                this._status = value;
            }
        }
        
        public override string TypeName()
        {
            return "ChildBounty";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParentBounty.Encode());
            result.AddRange(Value.Encode());
            result.AddRange(Fee.Encode());
            result.AddRange(CuratorDeposit.Encode());
            result.AddRange(Status.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParentBounty = new Ajuna.NetApi.Model.Types.Primitive.U32();
            ParentBounty.Decode(byteArray, ref p);
            Value = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Value.Decode(byteArray, ref p);
            Fee = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Fee.Decode(byteArray, ref p);
            CuratorDeposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            CuratorDeposit.Decode(byteArray, ref p);
            Status = new Substats.Kusama.NetApiExt.Generated.Model.pallet_child_bounties.EnumChildBountyStatus();
            Status.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
