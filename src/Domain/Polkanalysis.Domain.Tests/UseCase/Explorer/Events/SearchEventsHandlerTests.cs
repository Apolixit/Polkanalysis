using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Domain.UseCase.Runtime.PalletVersion;
using Polkanalysis.Domain.UseCase.Search;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;
using Polkanalysis.Infrastructure.Database.Repository.Events.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Events
{
    public class SearchEventsHandlerTests : UseCaseTest<SearchEventsHandler, IQueryable<EventsResultDto>, SearchEventsQuery>
    {
        private IEventsFactory _eventFactory;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SearchEventsHandler>>();

            var _serviceProvider = Substitute.For<IServiceProvider>();
            _serviceProvider.GetService(typeof(SystemNewAccountRepository)).Returns(new SystemNewAccountRepository(_substrateDbContext, _substrateService, Substitute.For<ILogger<SystemNewAccountRepository>>()));
            _serviceProvider.GetService(typeof(SystemKilledAccountRepository)).Returns(new SystemKilledAccountRepository(_substrateDbContext, _substrateService, Substitute.For<ILogger<SystemKilledAccountRepository>>()));

            _eventFactory = new EventsFactory(_serviceProvider, Substitute.For<ILogger<EventsFactory>>());
            PopulateDatabaseWithSomeEvents();

            _substrateDbContext.SaveChanges();

            _useCase = new SearchEventsHandler(_logger, Substitute.For<IDistributedCache>(), _eventFactory);
        }

        

        #region Validator
        [Test]
        public void SearchEventsQueryValidator_WithInvalidDateStart_ShouldFail()
        {
            var query = new SearchEventsQuery()
            {
                DateBlockFilter = new NumberCriteria<DateTime>()
                {
                    Operator = Operator.GreaterStrict,
                    Value = DateTime.Now.AddDays(1),
                }
            };

            Assert.That(new SearchEventsQueryValidator().Validate(query).IsValid, Is.False);
        }

        [Test]
        public void SearchEventsQueryValidator_WithInvalidDateEnd_ShouldFail()
        {
            var query = new SearchEventsQuery()
            {
                DateBlockFilter = new NumberCriteria<DateTime>()
                {
                    Operator = Operator.GreaterStrict,
                    Value2 = DateTime.Now.AddDays(1),
                }
            };

            Assert.That(new SearchEventsQueryValidator().Validate(query).IsValid, Is.False);
        }

        [Test]
        public void SearchEventsQueryValidator_WithDateStartGreaterThanDateEnd_ShouldFail()
        {
            var query = new SearchEventsQuery()
            {
                DateBlockFilter = new NumberCriteria<DateTime>()
                {
                    Operator = Operator.Equal,
                    Value = DateTime.Now.AddDays(1),
                    Value2 = DateTime.Now.AddDays(-1),
                }
            };

            var validator = new SearchEventsQueryValidator();
            Assert.That(new SearchEventsQueryValidator().Validate(query).IsValid, Is.False);
        }
        #endregion

        [Test]
        public async Task SearchEvent_WithNoFilter_ShouldReturnAllEventsAsync()
        {
            var query = new SearchEventsQuery();

            var result = await _useCase!.Handle(query, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Count(), Is.GreaterThan(0));

            Assert.That(result.Value.All(x => x.ContextParameters.Count() == 0), Is.True);
        }

        [Test]
        public async Task SearchEventSystem_WhenFilterOnModule_ShouldReturnAllAssociatedEventsAsync()
        {
            var query = new SearchEventsQuery()
            {
                SelectedModules = ["System"]
            };

            var result = await _useCase!.Handle(query, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value.Count(), Is.EqualTo(3));
        }

        [Test]
        public async Task SearchEventSystem_WhenFilterOnModuleAndEvents_ShouldReturnOnlyEventsAsync()
        {
            var query = new SearchEventsQuery()
            {
                SelectedModules = ["System"],
                SelectedEvents = ["NewAccount"],
                DateBlockFilter = new NumberCriteria<DateTime>()
                {
                    Operator = Operator.Equal,
                    Value = new DateTime(2024, 01, 01)
                }
            };

            var result = await _useCase!.Handle(query, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            var listRes = result.Value.ToList();
            Assert.That(listRes.Count, Is.EqualTo(1));
            Assert.That(listRes[0].BlockId, Is.EqualTo(1));

            var firstParam = listRes[0].ContextParameters[0];
            Assert.That(firstParam, Is.Not.Null);

            Assert.That(firstParam.Name.ToString(), Is.EqualTo("AccountAddress"));
            Assert.That(firstParam.Value!.ToString(), Is.EqualTo(Alice.ToString()));
        }
    }
}
