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
using System.Threading.Tasks;
using Substrate.NetApi.Model.Meta;
using System.Threading;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Extrinsics;

namespace Polkanalysis.Polkadot.NetApiExt.Generated.Storage.v9180
{
    public sealed class CrowdloanStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> FundsParams
        ///  Info on all of the funds.
        /// </summary>
        public static string FundsParams(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_parachain.primitives.Id key)
        {
            return RequestGenerator.GetStorage("Crowdloan", "Funds", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> FundsDefault
        /// Default value as hex string
        /// </summary>
        public static string FundsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Funds
        ///  Info on all of the funds.
        /// </summary>
        public async Task<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_runtime_common.crowdloan.FundInfo> Funds(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_parachain.primitives.Id key, CancellationToken token)
        {
            string parameters = FundsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_runtime_common.crowdloan.FundInfo>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NewRaiseParams
        ///  The funds that have had additional contributions during the last block. This is used
        ///  in order to determine which funds should submit new or updated bids.
        /// </summary>
        public static string NewRaiseParams()
        {
            return RequestGenerator.GetStorage("Crowdloan", "NewRaise", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NewRaiseDefault
        /// Default value as hex string
        /// </summary>
        public static string NewRaiseDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> NewRaise
        ///  The funds that have had additional contributions during the last block. This is used
        ///  in order to determine which funds should submit new or updated bids.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_parachain.primitives.Id>> NewRaise(CancellationToken token)
        {
            string parameters = NewRaiseParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.polkadot_parachain.primitives.Id>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> EndingsCountParams
        ///  The number of auctions that have entered into their ending period so far.
        /// </summary>
        public static string EndingsCountParams()
        {
            return RequestGenerator.GetStorage("Crowdloan", "EndingsCount", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> EndingsCountDefault
        /// Default value as hex string
        /// </summary>
        public static string EndingsCountDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> EndingsCount
        ///  The number of auctions that have entered into their ending period so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> EndingsCount(CancellationToken token)
        {
            string parameters = EndingsCountParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> NextFundIndexParams
        ///  Tracker for the next available fund index
        /// </summary>
        public static string NextFundIndexParams()
        {
            return RequestGenerator.GetStorage("Crowdloan", "NextFundIndex", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> NextFundIndexDefault
        /// Default value as hex string
        /// </summary>
        public static string NextFundIndexDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> NextFundIndex
        ///  Tracker for the next available fund index
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> NextFundIndex(CancellationToken token)
        {
            string parameters = NextFundIndexParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        public CrowdloanStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class CrowdloanConstants
    {
        /// <summary>
        /// >> PalletId
        ///  `PalletId` for the crowdloan pallet. An appropriate value could be `PalletId(*b"py/cfund")`
        /// </summary>
        public Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.frame_support.PalletId PalletId()
        {
            var result = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9180.frame_support.PalletId();
            result.Create("0x70792F6366756E64");
            return result;
        }

        /// <summary>
        /// >> MinContribution
        ///  The minimum amount that may be contributed into a crowdloan. Should almost certainly be at
        ///  least `ExistentialDeposit`.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U128 MinContribution()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U128();
            result.Create("0x00743BA40B0000000000000000000000");
            return result;
        }

        /// <summary>
        /// >> RemoveKeysLimit
        ///  Max number of storage keys to remove per extrinsic call.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 RemoveKeysLimit()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0xE8030000");
            return result;
        }
    }

    public enum CrowdloanErrors
    {
        /// <summary>
        /// >> FirstPeriodInPast
        /// The current lease period is more than the first lease period.
        /// </summary>
        FirstPeriodInPast,
        /// <summary>
        /// >> FirstPeriodTooFarInFuture
        /// The first lease period needs to at least be less than 3 `max_value`.
        /// </summary>
        FirstPeriodTooFarInFuture,
        /// <summary>
        /// >> LastPeriodBeforeFirstPeriod
        /// Last lease period must be greater than first lease period.
        /// </summary>
        LastPeriodBeforeFirstPeriod,
        /// <summary>
        /// >> LastPeriodTooFarInFuture
        /// The last lease period cannot be more than 3 periods after the first period.
        /// </summary>
        LastPeriodTooFarInFuture,
        /// <summary>
        /// >> CannotEndInPast
        /// The campaign ends before the current block number. The end must be in the future.
        /// </summary>
        CannotEndInPast,
        /// <summary>
        /// >> EndTooFarInFuture
        /// The end date for this crowdloan is not sensible.
        /// </summary>
        EndTooFarInFuture,
        /// <summary>
        /// >> Overflow
        /// There was an overflow.
        /// </summary>
        Overflow,
        /// <summary>
        /// >> ContributionTooSmall
        /// The contribution was below the minimum, `MinContribution`.
        /// </summary>
        ContributionTooSmall,
        /// <summary>
        /// >> InvalidParaId
        /// Invalid fund index.
        /// </summary>
        InvalidParaId,
        /// <summary>
        /// >> CapExceeded
        /// Contributions exceed maximum amount.
        /// </summary>
        CapExceeded,
        /// <summary>
        /// >> ContributionPeriodOver
        /// The contribution period has already ended.
        /// </summary>
        ContributionPeriodOver,
        /// <summary>
        /// >> InvalidOrigin
        /// The origin of this call is invalid.
        /// </summary>
        InvalidOrigin,
        /// <summary>
        /// >> NotParachain
        /// This crowdloan does not correspond to a parachain.
        /// </summary>
        NotParachain,
        /// <summary>
        /// >> LeaseActive
        /// This parachain lease is still active and retirement cannot yet begin.
        /// </summary>
        LeaseActive,
        /// <summary>
        /// >> BidOrLeaseActive
        /// This parachain's bid or lease is still active and withdraw cannot yet begin.
        /// </summary>
        BidOrLeaseActive,
        /// <summary>
        /// >> FundNotEnded
        /// The crowdloan has not yet ended.
        /// </summary>
        FundNotEnded,
        /// <summary>
        /// >> NoContributions
        /// There are no contributions stored in this crowdloan.
        /// </summary>
        NoContributions,
        /// <summary>
        /// >> NotReadyToDissolve
        /// The crowdloan is not ready to dissolve. Potentially still has a slot or in retirement period.
        /// </summary>
        NotReadyToDissolve,
        /// <summary>
        /// >> InvalidSignature
        /// Invalid signature.
        /// </summary>
        InvalidSignature,
        /// <summary>
        /// >> MemoTooLarge
        /// The provided memo is too large.
        /// </summary>
        MemoTooLarge,
        /// <summary>
        /// >> AlreadyInNewRaise
        /// The fund is already in `NewRaise`
        /// </summary>
        AlreadyInNewRaise,
        /// <summary>
        /// >> VrfDelayInProgress
        /// No contributions allowed during the VRF delay
        /// </summary>
        VrfDelayInProgress,
        /// <summary>
        /// >> NoLeasePeriod
        /// A lease period has not started yet, due to an offset in the starting block.
        /// </summary>
        NoLeasePeriod
    }
}