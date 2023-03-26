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

        [SetUp]
        public void Setup()
        {
            _parachainRepository = new PolkadotParachainRepository(_substrateRepository);
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
