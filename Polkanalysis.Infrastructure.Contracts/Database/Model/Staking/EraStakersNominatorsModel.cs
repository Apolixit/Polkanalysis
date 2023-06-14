using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Staking
{
    public class EraStakersNominatorsModel
    {
        public string NominatorAddress { get; set; } = string.Empty;
        public BigInteger ValueStake { get; set; }

        public EraStakersNominatorsModel() { }

        public EraStakersNominatorsModel(IndividualExposure exposure)
        {
            this.NominatorAddress = exposure.Who.ToPolkadotAddress();
            this.ValueStake = exposure.Value.Value.Value;
        }

        public IndividualExposure ToCore()
        {
            return new IndividualExposure(new Domain.Contracts.Core.SubstrateAccount(NominatorAddress),
                new BaseCom<U128>(new Substrate.NetApi.CompactInteger(ValueStake)));
        }
    }
}
