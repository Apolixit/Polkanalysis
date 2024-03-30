using Substrate.NET.Wallet.Keyring;
using Substrate.NetApi.Model.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Abstract
{
    public abstract class DomainTestAbstract
    {
        public Keyring Keyring { get; private set; } = new();

        private Account? _alice;
        public Account Alice {
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
    }
}
