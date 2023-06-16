using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts.Information;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Integration.Tests.Polkadot;
using Polkanalysis.Domain.Service;

namespace Polkanalysis.Domain.Integration.Tests.Repository
{
    [Timeout(RepositoryMaxTimeout)]
    public class ParachainRepositoryTest : PolkadotIntegrationTest
    {
        private IParachainService _parachainService;
        private IAccountService _accountRepository;
        private IExplorerService _explorerRepository;
        private IBlockchainInformations _blockchainInformations;

        [SetUp]
        public void Setup()
        {
            _accountRepository = Substitute.For<IAccountService>();
            _explorerRepository = Substitute.For<IExplorerService>();
            _blockchainInformations = Substitute.For<IBlockchainInformations>();

            _parachainService = new ParachainService(_substrateRepository, _accountRepository, _explorerRepository, _blockchainInformations);
        }

        [Test]
        [TestCase(2051)]
        public async Task ValidParachain_GetDetails_ShouldWorkAsync(int parachainId)
        {
            var res = await _parachainService.GetParachainDetailAsync((uint)parachainId, CancellationToken.None);

            Assert.That(res.ParachainId, Is.EqualTo(parachainId)); 
            Assert.That(res.RegisterStatus, Is.EqualTo("Parachain")); 
        }
    }
}
