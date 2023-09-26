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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_runtime;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.polkadot_runtime
{
    /// <summary>
    /// >> 2024 - Composite[polkadot_runtime.SessionKeys]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SessionKeys : SessionKeysBase
    {
        public override System.String TypeName()
        {
            return "SessionKeys";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Grandpa.Encode());
            result.AddRange(Babe.Encode());
            result.AddRange(ImOnline.Encode());
            result.AddRange(ParaValidator.Encode());
            result.AddRange(ParaAssignment.Encode());
            result.AddRange(AuthorityDiscovery.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Grandpa = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_finality_grandpa.app.Public();
            Grandpa.Decode(byteArray, ref p);
            Babe = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_consensus_babe.app.Public();
            Babe.Decode(byteArray, ref p);
            ImOnline = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.pallet_im_online.sr25519.app_sr25519.Public();
            ImOnline.Decode(byteArray, ref p);
            ParaValidator = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.polkadot_primitives.v0.validator_app.Public();
            ParaValidator.Decode(byteArray, ref p);
            ParaAssignment = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.polkadot_primitives.v1.assignment_app.Public();
            ParaAssignment.Decode(byteArray, ref p);
            AuthorityDiscovery = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9151.sp_authority_discovery.app.Public();
            AuthorityDiscovery.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}