using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class ModuleInformationTest : PolkadotIntegrationTest
    {
        private IMetadataService _metadataService;

        [SetUp]
        public void Setup()
        {
            _metadataService = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<ICoreService>(),
                                                      Substitute.For<ILogger<MetadataService>>());
        }

        [Test, CancelAfter(2000)]
        public async Task Module_PalletBalances_ShouldWorkAsync()
        {
            var res = await _metadataService.GetModuleDetailAsync("balances", CancellationToken.None);

            Assert.That(res, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(res.Events.Count, Is.GreaterThan(0));
                Assert.That(res.Calls.Count, Is.GreaterThan(0));
                Assert.That(res.Storage.Count, Is.GreaterThan(0));
                Assert.That(res.Constants.Count, Is.GreaterThan(0));
                Assert.That(res.Errors.Count, Is.GreaterThan(0));
            });
            
        }
    }
}
