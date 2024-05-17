using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.SystemT
{
    public class SystemNewAccountRepositoryTest : EventsDatabaseTests
    {
        private SystemNewAccountRepository _systemNewAccountRepository;

        [SetUp]
        public void Setup()
        {
            _systemNewAccountRepository = new SystemNewAccountRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<SystemNewAccountRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventSystemNewAccount.Add(new("Polkadot", 1, new DateTime(2024, 01, 01), 1, "", "", Alice.ToString()));
            _substrateDbContext.EventSystemNewAccount.Add(new("Polkadot", 2, new DateTime(2024, 01, 01), 1, "", "", Bob.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_systemNewAccountRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(MockAddress)]
        public async Task BuildModel_WhenValidNewAccount_ShouldBuildModelSuccessfullyAsync(string account)
        {
            var enumNewAccount = new Blockchain.Contracts.Pallet.System.Enums.EnumEvent();
            enumNewAccount.Create(
                    Blockchain.Contracts.Pallet.System.Enums.Event.NewAccount,
                    new SubstrateAccount(account)

            );

            var model = await _systemNewAccountRepository.BuildModelAsync(
                BuildEventModel("System", "NewAccount"),
                enumNewAccount,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("System"));
            Assert.That(model.ModuleEvent, Is.EqualTo("NewAccount"));
            Assert.That(model.AccountAddress, Is.EqualTo(account));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _systemNewAccountRepository.SearchAsync(new()
            {
                AccountAddress = RandomAccount.ToString(),
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(0));
        }
    }
}
