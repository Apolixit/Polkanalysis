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
using Polkanalysis.Kusama.NetApiExt.Generated.Model.vbase.polkadot_runtime_parachains.configuration;

namespace Polkanalysis.Kusama.NetApiExt.Generated.Model.v9122.polkadot_runtime_parachains.configuration
{
    /// <summary>
    /// >> 19586 - Composite[polkadot_runtime_parachains.configuration.HostConfiguration]
    /// </summary>
    [SubstrateNodeType(TypeDefEnum.Composite)]
    public sealed class HostConfiguration : HostConfigurationBase
    {
        public override System.String TypeName()
        {
            return "HostConfiguration";
        }

        public override System.Byte[] Encode()
        {
            var result = new List<byte>();
            result.AddRange(MaxCodeSize.Encode());
            result.AddRange(MaxHeadDataSize.Encode());
            result.AddRange(MaxUpwardQueueCount.Encode());
            result.AddRange(MaxUpwardQueueSize.Encode());
            result.AddRange(MaxUpwardMessageSize.Encode());
            result.AddRange(MaxUpwardMessageNumPerCandidate.Encode());
            result.AddRange(HrmpMaxMessageNumPerCandidate.Encode());
            result.AddRange(ValidationUpgradeFrequency.Encode());
            result.AddRange(ValidationUpgradeDelay.Encode());
            result.AddRange(MaxPovSize.Encode());
            result.AddRange(MaxDownwardMessageSize.Encode());
            result.AddRange(UmpServiceTotalWeight2.Encode());
            result.AddRange(HrmpMaxParachainOutboundChannels.Encode());
            result.AddRange(HrmpMaxParathreadOutboundChannels.Encode());
            result.AddRange(HrmpSenderDeposit.Encode());
            result.AddRange(HrmpRecipientDeposit.Encode());
            result.AddRange(HrmpChannelMaxCapacity.Encode());
            result.AddRange(HrmpChannelMaxTotalSize.Encode());
            result.AddRange(HrmpMaxParachainInboundChannels.Encode());
            result.AddRange(HrmpMaxParathreadInboundChannels.Encode());
            result.AddRange(HrmpChannelMaxMessageSize.Encode());
            result.AddRange(CodeRetentionPeriod.Encode());
            result.AddRange(ParathreadCores.Encode());
            result.AddRange(ParathreadRetries.Encode());
            result.AddRange(GroupRotationFrequency.Encode());
            result.AddRange(ChainAvailabilityPeriod.Encode());
            result.AddRange(ThreadAvailabilityPeriod.Encode());
            result.AddRange(SchedulingLookahead.Encode());
            result.AddRange(MaxValidatorsPerCore.Encode());
            result.AddRange(MaxValidators.Encode());
            result.AddRange(DisputePeriod.Encode());
            result.AddRange(DisputePostConclusionAcceptancePeriod.Encode());
            result.AddRange(DisputeMaxSpamSlots.Encode());
            result.AddRange(DisputeConclusionByTimeOutPeriod.Encode());
            result.AddRange(NoShowSlots.Encode());
            result.AddRange(NDelayTranches.Encode());
            result.AddRange(ZerothDelayTrancheWidth.Encode());
            result.AddRange(NeededApprovals.Encode());
            result.AddRange(RelayVrfModuloSamples.Encode());
            result.AddRange(UmpMaxIndividualWeight2.Encode());
            return result.ToArray();
        }

