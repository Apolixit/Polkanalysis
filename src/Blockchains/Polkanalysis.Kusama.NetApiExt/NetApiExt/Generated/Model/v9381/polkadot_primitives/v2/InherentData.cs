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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2
{
    /// <summary>
    /// >> 2063 - Composite[polkadot_primitives.v2.InherentData]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class InherentData : InherentDataBase
    {
        public override System.String TypeName()
        {
            return "InherentData";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(Bitfields.Encode());
            result.AddRange(BackedCandidates.Encode());
            result.AddRange(Disputes.Encode());
            result.AddRange(ParentHeader.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            Bitfields = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.signed.UncheckedSigned>();
            Bitfields.Decode(byteArray, ref p);
            BackedCandidates = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.BackedCandidate>();
            BackedCandidates.Decode(byteArray, ref p);
            Disputes = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.DisputeStatementSet>();
            Disputes.Decode(byteArray, ref p);
            ParentHeader = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_runtime.generic.header.Header();
            ParentHeader.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}