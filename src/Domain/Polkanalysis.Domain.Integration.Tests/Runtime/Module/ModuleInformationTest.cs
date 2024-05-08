using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Runtime.Module;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Domain.Contracts.Runtime;

namespace Polkanalysis.Domain.Integration.Tests.Runtime.Module
{
    public class ModuleInformationTest : PolkadotIntegrationTest
    {
        private IModuleInformationService _moduleRepository;
        private ICurrentMetaData _currentMetadata;

        [SetUp]
        public void Setup()
        {
            _currentMetadata = new CurrentMetaData(_substrateService, Substitute.For<ILogger<CurrentMetaData>>());
            _moduleRepository = new ModuleInformation(_currentMetadata, _substrateService);
        }

        [Test, CancelAfter(2000)]
        public void Module_PalletBalances_ShouldWork()
        {
            var balanceModuleFromCurrentMetadata = _currentMetadata.GetCurrentMetadata().Modules.FirstOrDefault(x => x.Value.Name == "balances");

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

        [Test]
        public void Module_CheckEveryCurrentRuntimeModule_ShouldWork()
        {
            _currentMetadata.GetCurrentMetadata().Modules.Select(x => x.Value).ToList().ForEach(module =>
            {
                var res = _moduleRepository.GetModuleDetail(module);
                Assert.That(res, Is.Not.Null);
            });
        }
    }
}