        public override void Decode(byte[] byteArray, ref int p)
        {
            var start = p;
            MaxCodeSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxCodeSize.Decode(byteArray, ref p);
            MaxHeadDataSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxHeadDataSize.Decode(byteArray, ref p);
            MaxUpwardQueueCount = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardQueueCount.Decode(byteArray, ref p);
            MaxUpwardQueueSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardQueueSize.Decode(byteArray, ref p);
            MaxUpwardMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardMessageSize.Decode(byteArray, ref p);
            MaxUpwardMessageNumPerCandidate = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxUpwardMessageNumPerCandidate.Decode(byteArray, ref p);
            HrmpMaxMessageNumPerCandidate = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxMessageNumPerCandidate.Decode(byteArray, ref p);
            ValidationUpgradeFrequency = new Substrate.NetApi.Model.Types.Primitive.U32();
            ValidationUpgradeFrequency.Decode(byteArray, ref p);
            ValidationUpgradeDelay = new Substrate.NetApi.Model.Types.Primitive.U32();
            ValidationUpgradeDelay.Decode(byteArray, ref p);
            MaxPovSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxPovSize.Decode(byteArray, ref p);
            MaxDownwardMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            MaxDownwardMessageSize.Decode(byteArray, ref p);
            UmpServiceTotalWeight2 = new Substrate.NetApi.Model.Types.Primitive.U64();
            UmpServiceTotalWeight2.Decode(byteArray, ref p);
            HrmpMaxParachainOutboundChannels = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxParachainOutboundChannels.Decode(byteArray, ref p);
            HrmpMaxParathreadOutboundChannels = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxParathreadOutboundChannels.Decode(byteArray, ref p);
            HrmpSenderDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            HrmpSenderDeposit.Decode(byteArray, ref p);
            HrmpRecipientDeposit = new Substrate.NetApi.Model.Types.Primitive.U128();
            HrmpRecipientDeposit.Decode(byteArray, ref p);
            HrmpChannelMaxCapacity = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpChannelMaxCapacity.Decode(byteArray, ref p);
            HrmpChannelMaxTotalSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpChannelMaxTotalSize.Decode(byteArray, ref p);
            HrmpMaxParachainInboundChannels = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxParachainInboundChannels.Decode(byteArray, ref p);
            HrmpMaxParathreadInboundChannels = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpMaxParathreadInboundChannels.Decode(byteArray, ref p);
            HrmpChannelMaxMessageSize = new Substrate.NetApi.Model.Types.Primitive.U32();
            HrmpChannelMaxMessageSize.Decode(byteArray, ref p);
            CodeRetentionPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            CodeRetentionPeriod.Decode(byteArray, ref p);
            ParathreadCores = new Substrate.NetApi.Model.Types.Primitive.U32();
            ParathreadCores.Decode(byteArray, ref p);
            ParathreadRetries = new Substrate.NetApi.Model.Types.Primitive.U32();
            ParathreadRetries.Decode(byteArray, ref p);
            GroupRotationFrequency = new Substrate.NetApi.Model.Types.Primitive.U32();
            GroupRotationFrequency.Decode(byteArray, ref p);
            ChainAvailabilityPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            ChainAvailabilityPeriod.Decode(byteArray, ref p);
            ThreadAvailabilityPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            ThreadAvailabilityPeriod.Decode(byteArray, ref p);
            SchedulingLookahead = new Substrate.NetApi.Model.Types.Primitive.U32();
            SchedulingLookahead.Decode(byteArray, ref p);
            MaxValidatorsPerCore = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            MaxValidatorsPerCore.Decode(byteArray, ref p);
            MaxValidators = new Substrate.NetApi.Model.Types.Base.BaseOpt<Substrate.NetApi.Model.Types.Primitive.U32>();
            MaxValidators.Decode(byteArray, ref p);
            DisputePeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputePeriod.Decode(byteArray, ref p);
            DisputePostConclusionAcceptancePeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputePostConclusionAcceptancePeriod.Decode(byteArray, ref p);
            DisputeMaxSpamSlots = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputeMaxSpamSlots.Decode(byteArray, ref p);
            DisputeConclusionByTimeOutPeriod = new Substrate.NetApi.Model.Types.Primitive.U32();
            DisputeConclusionByTimeOutPeriod.Decode(byteArray, ref p);
            NoShowSlots = new Substrate.NetApi.Model.Types.Primitive.U32();
            NoShowSlots.Decode(byteArray, ref p);
            NDelayTranches = new Substrate.NetApi.Model.Types.Primitive.U32();
            NDelayTranches.Decode(byteArray, ref p);
            ZerothDelayTrancheWidth = new Substrate.NetApi.Model.Types.Primitive.U32();
            ZerothDelayTrancheWidth.Decode(byteArray, ref p);
            NeededApprovals = new Substrate.NetApi.Model.Types.Primitive.U32();
            NeededApprovals.Decode(byteArray, ref p);
            RelayVrfModuloSamples = new Substrate.NetApi.Model.Types.Primitive.U32();
            RelayVrfModuloSamples.Decode(byteArray, ref p);
            UmpMaxIndividualWeight2 = new Substrate.NetApi.Model.Types.Primitive.U64();
            UmpMaxIndividualWeight2.Decode(byteArray, ref p);
            var bytesLength = p - start;
            TypeSize = bytesLength;
            Bytes = new byte[bytesLength];
            System.Array.Copy(byteArray, start, Bytes, 0, bytesLength);
        }
    }
}