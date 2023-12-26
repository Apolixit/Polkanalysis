using Polkanalysis.Infrastructure.Blockchain.Internal.Scan.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Architecture.Tests
{
    public class MappingBlockchainExtTests
    {
        [Test]
        public void EveryBlockchainEvents_ShouldBeMappedFromExtProject_WithAllEnumValueThatEverExisted()
        {
            // Let's get all events from blockchain ext
            var result = ScanAssemblyMapping.ScanEnumMappings("Polkanalysis.Polkadot.NetApiExt", "Polkanalysis.Domain.Contracts");

            Assert.That(result, Is.Not.Empty);
            // Check if all events have been mapped

            // Check if domain enum have the aggregation of all ext enum version

            Assert.Fail();
        }
    }
}
