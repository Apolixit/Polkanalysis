﻿using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Staking;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NET.Utils;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Contracts.Database.Model.Staking
{
    public class EraStakersModel : BlockchainModel
    {
        public int EraId { get; set; }
        public string ValidatorAddress { get; set; } = string.Empty;

        public BigInteger TotalStake { get; set; }
        public BigInteger OwnStake { get; set; }

        public IEnumerable<EraStakersNominatorsModel> EraNominatorsVote { get; set; } = Enumerable.Empty<EraStakersNominatorsModel>();

        public EraStakersModel() { }

        [SetsRequiredMembers]
        public EraStakersModel((BaseTuple<U32, SubstrateAccount>, Exposure) data, string blockchainName, U32 eraId) {
            var validatorAccount = (SubstrateAccount)data.Item1.Value[1];
            var exposure = data.Item2;

            BlockchainName = blockchainName;
            EraId = (int)eraId.Value;
            ValidatorAddress = validatorAccount.ToPolkadotAddress();
            OwnStake = exposure.Own.Value.Value;
            TotalStake = exposure.Total.Value.Value;
            EraNominatorsVote = exposure.Others.Value.Select(x => new EraStakersNominatorsModel(x));
        }

        public (BaseTuple<U32, SubstrateAccount>, Exposure) ToCore()
        {
            return new(
                new BaseTuple<U32, SubstrateAccount>(new U32((uint)EraId), new SubstrateAccount(ValidatorAddress)),
                new Exposure(
                    new BaseCom<U128>(new Substrate.NetApi.CompactInteger(TotalStake)),
                    new BaseCom<U128>(new Substrate.NetApi.CompactInteger(OwnStake)),
                    new BaseVec<IndividualExposure>(EraNominatorsVote.Select(x => x.ToCore()).ToArray())
                )
            );
        }
    }

    
}
