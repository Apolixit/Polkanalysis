using Substats.Domain.Contracts.Secondary;
using Substats.Integration.Tests.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Infrastructure.DirectAccess.Repository;

namespace Substats.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Repository
{
    public class ValidatorRepositoryTest : PolkadotIntegrationTest
    {
        private IValidatorRepository _validatorRepository;

        [SetUp]
        public void Setup()
        {
            _validatorRepository = new PolkadotValidatorRepository(_substrateRepository);
        }

        [Test]
        [TestCase("5C4i2nwtkzX3ANCq1dsgLcbW8bCfKJJHVHBzk776JAbqoRRw")]
        //111B8CxcmnWbuDLyGvgUmRezDCK1brRZmvUuQ6SrFdMyc3S
        public async Task ValidValidator_GetDetails_ShouldWorkAsync(string validatorAddress)
        {
            var res = await _validatorRepository.GetValidatorDetailAsync(validatorAddress, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
