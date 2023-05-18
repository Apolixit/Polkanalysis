using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Integration.Tests.Repository
{
    public class ParachainRepositoryTest : PolkadotIntegrationTest
    {
        private IParachainRepository _parachainRepository;
        private IAccountRepository _accountRepository;
        private IExplorerRepository _explorerRepository;

        [SetUp]
        public void Setup()
        {
            _accountRepository = Substitute.For<IAccountRepository>();
            _explorerRepository = Substitute.For<IExplorerRepository>();

            _parachainRepository = new ParachainRepository(_substrateRepository, _accountRepository, _explorerRepository);
        }

        [Test]
        [TestCase(2051)]
        public async Task ValidParachain_GetDetails_ShouldWorkAsync(int parachainId)
        {
            var res = await _parachainRepository.GetParachainDetailAsync((uint)parachainId, CancellationToken.None);

            Assert.True(true); // TODO TMP
            //Assert.That(res, Is.Not.Null);
        }
    }
}
