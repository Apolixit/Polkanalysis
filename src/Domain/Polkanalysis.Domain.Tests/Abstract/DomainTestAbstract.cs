using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database;
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
        protected SubstrateDbContext _substrateDbContext;

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

        private Account? _randomAccount;
        public Account RandomAccount
        {
            get
            {
                return _randomAccount ??=
                    Keyring.AddFromUri("//RandomAccount", new Meta() { Name = "RandomAccount" }, KeyType.Sr25519).Account;
            }
        }

        [SetUp]
        protected void Setup()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;
            _substrateDbContext = new SubstrateDbContext(contextOption);

            _substrateDbContext.TokenPrices.Add(new Infrastructure.Database.Contracts.Model.Price.TokenPriceModel()
            {
                BlockchainName = "Polkadot",
                Date = new DateTime(2024, 01, 01),
                Price = 10
            });

            _substrateDbContext.SaveChanges();
        }

        [TearDown]
        public void TearDown()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }
    }
}
