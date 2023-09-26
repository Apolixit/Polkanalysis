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

namespace Polkanalysis.Kusama.NetApiExt.Generated.Storage.v9260
{
    public sealed class NominationPoolsStorage
    {
        /// <summary>
        /// Substrate client for the storage calls.
        /// </summary>
        private SubstrateClientExt _client;
        public string blockHash { get; set; } = null;

        /// <summary>
        /// >> MinJoinBondParams
        ///  Minimum amount to bond to join a pool.
        /// </summary>
        public static string MinJoinBondParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "MinJoinBond", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MinJoinBondDefault
        /// Default value as hex string
        /// </summary>
        public static string MinJoinBondDefault()
        {
            return "0x00000000000000000000000000000000";
        }

        /// <summary>
        /// >> MinJoinBond
        ///  Minimum amount to bond to join a pool.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> MinJoinBond(CancellationToken token)
        {
            string parameters = MinJoinBondParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MinCreateBondParams
        ///  Minimum bond required to create a pool.
        /// 
        ///  This is the amount that the depositor must put as their initial stake in the pool, as an
        ///  indication of "skin in the game".
        /// 
        ///  This is the value that will always exist in the staking ledger of the pool bonded account
        ///  while all other accounts leave.
        /// </summary>
        public static string MinCreateBondParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "MinCreateBond", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MinCreateBondDefault
        /// Default value as hex string
        /// </summary>
        public static string MinCreateBondDefault()
        {
            return "0x00000000000000000000000000000000";
        }

        /// <summary>
        /// >> MinCreateBond
        ///  Minimum bond required to create a pool.
        /// 
        ///  This is the amount that the depositor must put as their initial stake in the pool, as an
        ///  indication of "skin in the game".
        /// 
        ///  This is the value that will always exist in the staking ledger of the pool bonded account
        ///  while all other accounts leave.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U128> MinCreateBond(CancellationToken token)
        {
            string parameters = MinCreateBondParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U128>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MaxPoolsParams
        ///  Maximum number of nomination pools that can exist. If `None`, then an unbounded number of
        ///  pools can exist.
        /// </summary>
        public static string MaxPoolsParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "MaxPools", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MaxPoolsDefault
        /// Default value as hex string
        /// </summary>
        public static string MaxPoolsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> MaxPools
        ///  Maximum number of nomination pools that can exist. If `None`, then an unbounded number of
        ///  pools can exist.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> MaxPools(CancellationToken token)
        {
            string parameters = MaxPoolsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MaxPoolMembersParams
        ///  Maximum number of members that can exist in the system. If `None`, then the count
        ///  members are not bound on a system wide basis.
        /// </summary>
        public static string MaxPoolMembersParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "MaxPoolMembers", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MaxPoolMembersDefault
        /// Default value as hex string
        /// </summary>
        public static string MaxPoolMembersDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> MaxPoolMembers
        ///  Maximum number of members that can exist in the system. If `None`, then the count
        ///  members are not bound on a system wide basis.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> MaxPoolMembers(CancellationToken token)
        {
            string parameters = MaxPoolMembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MaxPoolMembersPerPoolParams
        ///  Maximum number of members that may belong to pool. If `None`, then the count of
        ///  members is not bound on a per pool basis.
        /// </summary>
        public static string MaxPoolMembersPerPoolParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "MaxPoolMembersPerPool", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> MaxPoolMembersPerPoolDefault
        /// Default value as hex string
        /// </summary>
        public static string MaxPoolMembersPerPoolDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> MaxPoolMembersPerPool
        ///  Maximum number of members that may belong to pool. If `None`, then the count of
        ///  members is not bound on a per pool basis.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> MaxPoolMembersPerPool(CancellationToken token)
        {
            string parameters = MaxPoolMembersPerPoolParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> PoolMembersParams
        ///  Active members.
        /// </summary>
        public static string PoolMembersParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("NominationPools", "PoolMembers", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> PoolMembersDefault
        /// Default value as hex string
        /// </summary>
        public static string PoolMembersDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> PoolMembers
        ///  Active members.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.PoolMember> PoolMembers(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = PoolMembersParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.PoolMember>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForPoolMembersParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForPoolMembersParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "CounterForPoolMembers", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForPoolMembersDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForPoolMembersDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForPoolMembers
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForPoolMembers(CancellationToken token)
        {
            string parameters = CounterForPoolMembersParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> BondedPoolsParams
        ///  Storage for bonded pools.
        /// </summary>
        public static string BondedPoolsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("NominationPools", "BondedPools", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> BondedPoolsDefault
        /// Default value as hex string
        /// </summary>
        public static string BondedPoolsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> BondedPools
        ///  Storage for bonded pools.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.BondedPoolInner> BondedPools(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = BondedPoolsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.BondedPoolInner>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForBondedPoolsParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForBondedPoolsParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "CounterForBondedPools", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForBondedPoolsDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForBondedPoolsDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForBondedPools
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForBondedPools(CancellationToken token)
        {
            string parameters = CounterForBondedPoolsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> RewardPoolsParams
        ///  Reward pools. This is where there rewards for each pool accumulate. When a members payout
        ///  is claimed, the balance comes out fo the reward pool. Keyed by the bonded pools account.
        /// </summary>
        public static string RewardPoolsParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("NominationPools", "RewardPools", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> RewardPoolsDefault
        /// Default value as hex string
        /// </summary>
        public static string RewardPoolsDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> RewardPools
        ///  Reward pools. This is where there rewards for each pool accumulate. When a members payout
        ///  is claimed, the balance comes out fo the reward pool. Keyed by the bonded pools account.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.RewardPool> RewardPools(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = RewardPoolsParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.RewardPool>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForRewardPoolsParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForRewardPoolsParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "CounterForRewardPools", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForRewardPoolsDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForRewardPoolsDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForRewardPools
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForRewardPools(CancellationToken token)
        {
            string parameters = CounterForRewardPoolsParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> SubPoolsStorageParams
        ///  Groups of unbonding pools. Each group of unbonding pools belongs to a bonded pool,
        ///  hence the name sub-pools. Keyed by the bonded pools account.
        /// </summary>
        public static string SubPoolsStorageParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("NominationPools", "SubPoolsStorage", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> SubPoolsStorageDefault
        /// Default value as hex string
        /// </summary>
        public static string SubPoolsStorageDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> SubPoolsStorage
        ///  Groups of unbonding pools. Each group of unbonding pools belongs to a bonded pool,
        ///  hence the name sub-pools. Keyed by the bonded pools account.
        /// </summary>
        public async Task<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.SubPools> SubPoolsStorage(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = SubPoolsStorageParams(key);
            var result = await _client.GetStorageAsync<Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.pallet_nomination_pools.SubPools>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForSubPoolsStorageParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForSubPoolsStorageParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "CounterForSubPoolsStorage", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForSubPoolsStorageDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForSubPoolsStorageDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForSubPoolsStorage
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForSubPoolsStorage(CancellationToken token)
        {
            string parameters = CounterForSubPoolsStorageParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> MetadataParams
        ///  Metadata for the pool.
        /// </summary>
        public static string MetadataParams(Substrate.NetApi.Model.Types.Primitive.U32 key)
        {
            return RequestGenerator.GetStorage("NominationPools", "Metadata", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> MetadataDefault
        /// Default value as hex string
        /// </summary>
        public static string MetadataDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> Metadata
        ///  Metadata for the pool.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>> Metadata(Substrate.NetApi.Model.Types.Primitive.U32 key, CancellationToken token)
        {
            string parameters = MetadataParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Base.BaseVec<Substrate.NetApi.Model.Types.Primitive.U8>>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForMetadataParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForMetadataParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "CounterForMetadata", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForMetadataDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForMetadataDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForMetadata
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForMetadata(CancellationToken token)
        {
            string parameters = CounterForMetadataParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> LastPoolIdParams
        ///  Ever increasing number of all pools created so far.
        /// </summary>
        public static string LastPoolIdParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "LastPoolId", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> LastPoolIdDefault
        /// Default value as hex string
        /// </summary>
        public static string LastPoolIdDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> LastPoolId
        ///  Ever increasing number of all pools created so far.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> LastPoolId(CancellationToken token)
        {
            string parameters = LastPoolIdParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> ReversePoolIdLookupParams
        ///  A reverse lookup from the pool's account id to its id.
        /// 
        ///  This is only used for slashing. In all other instances, the pool id is used, and the
        ///  accounts are deterministically derived from it.
        /// </summary>
        public static string ReversePoolIdLookupParams(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32 key)
        {
            return RequestGenerator.GetStorage("NominationPools", "ReversePoolIdLookup", Substrate.NetApi.Model.Meta.Storage.Type.Map, new Substrate.NetApi.Model.Meta.Storage.Hasher[] { Substrate.NetApi.Model.Meta.Storage.Hasher.Twox64Concat }, new Substrate.NetApi.Model.Types.IType[] { key });
        }

        /// <summary>
        /// >> ReversePoolIdLookupDefault
        /// Default value as hex string
        /// </summary>
        public static string ReversePoolIdLookupDefault()
        {
            return "0x00";
        }

        /// <summary>
        /// >> ReversePoolIdLookup
        ///  A reverse lookup from the pool's account id to its id.
        /// 
        ///  This is only used for slashing. In all other instances, the pool id is used, and the
        ///  accounts are deterministically derived from it.
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> ReversePoolIdLookup(Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.sp_core.crypto.AccountId32 key, CancellationToken token)
        {
            string parameters = ReversePoolIdLookupParams(key);
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        /// <summary>
        /// >> CounterForReversePoolIdLookupParams
        /// Counter for the related counted storage map
        /// </summary>
        public static string CounterForReversePoolIdLookupParams()
        {
            return RequestGenerator.GetStorage("NominationPools", "CounterForReversePoolIdLookup", Substrate.NetApi.Model.Meta.Storage.Type.Plain);
        }

        /// <summary>
        /// >> CounterForReversePoolIdLookupDefault
        /// Default value as hex string
        /// </summary>
        public static string CounterForReversePoolIdLookupDefault()
        {
            return "0x00000000";
        }

        /// <summary>
        /// >> CounterForReversePoolIdLookup
        /// Counter for the related counted storage map
        /// </summary>
        public async Task<Substrate.NetApi.Model.Types.Primitive.U32> CounterForReversePoolIdLookup(CancellationToken token)
        {
            string parameters = CounterForReversePoolIdLookupParams();
            var result = await _client.GetStorageAsync<Substrate.NetApi.Model.Types.Primitive.U32>(parameters, blockHash, token);
            return result;
        }

        public NominationPoolsStorage(SubstrateClientExt client)
        {
            _client = client;
        }
    }

    public sealed class NominationPoolsConstants
    {
        /// <summary>
        /// >> PalletId
        ///  The nomination pool's pallet id.
        /// </summary>
        public Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.frame_support.PalletId PalletId()
        {
            var result = new Polkanalysis.Kusama.NetApiExt.Generated.Model.v9260.frame_support.PalletId();
            result.Create("0x70792F6E6F706C73");
            return result;
        }

        /// <summary>
        /// >> MinPointsToBalance
        ///  The minimum pool points-to-balance ratio that must be maintained for it to be `open`.
        ///  This is important in the event slashing takes place and the pool's points-to-balance
        ///  ratio becomes disproportional.
        ///  For a value of 10, the threshold would be a pool points-to-balance ratio of 10:1.
        ///  Such a scenario would also be the equivalent of the pool being 90% slashed.
        /// </summary>
        public Substrate.NetApi.Model.Types.Primitive.U32 MinPointsToBalance()
        {
            var result = new Substrate.NetApi.Model.Types.Primitive.U32();
            result.Create("0x0A000000");
            return result;
        }
    }

    public enum NominationPoolsErrors
    {
        /// <summary>
        /// >> PoolNotFound
        /// A (bonded) pool id does not exist.
        /// </summary>
        PoolNotFound,
        /// <summary>
        /// >> PoolMemberNotFound
        /// An account is not a member.
        /// </summary>
        PoolMemberNotFound,
        /// <summary>
        /// >> RewardPoolNotFound
        /// A reward pool does not exist. In all cases this is a system logic error.
        /// </summary>
        RewardPoolNotFound,
        /// <summary>
        /// >> SubPoolsNotFound
        /// A sub pool does not exist.
        /// </summary>
        SubPoolsNotFound,
        /// <summary>
        /// >> AccountBelongsToOtherPool
        /// An account is already delegating in another pool. An account may only belong to one
        /// pool at a time.
        /// </summary>
        AccountBelongsToOtherPool,
        /// <summary>
        /// >> FullyUnbonding
        /// The member is fully unbonded (and thus cannot access the bonded and reward pool
        /// anymore to, for example, collect rewards).
        /// </summary>
        FullyUnbonding,
        /// <summary>
        /// >> MaxUnbondingLimit
        /// The member cannot unbond further chunks due to reaching the limit.
        /// </summary>
        MaxUnbondingLimit,
        /// <summary>
        /// >> CannotWithdrawAny
        /// None of the funds can be withdrawn yet because the bonding duration has not passed.
        /// </summary>
        CannotWithdrawAny,
        /// <summary>
        /// >> MinimumBondNotMet
        /// The amount does not meet the minimum bond to either join or create a pool.
        /// </summary>
        MinimumBondNotMet,
        /// <summary>
        /// >> OverflowRisk
        /// The transaction could not be executed due to overflow risk for the pool.
        /// </summary>
        OverflowRisk,
        /// <summary>
        /// >> NotDestroying
        /// A pool must be in [`PoolState::Destroying`] in order for the depositor to unbond or for
        /// other members to be permissionlessly unbonded.
        /// </summary>
        NotDestroying,
        /// <summary>
        /// >> NotOnlyPoolMember
        /// The depositor must be the only member in the bonded pool in order to unbond. And the
        /// depositor must be the only member in the sub pools in order to withdraw unbonded.
        /// </summary>
        NotOnlyPoolMember,
        /// <summary>
        /// >> NotNominator
        /// The caller does not have nominating permissions for the pool.
        /// </summary>
        NotNominator,
        /// <summary>
        /// >> NotKickerOrDestroying
        /// Either a) the caller cannot make a valid kick or b) the pool is not destroying.
        /// </summary>
        NotKickerOrDestroying,
        /// <summary>
        /// >> NotOpen
        /// The pool is not open to join
        /// </summary>
        NotOpen,
        /// <summary>
        /// >> MaxPools
        /// The system is maxed out on pools.
        /// </summary>
        MaxPools,
        /// <summary>
        /// >> MaxPoolMembers
        /// Too many members in the pool or system.
        /// </summary>
        MaxPoolMembers,
        /// <summary>
        /// >> CanNotChangeState
        /// The pools state cannot be changed.
        /// </summary>
        CanNotChangeState,
        /// <summary>
        /// >> DoesNotHavePermission
        /// The caller does not have adequate permissions.
        /// </summary>
        DoesNotHavePermission,
        /// <summary>
        /// >> MetadataExceedsMaxLen
        /// Metadata exceeds [`Config::MaxMetadataLen`]
        /// </summary>
        MetadataExceedsMaxLen,
        /// <summary>
        /// >> Defensive
        /// Some error occurred that should never happen. This should be reported to the
        /// maintainers.
        /// </summary>
        Defensive,
        /// <summary>
        /// >> NotEnoughPointsToUnbond
        /// Not enough points. Ty unbonding less.
        /// </summary>
        NotEnoughPointsToUnbond,
        /// <summary>
        /// >> PartialUnbondNotAllowedPermissionlessly
        /// Partial unbonding now allowed permissionlessly.
        /// </summary>
        PartialUnbondNotAllowedPermissionlessly
    }
}