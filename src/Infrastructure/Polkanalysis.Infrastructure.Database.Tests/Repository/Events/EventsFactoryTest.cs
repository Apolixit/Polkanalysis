using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events
{
    public class EventsFactoryTest : EventsDatabaseTests
    {
        private IServiceProvider _serviceProvider;
        private EventsFactory _eventsFactory;

        [SetUp]
        public void Start()
        {
            var substrateNodeRepository = Substitute.For<ISubstrateService>();

            _serviceProvider = Substitute.For<IServiceProvider>();
            _serviceProvider.GetService(typeof(BalancesDustLostRepository)).Returns(new BalancesDustLostRepository(_substrateDbContext, substrateNodeRepository, Substitute.For<ILogger<BalancesDustLostRepository>>()));
            _serviceProvider.GetService(typeof(SystemKilledAccountRepository)).Returns(new SystemKilledAccountRepository(_substrateDbContext, substrateNodeRepository, Substitute.For<ILogger<SystemKilledAccountRepository>>()));

            _eventsFactory = new EventsFactory(_serviceProvider, Substitute.For<ILogger<EventsFactory>>());
        }

        [Test]
        public void EventFactory_ShouldDetectAutomaticallyRepositories()
        {
            Assert.That(_eventsFactory.Mapped.Count(), Is.EqualTo(2)); // 2 is the number of services that we have registered in the Start method
        }

        [Test]
        public void EventFactory_TryFind_ShouldSucceed()
        {
            var res1 = _eventsFactory.TryFind(Blockchain.Contracts.Pallet.PolkadotRuntime.RuntimeEvent.Balances, Blockchain.Contracts.Pallet.Balances.Enums.Event.DustLost);
            var bool1 = _eventsFactory.Has(Blockchain.Contracts.Pallet.PolkadotRuntime.RuntimeEvent.Balances, Blockchain.Contracts.Pallet.Balances.Enums.Event.DustLost);

            Assert.That(res1, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(res1.EventName, Is.EqualTo("Balances.DustLost"));
                Assert.That(bool1);
            });

            var res2 = _eventsFactory.TryFind("Balances", "DustLost");
            var bool2 = _eventsFactory.Has(Blockchain.Contracts.Pallet.PolkadotRuntime.RuntimeEvent.Balances, Blockchain.Contracts.Pallet.Balances.Enums.Event.DustLost);

            Assert.That(res2, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(res2.EventName, Is.EqualTo("Balances.DustLost"));
                Assert.That(bool2);
            });
        }

        [Test]
        public void EventFactory_GetSearchCriteriasParameters_WithValidSearchCriteriaClass_ShouldSucceed()
        {
            var balancesDustLostCriteria = new SearchCriteriaBalancesDustLost();

            var res = _eventsFactory.GetSearchCriteriasParameters(balancesDustLostCriteria.GetType()).ToArray();

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Length, Is.EqualTo(4));
        }

        [Test]
        public void EventFactory_GetSearchCriteriasParameters_WithInvalidSearchCriteriaClass_ShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => _eventsFactory.GetSearchCriteriasParameters(new U32(0).GetType()).ToArray());
        }
    }
}
