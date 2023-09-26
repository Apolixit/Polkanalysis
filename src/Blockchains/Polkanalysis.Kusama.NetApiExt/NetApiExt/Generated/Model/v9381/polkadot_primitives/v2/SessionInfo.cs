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
    /// >> 2545 - Composite[polkadot_primitives.v2.SessionInfo]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class SessionInfo : SessionInfoBase
    {
        public override System.String TypeName()
        {
            return "SessionInfo";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(ActiveValidatorIndices.Encode());
            result.AddRange(RandomSeed.Encode());
            result.AddRange(DisputePeriod.Encode());
            result.AddRange(Validators.Encode());
            result.AddRange(DiscoveryKeys.Encode());
            result.AddRange(AssignmentKeys.Encode());
            result.AddRange(ValidatorGroups.Encode());
            result.AddRange(NCores.Encode());
            result.AddRange(ZerothDelayTrancheWidth.Encode());
            result.AddRange(RelayVrfModuloSamples.Encode());
            result.AddRange(NDelayTranches.Encode());
            result.AddRange(NoShowSlots.Encode());
            result.AddRange(NeededApprovals.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            ActiveValidatorIndices = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.ValidatorIndex>();
            ActiveValidatorIndices.Decode(byteArray, ref p);
            RandomSeed = new Polkanalysis.Kusama.NetApiExt.Generated.Types.Base.Arr32U8();
            RandomSeed.Decode(byteArray, ref p);
            DisputePeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputePeriod.Decode(byteArray, ref p);
            Validators = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.validator_app.Public>();
            Validators.Decode(byteArray, ref p);
            DiscoveryKeys = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.sp_authority_discovery.app.Public>();
            DiscoveryKeys.Decode(byteArray, ref p);
            AssignmentKeys = new Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.assignment_app.Public>();
            AssignmentKeys.Decode(byteArray, ref p);
            ValidatorGroups = new Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9381.polkadot_primitives.v2.ValidatorIndex>>();
            ValidatorGroups.Decode(byteArray, ref p);
            NCores = new Substrate.NetApi.Model.Types.Primitive.U32();
            NCores.Decode(byteArray, ref p);
            ZerothDelayTrancheWidth = new Substrate.NetApi.Model.Types.Primitive.U32();
            ZerothDelayTrancheWidth.Decode(byteArray, ref p);
            RelayVrfModuloSamples = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayVrfModuloSamples.Decode(byteArray, ref p);
            NDelayTranches = new Substrate.NetApi.Model.Types.Primitive.U32();
            NDelayTranches.Decode(byteArray, ref p);
            NoShowSlots = new Substrate.NetApi.Model.Types.Primitive.U32();
            NoShowSlots.Decode(byteArray, ref p);
            NeededApprovals = new Substrate.NetApi.Model.Types.Primitive.U32();
            NeededApprovals.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}