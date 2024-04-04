using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Configuration.Contracts.Information;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Tests.Service
{
    public class ParachainServiceTest
    {
        private IParachainService _parachainRepository;
        private ISubstrateService _substrateRepository;
        private IAccountService _accountRepository;
        private IExplorerService _explorerRepository;
        private IBlockchainInformations _blockchainInformations;

        [SetUp]
        public void Setup()
        {
            _substrateRepository = Substitute.For<ISubstrateService>();
            _accountRepository = Substitute.For<IAccountService>();
            _explorerRepository = Substitute.For<IExplorerService>();
            _blockchainInformations = Substitute.For<IBlockchainInformations>();

            _parachainRepository = new ParachainService(_substrateRepository, _accountRepository, _explorerRepository, _blockchainInformations);
        }

        [Test]
        public async Task ParachainNull_ShouldReturnEmptyAsync()
        {
            _substrateRepository.Storage.Paras.ParachainsAsync(Arg.Any<CancellationToken>()).ReturnsNull();

            var result = await _parachainRepository.GetParachainsAsync(CancellationToken.None);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Count(), Is.EqualTo(0));
        }
    }
}
