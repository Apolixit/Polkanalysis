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
    /// >> 2087 - Composite[polkadot_primitives.v2.DisputeStatementSet]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class DisputeStatementSet : DisputeStatementSetBase
    {
        public override System.String TypeName()
        {
            return "DisputeStatementSet";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(CandidateHash.Encode());
            result.AddRange(Session.Encode());
            result.AddRange(Statements.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            CandidateHash = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_core_primitives.CandidateHash();
            CandidateHash.Decode(byteArray, ref p);
            Session = new Substrate.NetApi.Model.Types.Primitive.U32();
            Session.Decode(byteArray, ref p);
            Statements = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseTuple<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.EnumDisputeStatement, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.ValidatorIndex, Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.validator_app.Signature>>();
            Statements.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}