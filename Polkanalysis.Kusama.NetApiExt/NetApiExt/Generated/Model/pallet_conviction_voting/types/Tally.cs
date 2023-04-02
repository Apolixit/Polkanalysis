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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_conviction_voting.types
{
    
    
    /// <summary>
    /// >> 438 - Composite[pallet_conviction_voting.types.Tally]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class Tally : BaseType
    {
        
        /// <summary>
        /// >> ayes
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U128 _ayes;
        
        /// <summary>
        /// >> nays
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U128 _nays;
        
        /// <summary>
        /// >> support
        /// </summary>
        private Substrate.NetApi.Model.Types.Primitive.U128 _support;
        
        public Substrate.NetApi.Model.Types.Primitive.U128 Ayes
        {
            get
            {
                return this._ayes;
            }
            set
            {
                this._ayes = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U128 Nays
        {
            get
            {
                return this._nays;
            }
            set
            {
                this._nays = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Primitive.U128 Support
        {
            get
            {
                return this._support;
            }
            set
            {
                this._support = value;
            }
        }
        
        public override string TypeName()
        {
            return "Tally";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Ayes.Encode());
            result.AddRange(Nays.Encode());
            result.AddRange(Support.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Ayes = new Substrate.NetApi.Model.Types.Primitive.U128();
            Ayes.Decode(byteArray, ref p);
            Nays = new Substrate.NetApi.Model.Types.Primitive.U128();
            Nays.Decode(byteArray, ref p);
            Support = new Substrate.NetApi.Model.Types.Primitive.U128();
            Support.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
