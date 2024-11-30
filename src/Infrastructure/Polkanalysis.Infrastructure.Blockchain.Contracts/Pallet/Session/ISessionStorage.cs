using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Random;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session
{
    public interface ISessionStorage : IPalletStorage
    {
        /// <summary>
        /// The current set of validators.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<SubstrateAccount>> ValidatorsAsync(CancellationToken token);

        /// <summary>
        /// Current index of the session.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<U32> CurrentIndexAsync(CancellationToken token);

        /// <summary>
        ///  True if the underlying economic identities or weighting behind the validators
        ///  has changed in the queued validator set.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<Bool> QueuedChangedAsync(CancellationToken token);

        /// <summary>
        ///  The queued keys for the next session. When the next session begins, these keys
        ///  will be used to determine the validator's session keys.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<BaseTuple<SubstrateAccount, SessionKeysPolka>>> QueuedKeysAsync(CancellationToken token);

        /// <summary>
        ///  Indices of disabled validators.
        /// 
        ///  The vec is always kept sorted so that we can find whether a given validator is
        ///  disabled using binary search. It gets cleared when `on_session_ending` returns
        ///  a new set of identities.
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<BaseVec<U32>> DisabledValidatorsAsync(CancellationToken token);

        /// <summary>
        /// The next session keys for a validator.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SessionKeysPolka> NextKeysAsync(SubstrateAccount account, CancellationToken token);

        /// <summary>
        /// The owner of a key. The key is the `KeyTypeId` + the encoded key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public Task<SubstrateAccount> KeyOwnerAsync(BaseTuple<FlexibleNameable, Hexa32> key, CancellationToken token);
    }
}
