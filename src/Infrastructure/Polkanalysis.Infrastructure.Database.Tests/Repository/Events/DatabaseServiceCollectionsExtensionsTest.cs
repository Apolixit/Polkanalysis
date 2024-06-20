using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository.Staking;
using Polkanalysis.Infrastructure.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Database.Repository.Events.Balances;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events
{
    internal class DatabaseServiceCollectionsExtensionsTest
    {
        private IServiceCollection _services;

        [SetUp]
        public void SetUp()
        {
            _services = new ServiceCollection();
        }

        [Test]
        public void AddEventDatabaseRepositories_ShouldRegisterRepositories()
        {
            _services.AddDatabase();
            _ = _services.BuildServiceProvider();
            Assert.That(_services.Count, Is.GreaterThan(3));
        }
    }
}
