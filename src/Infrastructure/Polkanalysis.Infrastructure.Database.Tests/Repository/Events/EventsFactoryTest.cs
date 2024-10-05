using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events
{
    public class EventsFactoryTest : EventsDatabaseTests
    {
        private IServiceProvider _serviceProvider;

        [SetUp]
        public void Start()
        {
            var substrateNodeRepository = Substitute.For<ISubstrateService>();

            _serviceProvider = Substitute.For<IServiceProvider>();
            _serviceProvider.GetService(typeof(BalancesDustLostRepository)).Returns(new BalancesDustLostRepository(_substrateDbContext, substrateNodeRepository, Substitute.For<ILogger<BalancesDustLostRepository>>()));
            _serviceProvider.GetService(typeof(SystemKilledAccountRepository)).Returns(new SystemKilledAccountRepository(_substrateDbContext, substrateNodeRepository, Substitute.For<ILogger<SystemKilledAccountRepository>>()));
        }
        [Test]
        public void EventFactory_ShouldDetectAutomaticallyRepositories()
        {
            EventsFactory _eventsFactory = new EventsFactory(_serviceProvider, Substitute.For<ILogger<EventsFactory>>());

            Assert.That(_eventsFactory.Mapped.Count(), Is.EqualTo(2)); // 2 is the number of services that we have registered in the Start method
        }
    }
}
