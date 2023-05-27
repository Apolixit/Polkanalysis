using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Configuration.Contracts.Information;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.Repository
{
    public class ParachainRepositoryTest
    {
        private IParachainRepository _parachainRepository;
        private ISubstrateRepository _substrateRepository;
        private IAccountRepository _accountRepository;
        private IExplorerRepository _explorerRepository;
        private IBlockchainInformations _blockchainInformations;

        [SetUp]
        public void Setup()
        {
            _substrateRepository = Substitute.For<ISubstrateRepository>();
            _accountRepository = Substitute.For<IAccountRepository>();
            _explorerRepository = Substitute.For<IExplorerRepository>();
            _blockchainInformations = Substitute.For<IBlockchainInformations>();

            _parachainRepository = new ParachainRepository(_substrateRepository, _accountRepository, _explorerRepository, _blockchainInformations);
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
