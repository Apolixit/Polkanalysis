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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.kusama_runtime;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.kusama_runtime
{
    /// <summary>
    /// >> 965 - Composite[kusama_runtime.SessionKeys]
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
            Grandpa = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_consensus_grandpa.app.Public();
            Grandpa.Decode(byteArray, ref p);
            Babe = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_consensus_babe.app.Public();
            Babe.Decode(byteArray, ref p);
            ImOnline = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.pallet_im_online.sr25519.app_sr25519.Public();
            ImOnline.Decode(byteArray, ref p);
            ParaValidator = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.validator_app.Public();
            ParaValidator.Decode(byteArray, ref p);
            ParaAssignment = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.polkadot_primitives.v4.assignment_app.Public();
            ParaAssignment.Decode(byteArray, ref p);
            AuthorityDiscovery = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9420.sp_authority_discovery.app.Public();
            AuthorityDiscovery.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}