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


namespace Polkanalysis.Bajun.NetApiExt.Generated.Model.pallet_ajuna_awesome_avatars.types
{
    
    
    /// <summary>
    /// >> 113 - Composite[pallet_ajuna_awesome_avatars.types.MintFees]
    /// </summary>
    [AjunaNodeType(TypeDefEnum.Composite)]
    public sealed class MintFees : BaseType
    {
        
        /// <summary>
        /// >> one
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _one;
        
        /// <summary>
        /// >> three
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _three;
        
        /// <summary>
        /// >> six
        /// </summary>
        private Ajuna.NetApi.Model.Types.Primitive.U128 _six;
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 One
        {
            get
            {
                return this._one;
            }
            set
            {
                this._one = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Three
        {
            get
            {
                return this._three;
            }
            set
            {
                this._three = value;
            }
        }
        
        public Ajuna.NetApi.Model.Types.Primitive.U128 Six
        {
            get
            {
                return this._six;
            }
            set
            {
                this._six = value;
            }
        }
        
        public override string TypeName()
        {
            return "MintFees";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(One.Encode());
            result.AddRange(Three.Encode());
            result.AddRange(Six.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            One = new Ajuna.NetApi.Model.Types.Primitive.U128();
            One.Decode(byteArray, ref p);
            Three = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Three.Decode(byteArray, ref p);
            Six = new Ajuna.NetApi.Model.Types.Primitive.U128();
            Six.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}