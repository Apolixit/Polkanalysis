using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Staking
{
    public class EraStakersNominatorsModel
    {
        public string NominatorAddress { get; set; } = string.Empty;
        public BigInteger ValueStake { get; set; }

        public int EraStakersId { get; set; }
        public required EraStakersModel EraStakers { get; set; }

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
            return new IndividualExposure(new Domain.Contracts.Core.SubstrateAccount(NominatorAddress),
                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(ValueStake)));
        }
    }
}
