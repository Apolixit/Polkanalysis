﻿using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Public;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.ParaSessionInfo
{
    public interface IParaSessionInfoStorage : IPalletStorage
    {
        /// <summary>
        ///  Assignment keys for the current session.
        ///  Note that this API is private due to it being prone to 'off-by-one' at session boundaries.
        ///  When in doubt, use `Sessions` API instead.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<PublicSr25519>> AssignmentKeysUnsafeAsync(CancellationToken token);

        /// <summary>
        /// The earliest session for which previous session info is stored.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> EarliestStoredSessionAsync(CancellationToken token);

        /// <summary>
        ///  Session information in a rolling window.
        ///  Should have an entry in range `EarliestStoredSession..=CurrentSessionIndex`.
        ///  Does not have any entries before the session index in the first session change notification.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SessionInfo> SessionsAsync(U32 key, CancellationToken token);

        /// <summary>
        /// The validator account keys of the validators actively participating in parachain consensus.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<SubstrateAccount>> AccountKeysAsync(U32 key, CancellationToken token);

        Task<ExecutorParams> SessionExecutorParamsAsync(U32 key, CancellationToken token);
    }
}
