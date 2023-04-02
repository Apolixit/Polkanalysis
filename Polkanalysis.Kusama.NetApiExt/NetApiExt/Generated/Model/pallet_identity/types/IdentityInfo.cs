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


namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types
{
    
    
    /// <summary>
    /// >> 180 - Composite[pallet_identity.types.IdentityInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class IdentityInfo : BaseType
    {
        
        /// <summary>
        /// >> additional
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT1 _additional;
        
        /// <summary>
        /// >> display
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _display;
        
        /// <summary>
        /// >> legal
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _legal;
        
        /// <summary>
        /// >> web
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _web;
        
        /// <summary>
        /// >> riot
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _riot;
        
        /// <summary>
        /// >> email
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _email;
        
        /// <summary>
        /// >> pgp_fingerprint
        /// </summary>
        private Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr20U8> _pgpFingerprint;
        
        /// <summary>
        /// >> image
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _image;
        
        /// <summary>
        /// >> twitter
        /// </summary>
        private Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData _twitter;
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT1 Additional
        {
            get
            {
                return this._additional;
            }
            set
            {
                this._additional = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Display
        {
            get
            {
                return this._display;
            }
            set
            {
                this._display = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Legal
        {
            get
            {
                return this._legal;
            }
            set
            {
                this._legal = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Web
        {
            get
            {
                return this._web;
            }
            set
            {
                this._web = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Riot
        {
            get
            {
                return this._riot;
            }
            set
            {
                this._riot = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Email
        {
            get
            {
                return this._email;
            }
            set
            {
                this._email = value;
            }
        }
        
        public Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr20U8> PgpFingerprint
        {
            get
            {
                return this._pgpFingerprint;
            }
            set
            {
                this._pgpFingerprint = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
            }
        }
        
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData Twitter
        {
            get
            {
                return this._twitter;
            }
            set
            {
                this._twitter = value;
            }
        }
        
        public override string TypeName()
        {
            return "IdentityInfo";
        }
        
        public override byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Additional.Encode());
            result.AddRange(Display.Encode());
            result.AddRange(Legal.Encode());
            result.AddRange(Web.Encode());
            result.AddRange(Riot.Encode());
            result.AddRange(Email.Encode());
            result.AddRange(PgpFingerprint.Encode());
            result.AddRange(Image.Encode());
            result.AddRange(Twitter.Encode());
            return result.ToArray();
        }
        
        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Additional = new Polkanalysis.Kusama.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT1();
            Additional.Decode(byteArray, ref p);
            Display = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Display.Decode(byteArray, ref p);
            Legal = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Legal.Decode(byteArray, ref p);
            Web = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Web.Decode(byteArray, ref p);
            Riot = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Riot.Decode(byteArray, ref p);
            Email = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Email.Decode(byteArray, ref p);
            PgpFingerprint = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr20U8>();
            PgpFingerprint.Decode(byteArray, ref p);
            Image = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Image.Decode(byteArray, ref p);
            Twitter = new Polkanalysis.Kusama.NetApiExt.Generated.Model.pallet_identity.types.EnumData();
            Twitter.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
