
using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Blazscan.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Schnorrkel.Keys;

namespace Blazscan.Domain.Contracts.Helpers
{
    /// <summary>
    /// Todo: refacto with interface
    /// </summary>
    public static class AccountHelper
    {
        /// <summary>
        /// Create an `AccountId32` from seed
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="secretSeed"></param>
        /// <returns></returns>
        public static AccountId32 BuildAccountId32(string secretSeed)
        {
            MiniSecret miniSecretAccount = new MiniSecret(Utils.HexToByteArray(secretSeed), ExpandMode.Ed25519);
            var account = Account.Build(KeyType.Sr25519, miniSecretAccount.ExpandToSecret().ToBytes(), miniSecretAccount.GetPair().Public.Key);

            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(account.Value));
            return accountId32;
        }

        /// <summary>
        /// Get and AccountId32 from Dto
        /// </summary>
        /// <param name="accountDto"></param>
        /// <returns></returns>
        public static AccountId32 BuildAccountId32(AccountDto accountDto)
        {
            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(accountDto.Address.Address));
            return accountId32;
        }

        public static string BuildAddress(AccountId32 account)
        {
            return Utils.GetAddressFrom(account.Value.Bytes);
        }
    }
}
