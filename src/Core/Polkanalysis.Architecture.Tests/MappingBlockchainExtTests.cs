using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Scan.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Architecture.Tests
{
    public class MappingBlockchainExtTests
    {
        private IBlockchainMapping _blockchainMapping;

        [OneTimeSetUp]
        public void Init()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test, Ignore("Need more time to fix this", Until = "2024-10-30")]
        public void EveryBlockchainEventsImplemented_ShouldHaveAllEnumValueThatEverExisted()
        {
            // Let's get all events from blockchain ext
            var result = ScanAssemblyMapping.ScanEnumMappings("Polkanalysis.Polkadot.NetApiExt", "Polkanalysis.Infrastructure.Blockchain.Contracts");

            Assert.That(result, Is.Not.Empty);

            // Check if domain enum have the aggregation of all ext enum version
            var mapped = result.Where(x => x.IsClassMapped).ToList();
            var mappedByMissProperties = mapped.Where(x => !x.AreAllPropertiesMapped).ToList();

            Assert.Multiple(() => {
                Assert.That(mappedByMissProperties.Count > 0, Is.True, "Enums have unmapped properties");

                mappedByMissProperties.ForEach(x =>
                {
                    Assert.Fail($"{x.SourceClass} has {string.Join(", ", x.UnmappedProperties)} unmapped properties");
                });
            });

            _blockchainMapping = new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>());

            //_blockchainMapping.MapEnum()
            Assert.Fail();
        }

        [Test, Ignore("Romain 2023-10-22 : It should not be the case, I keep it as ignore in case i change my mind")]
        public void EveryBlockchainEvents_ShouldBeMappedFromExtProject()
        {
            // Let's get all events from blockchain ext
            var result = ScanAssemblyMapping.ScanEnumMappings("Polkanalysis.Polkadot.NetApiExt", "Polkanalysis.Infrastructure.Blockchain.Contracts");

            Assert.That(result, Is.Not.Empty);

            // Check if all events have been mapped
            // Take maximum 20 errors
            var unmapped = result.Where(x => !x.IsClassMapped).Take(20).ToList();

            Assert.Multiple(() =>
            {
                Assert.That(unmapped.Count > 0, Is.True, "All enums are not mapped correctly");

                unmapped.ForEach(x =>
                {
                    Assert.Fail($"{x.SourceClass} is not mapped to Domain");
                });
            });
        }

        [Test]
        public void EveryDomainEventBlockchain_ShouldHaveDomainMappingAttribute()
        {
            var result = ScanAssemblyMapping.LoadEnumDomainType("Polkanalysis.Infrastructure.Blockchain.Contracts");

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Empty);

                var missingAttribute = result.Where(x => x.MappingAttribute is null).ToList();
                missingAttribute.ForEach(x =>
                {
                    Assert.Fail($"Missing DomainMapping attribute for {x.EnumExt.GetType().Name} ({x.FullName})");
                });
            });
            
        }
    }
}
