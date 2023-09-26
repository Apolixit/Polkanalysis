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
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.polkadot_primitives.v2;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2
{
    /// <summary>
    /// >> 3949 - Composite[polkadot_primitives.v2.CandidateDescriptor]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class CandidateDescriptor : CandidateDescriptorBase
    {
        public override System.String TypeName()
        {
            return "CandidateDescriptor";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ParaId.Encode());
            result.AddRange(RelayParent.Encode());
            result.AddRange(Collator.Encode());
            result.AddRange(PersistedValidationDataHash.Encode());
            result.AddRange(PovHash.Encode());
            result.AddRange(ErasureRoot.Encode());
            result.AddRange(Signature.Encode());
            result.AddRange(ParaHead.Encode());
            result.AddRange(ValidationCodeHash.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ParaId = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_parachain.primitives.Id();
            ParaId.Decode(byteArray, ref p);
            RelayParent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.primitive_types.H256();
            RelayParent.Decode(byteArray, ref p);
            Collator = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.collator_app.Public();
            Collator.Decode(byteArray, ref p);
            PersistedValidationDataHash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.primitive_types.H256();
            PersistedValidationDataHash.Decode(byteArray, ref p);
            PovHash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.primitive_types.H256();
            PovHash.Decode(byteArray, ref p);
            ErasureRoot = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.primitive_types.H256();
            ErasureRoot.Decode(byteArray, ref p);
            Signature = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_primitives.v2.collator_app.Signature();
            Signature.Decode(byteArray, ref p);
            ParaHead = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.primitive_types.H256();
            ParaHead.Decode(byteArray, ref p);
            ValidationCodeHash = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9190.polkadot_parachain.primitives.ValidationCodeHash();
            ValidationCodeHash.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}