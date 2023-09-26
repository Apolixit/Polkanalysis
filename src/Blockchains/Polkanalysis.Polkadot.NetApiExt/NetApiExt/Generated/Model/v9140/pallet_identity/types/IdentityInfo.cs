//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Substrate.NetApi.Model.Types.Base;
using System.Collections.Generic;
using Substrate.NetApi.Model.Types.Metadata.V14;
using Substrate.NetApi.Attributes;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_identity.types;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types
{
    /// <summary>
    /// >> 1417 - Composite[pallet_identity.types.IdentityInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class IdentityInfo : IdentityInfoBase
    {
        public override System.String TypeName()
        {
            return "IdentityInfo";
        }

        public override System.Byte[] Encode()
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
            Additional = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData, Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData>>();
            Additional.Decode(byteArray, ref p);
            Display = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Display.Decode(byteArray, ref p);
            Legal = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Legal.Decode(byteArray, ref p);
            Web = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Web.Decode(byteArray, ref p);
            Riot = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Riot.Decode(byteArray, ref p);
            Email = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Email.Decode(byteArray, ref p);
            PgpFingerprint = new Substrate.NetApi.Model.Types.Base.BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base.Arr20U8>();
            PgpFingerprint.Decode(byteArray, ref p);
            Image = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Image.Decode(byteArray, ref p);
            Twitter = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.pallet_identity.types.EnumData();
            Twitter.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}