using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Staking
{
    public class EraStakersNominatorsModel
    {
        public string NominatorAddress { get; set; }
        public BigInteger ValueStake { get; set; }
        public EraStakersModel EraStakers { get; set; }

        public EraStakersNominatorsModel(string nominatorAddress, BigInteger valueStake, EraStakersModel eraStakers)
        {
            NominatorAddress = nominatorAddress;
            ValueStake = valueStake;
            EraStakers = eraStakers;
        }


        [SetsRequiredMembers]
        public EraStakersNominatorsModel(IndividualExposure exposure, EraStakersModel eraStakers)
        {
            NominatorAddress = exposure.Who.ToPolkadotAddress();
            ValueStake = exposure.Value.Value.Value;
            EraStakers = eraStakers;
        }

        public IndividualExposure ToCore()
        {
            return new IndividualExposure(new Domain.Contracts.Core.SubstrateAccount(NominatorAddress),
                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(ValueStake)));
        }

        public override bool Equals(object? obj)
        {
            return obj is EraStakersNominatorsModel model &&
                   NominatorAddress == model.NominatorAddress &&
                   ValueStake.Equals(model.ValueStake) &&
                   EraStakers.EraStakersId == model.EraStakers.EraStakersId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NominatorAddress, ValueStake, EraStakers);
        }
    }
}
