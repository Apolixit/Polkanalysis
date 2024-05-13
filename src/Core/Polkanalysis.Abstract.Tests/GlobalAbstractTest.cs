using Substrate.NET.Wallet.Keyring;
using Substrate.NetApi.Model.Types;

namespace Polkanalysis.Abstract.Tests
{
    public abstract class GlobalAbstractTest
    {
        public Keyring Keyring { get; private set; } = new();

        private Account? _alice;
        public Account Alice
        {
            get
            {
                return _alice ??=
                    Keyring.AddFromUri("//Alice", new Meta() { Name = "Alice" }, KeyType.Sr25519).Account;
            }
        }

        private Account? _bob;
        public Account Bob
        {
            get
            {
                return _bob ??=
                    Keyring.AddFromUri("//Bob", new Meta() { Name = "Bob" }, KeyType.Sr25519).Account;
            }
        }

        private Account? _randomAccount;
        public Account RandomAccount
        {
            get
            {
                return _randomAccount ??=
                    Keyring.AddFromUri("//RandomAccount", new Meta() { Name = "RandomAccount" }, KeyType.Sr25519).Account;
            }
        }
    }
}