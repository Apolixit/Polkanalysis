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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types
{
    
    
    /// <summary>
    /// >> 115 - Composite[pallet_ajuna_awesome_avatars.types.TradeConfig]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class TradeConfig : BaseType
    {
        
        /// <summary>
        /// >> open
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.Bool _open;
        
        public Substrate.NetApi.Model.Types.Primitive.Bool Open
        {
            get
            {
                return this._open;
            }
            set
            {
                this._open = value;
            }
        }
        
        public override string TypeName()
        {
            return "TradeConfig";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Open.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Open = new Substrate.NetApi.Model.Types.Primitive.Bool();
            Open.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
