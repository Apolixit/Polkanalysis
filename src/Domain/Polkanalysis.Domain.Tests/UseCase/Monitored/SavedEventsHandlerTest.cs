using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Microsoft.Extensions.Caching.Distributed;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Core.DispatchInfo;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Infrastructure.Database.Repository;
using Microsoft.Extensions.DependencyInjection;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using Polkanalysis.Domain.Contracts.Core;

namespace Polkanalysis.Domain.Tests.UseCase.Monitored
{
    public class SavedEventsHandlerTest : UseCaseTest<SavedEventsHandler, bool, SavedEventsCommand>
    {
        private IEventsFactory _eventsFactory;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SavedEventsHandler>>();
            var _serviceProvider = Substitute.For<IServiceProvider>();
            _serviceProvider.GetService(typeof(BalancesDustLostRepository)).Returns(new BalancesDustLostRepository(_substrateDbContext, _substrateService, Substitute.For<ILogger<BalancesDustLostRepository>>()));
            _serviceProvider.GetService(typeof(SystemKilledAccountRepository)).Returns(new SystemKilledAccountRepository(_substrateDbContext, _substrateService, Substitute.For<ILogger<SystemKilledAccountRepository>>()));

            _eventsFactory = new EventsFactory(_serviceProvider, Substitute.For<ILogger<IEventsFactory>>());

            _substrateService.BlockchainName.Returns("Polkadot");

            _useCase = new SavedEventsHandler(_substrateService,
                                              _eventsFactory,
                                              _logger,
                                              Substitute.For<IDistributedCache>(),
                                              _substrateDbContext);
        }

        [Test]
        public async Task SavedEventHandler_WithValidData_ShouldSucceedAsync()
        {
            var firstEvent = new EventRecord();
            var phase = new EnumPhase();
            phase.Create(Phase.ApplyExtrinsic, new U32(0));
            var topics = new BaseVec<Hash>();
            topics.Create(new byte[] { 0 });

            var runtimeEvent = new EnumRuntimeEvent();
            var killedAccountEvent = new EnumEvent();

            killedAccountEvent.Create(Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums.Event.KilledAccount, new SubstrateAccount(Alice.ToString()));
            runtimeEvent.Create(RuntimeEvent.System, killedAccountEvent);

            firstEvent.Create(phase, new Infrastructure.Blockchain.Contracts.Core.Maybe<EnumRuntimeEvent>(runtimeEvent), topics);
            
            var eventNode = Substitute.For<IEventNode>();
            eventNode.Module.Returns(RuntimeEvent.System);
            eventNode.Method.Returns(Event.KilledAccount);

            var command = new SavedEventsCommand(new BlockNumber(1),
                                                 new DateTime(2024, 01, 01),
                                                 1,
                                                 firstEvent,
                                                 eventNode);

            Assert.That(_substrateDbContext.EventSystemKilledAccount.Count(), Is.EqualTo(0));
            Assert.That(_substrateDbContext.EventManagerModel.Count(), Is.EqualTo(0));

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            Assert.That(_substrateDbContext.EventSystemKilledAccount.Count(), Is.EqualTo(1));
            Assert.That(_substrateDbContext.EventManagerModel.Count(), Is.EqualTo(1));
        }
    }
}
