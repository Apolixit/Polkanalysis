﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Pallet.Babe
{
    public interface IBabeStorage : IPalletStorage
    {
        /// <summary>
        /// Current epoch index.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U64> EpochIndexAsync(CancellationToken token);

        /// <summary>
        /// Current epoch authorities.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<PublicSr25519, U64>>> AuthoritiesAsync(CancellationToken token);

        /// <summary>
        ///  The slot at which the first epoch actually started. This is 0
        ///  until the first block of the chain.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U64> GenesisSlotAsync(CancellationToken token);

        /// <summary>
        /// Current slot number.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U64> CurrentSlotAsync(CancellationToken token);

        /// <summary>
        ///  The epoch randomness for the *current* epoch.
        /// 
        ///  # Security
        /// 
        ///  This MUST NOT be used for gambling, as it can be influenced by a
        ///  malicious validator in the short term. It MAY be used in many
        ///  cryptographic protocols, however, so long as one remembers that this
        ///  (like everything else on-chain) it is public. For example, it can be
        ///  used where a number is needed that cannot have been chosen by an
        ///  adversary, for purposes such as public-coin zero-knowledge proofs.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hexa> RandomnessAsync(CancellationToken token);

        /// <summary>
        /// Pending epoch configuration change that will be applied when the next epoch is enacted.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<EnumNextConfigDescriptor> PendingEpochConfigChangeAsync(CancellationToken token);

        /// <summary>
        /// Next epoch randomness.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Hexa> NextRandomnessAsync(CancellationToken token);

        /// <summary>
        /// Next epoch authorities.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<PublicSr25519, U64>>> NextAuthoritiesAsync(CancellationToken token);

        /// <summary>
        ///  Randomness under construction.
        /// 
        ///  We make a trade-off between storage accesses and list length.
        ///  We store the under-construction randomness in segments of up to
        ///  `UNDER_CONSTRUCTION_SEGMENT_LENGTH`.
        /// 
        ///  Once a segment reaches this length, we begin the next one.
        ///  We reset all segments and return to `0` at the beginning of every
        ///  epoch.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> SegmentIndexAsync(CancellationToken token);

        /// <summary>
        /// TWOX-NOTE: `SegmentIndex` is an increasing integer, so this is okay.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<Hexa>> UnderConstructionAsync(U32 key, CancellationToken token);

        /// <summary>
        ///  Temporary value (cleared at block finalization) which is `Some`
        ///  if per-block initialization has already been called for current block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseOpt<EnumPreDigest>> InitializedAsync(CancellationToken token);

        /// <summary>
        ///  This field should always be populated during block processing unless
        ///  secondary plain slots are enabled (which don't contain a VRF output).
        /// 
        ///  It is set in `on_finalize`, before it will contain the value from the last block.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseOpt<Hexa>> AuthorVrfRandomnessAsync(CancellationToken token);

        /// <summary>
        ///  The block numbers when the last and current epoch have started, respectively `N-1` and
        ///  `N`.
        ///  NOTE: We track this is in order to annotate the block number when a given pool of
        ///  entropy was fixed (i.e. it was known to chain observers). Since epochs are defined in
        ///  slots, which may be skipped, the block numbers may not line up with the slot numbers.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseTuple<U32, U32>> EpochStartAsync(CancellationToken token);

        /// <summary>
        ///  How late the current block is compared to its parent.
        /// 
        ///  This entry is populated as part of block execution and is cleaned up
        ///  on block finalization. Querying this storage entry outside of block
        ///  execution context should always yield zero.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> LatenessAsync(CancellationToken token);

        /// <summary>
        ///  The configuration for the current epoch. Should never be `None` as it is initialized in
        ///  genesis.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BabeEpochConfiguration> EpochConfigAsync(CancellationToken token);

        /// <summary>
        ///  The configuration for the next epoch, `None` if the config will not change
        ///  (you can fallback to `EpochConfig` instead in that case).
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BabeEpochConfiguration> NextEpochConfigAsync(CancellationToken token);
    }
}
