using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Staking;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Database.Contracts.Model.Staking
{
    public class EraStakersNominatorsModel
    {
        public string NominatorAddress { get; set; } = string.Empty;
        public BigInteger ValueStake { get; set; }

        public EraStakersModel EraStakers { get; set; }

        public EraStakersNominatorsModel() { }

        [SetsRequiredMembers]
        public EraStakersNominatorsModel(IndividualExposure exposure, EraStakersModel eraStakers)
        {
            NominatorAddress = exposure.Who.ToPolkadotAddress();
            ValueStake = exposure.Value.Value.Value;
            EraStakers = eraStakers;
        }

        public IndividualExposure ToCore()
        {
            return new IndividualExposure(new SubstrateAccount(NominatorAddress),
                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(ValueStake)));
        }

        public override bool Equals(object? obj)
        {
            return obj is EraStakersNominatorsModel model &&
                   NominatorAddress == model.NominatorAddress &&
                   ValueStake.Equals(model.ValueStake) &&
                   EraStakers.Id == model.EraStakers.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(NominatorAddress, ValueStake, EraStakers);
        }
    }
}
