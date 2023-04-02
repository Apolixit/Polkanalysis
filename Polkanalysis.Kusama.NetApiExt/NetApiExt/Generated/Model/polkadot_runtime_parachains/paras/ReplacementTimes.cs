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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.polkadot_runtime_parachains.paras
{
    
    
    /// <summary>
    /// >> 792 - Composite[polkadot_runtime_parachains.paras.ReplacementTimes]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class ReplacementTimes : BaseType
    {
        
        /// <summary>
        /// >> expected_at
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _expectedAt;
        
        /// <summary>
        /// >> activated_at
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U32 _activatedAt;
        
        public Substrate.NetApi.Model.Types.Primitive.U32 ExpectedAt
        {
            get
            {
                return this._expectedAt;
            }
            set
            {
                this._expectedAt = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U32 ActivatedAt
        {
            get
            {
                return this._activatedAt;
            }
            set
            {
                this._activatedAt = value;
            }
        }
        
        public override string TypeName()
        {
            return "ReplacementTimes";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ExpectedAt.Encode());
            result.AddRange(ActivatedAt.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ExpectedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            ExpectedAt.Decode(byteArray, ref p);
            ActivatedAt = new Substrate.NetApi.Model.Types.Primitive.U32();
            ActivatedAt.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
