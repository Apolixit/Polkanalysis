using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Random;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.ParaSessionInfo
{
    public class SessionInfo : BaseType
    {
        public BaseVec<U32> ActiveValidatorIndices { get; set; }
        public Hexa RandomSeed { get; set; }
        public U32 DisputePeriod { get; set; }
        public BaseVec<PublicSr25519> Validators { get; set; }
        public BaseVec<PublicSr25519> DiscoveryKeys { get; set; }
        public BaseVec<PublicSr25519> AssignmentKeys { get; set; }
        public BaseVec<BaseVec<U32>> ValidatorGroups { get; set; }
        public U32 NCores { get; set; }
        public U32 ZerothDelayTrancheWidth { get; set; }
        public U32 RelayVrfModuloSamples { get; set; }
        public U32 NDelayTranches { get; set; }
        public U32 NoShowSlots { get; set; }
        public U32 NeededApprovals { get; set; }

        public SessionInfo() { }

        public SessionInfo(BaseVec<U32> activeValidatorIndices, Hexa randomSeed, U32 disputePeriod, BaseVec<PublicSr25519> validators, BaseVec<PublicSr25519> discoveryKeys, BaseVec<PublicSr25519> assignmentKeys, BaseVec<BaseVec<U32>> validatorGroups, U32 nCores, U32 zerothDelayTrancheWidth, U32 relayVrfModuloSamples, U32 nDelayTranches, U32 noShowSlots, U32 neededApprovals)
        {
            Create(activeValidatorIndices, randomSeed, disputePeriod, validators, discoveryKeys, assignmentKeys, validatorGroups, nCores, zerothDelayTrancheWidth, relayVrfModuloSamples, nDelayTranches, noShowSlots, neededApprovals);
        }

        public void Create(BaseVec<U32> activeValidatorIndices, Hexa randomSeed, U32 disputePeriod, BaseVec<PublicSr25519> validators, BaseVec<PublicSr25519> discoveryKeys, BaseVec<PublicSr25519> assignmentKeys, BaseVec<BaseVec<U32>> validatorGroups, U32 nCores, U32 zerothDelayTrancheWidth, U32 relayVrfModuloSamples, U32 nDelayTranches, U32 noShowSlots, U32 neededApprovals)
        {
            ActiveValidatorIndices = activeValidatorIndices;
            RandomSeed = randomSeed;
            DisputePeriod = disputePeriod;
            Validators = validators;
            DiscoveryKeys = discoveryKeys;
            AssignmentKeys = assignmentKeys;
            ValidatorGroups = validatorGroups;
            NCores = nCores;
            ZerothDelayTrancheWidth = zerothDelayTrancheWidth;
            RelayVrfModuloSamples = relayVrfModuloSamples;
            NDelayTranches = nDelayTranches;
            NoShowSlots = noShowSlots;
            NeededApprovals = neededApprovals;

            Bytes = Encode();
            TypeSize = ActiveValidatorIndices.TypeSize +
                RandomSeed.TypeSize +
                DisputePeriod.TypeSize +
                Validators.TypeSize +
                DiscoveryKeys.TypeSize +
                AssignmentKeys.TypeSize +
                ValidatorGroups.TypeSize +
                NCores.TypeSize +
                ZerothDelayTrancheWidth.TypeSize +
                RelayVrfModuloSamples.TypeSize +
                NDelayTranches.TypeSize +
                NoShowSlots.TypeSize +
                NeededApprovals.TypeSize;
        }

        public override byte[] Encode()
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
            ActiveValidatorIndices = new BaseVec<U32>();
            ActiveValidatorIndices.Decode(byteArray, ref p);
            RandomSeed = new Hexa();
            RandomSeed.Decode(byteArray, ref p);
            DisputePeriod = new U32();
            DisputePeriod.Decode(byteArray, ref p);
            Validators = new BaseVec<PublicSr25519>();
            Validators.Decode(byteArray, ref p);
            DiscoveryKeys = new BaseVec<PublicSr25519>();
            DiscoveryKeys.Decode(byteArray, ref p);
            AssignmentKeys = new BaseVec<PublicSr25519>();
            AssignmentKeys.Decode(byteArray, ref p);
            ValidatorGroups = new BaseVec<BaseVec<U32>>();
            ValidatorGroups.Decode(byteArray, ref p);
            NCores = new U32();
            NCores.Decode(byteArray, ref p);
            ZerothDelayTrancheWidth = new U32();
            ZerothDelayTrancheWidth.Decode(byteArray, ref p);
            RelayVrfModuloSamples = new U32();
            RelayVrfModuloSamples.Decode(byteArray, ref p);
            NDelayTranches = new U32();
            NDelayTranches.Decode(byteArray, ref p);
            NoShowSlots = new U32();
            NoShowSlots.Decode(byteArray, ref p);
            NeededApprovals = new U32();
            NeededApprovals.Decode(byteArray, ref p);
            TypeSize = p - start;
        }
    }
}
