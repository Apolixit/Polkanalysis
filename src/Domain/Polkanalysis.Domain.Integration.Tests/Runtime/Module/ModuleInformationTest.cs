using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class ModuleInformationTest : PolkadotIntegrationTest
    {
        private IModuleInformationService _moduleRepository;
        private IMetadataService _currentMetadata;

        [SetUp]
        public void Setup()
        {
            _currentMetadata = new MetadataService(_substrateService,
                                                      _substrateDbContext,
                                                      Substitute.For<IExplorerService>(),
                                                      Substitute.For<ILogger<MetadataService>>());
            _moduleRepository = new ModuleInformation(_currentMetadata, _substrateService);
        }

        [Test, CancelAfter(2000)]
        public async Task Module_PalletBalances_ShouldWorkAsync()
        {
            var metadata = await _substrateService.GetMetadataAsync(CancellationToken.None);
            var balanceModuleFromCurrentMetadata = metadata.NodeMetadata.Modules.FirstOrDefault(x => x.Value.Name == "balances");

            var res = _moduleRepository.GetModuleDetail("balances");

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
