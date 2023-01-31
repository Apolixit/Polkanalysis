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


namespace Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime_common.paras_registrar
{
    
    
    /// <summary>
    /// >> 703 - Composite[polkadot_runtime_common.paras_registrar.ParaInfo]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ParaInfo : BaseType
    {
        
        /// <summary>
        /// >> manager
        /// </summary>
        private Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 _manager;
        
        /// <summary>
        /// >> deposit
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _deposit;
        
        /// <summary>
        /// >> locked
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.Bool _locked;
        
        public Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32 Manager
        {
            get
            {
                return this._manager;
            }
            set
            {
                this._manager = value;
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
        
        public Ajuna.NetApi.Model.Types.Primitive.Bool Locked
        {
            get
            {
                return this._locked;
            }
            set
            {
                this._locked = value;
            }
        }
        
        public override string TypeName()
        {
            return "ParaInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Manager.Encode());
            result.AddRange(Deposit.Encode());
            result.AddRange(Locked.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Manager = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32();
            Manager.Decode(byteArray, ref p);
            Deposit = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Deposit.Decode(byteArray, ref p);
            Locked = new Ajuna.NetApi.Model.Types.Primitive.Bool();
            Locked.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
