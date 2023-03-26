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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_staking
{
    
    
    /// <summary>
    /// >> 538 - Composite[pallet_staking.ActiveEraInfo]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class ActiveEraInfo : BaseType
    {
        
        /// <summary>
        /// >> index
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U32 _index;
        
        /// <summary>
        /// >> start
        /// </summary>
        private Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U64> _start;
        
        public Ajuna.NetApi.Model.Types.Primitive.U32 Index
        {
            get
            {
                return this._index;
            }
            set
            {
                this._index = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U64> Start
        {
            get
            {
                return this._start;
            }
            set
            {
                this._start = value;
            }
        }
        
        public override string TypeName()
        {
            return "ActiveEraInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Index.Encode());
            result.AddRange(Start.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Index = new Ajuna.NetApi.Model.Types.Primitive.U32();
            Index.Decode(byteArray, ref p);
            Start = new Ajuna.NetApi.Model.Types.Base.BaseOpt<Ajuna.NetApi.Model.Types.Primitive.U64>();
            Start.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
