using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
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
    public class SystemKilledAccountRepositoryTest : EventsDatabaseTests
    {
        private SystemKilledAccountRepository _systemKilledAccountRepository;

        [SetUp]
        public void Setup()
        {
            _systemKilledAccountRepository = new SystemKilledAccountRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IBlockchainMapping>(),
                Substitute.For<ILogger<SystemKilledAccountRepository>>());
        }

        [Test]
        [TestCase(MockAddress)]
        public async Task BuildModel_WhenValidKilledAccount_ShouldBuildModelSuccessfullyAsync(string account)
        {
            var enumKilledAccount = new Blockchain.Contracts.Pallet.System.Enums.EnumEvent();
            enumKilledAccount.Create(
                    Blockchain.Contracts.Pallet.System.Enums.Event.KilledAccount,
                    new SubstrateAccount(account)

            );

            var model = await _systemKilledAccountRepository.BuildModelAsync(
                BuildEventModel("System", "KilledAccount"),
                enumKilledAccount,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("System"));
            Assert.That(model.ModuleEvent, Is.EqualTo("KilledAccount"));
            Assert.That(model.Account, Is.EqualTo(account));
        }
    }
}
