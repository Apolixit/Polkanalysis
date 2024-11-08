using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot
{
    internal class DelegateSystemChainTests : PolkadotIntegrationTest
    {
        /// <summary>
        /// https://people-polkadot.subscan.io/block/540668
        /// </summary>
        /// <returns></returns>
        public async Task GetAssociatedHashFromOtherChain_WithValidBlockNumber_ShouldSucceedAsync()
        {
            var res = await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(
                _peopleChainService.AjunaClient,
                _peopleChainService.BlockchainName,
                540668,
                CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value, Is.EqualTo("0x357d1d4b7e35f1ebc1786acf83112ea7b85aebd7075c550bd3d1d0c5742be7f8"));
        }

        [Test]
        public void GetAssociatedHashFromOtherChain_WithInvalidBlockNumber_ShouldFail()
        {
            Assert.ThrowsAsync<InvalidDataFromSystemParachainException>(async () => await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(
                _peopleChainService.AjunaClient,
                _peopleChainService.BlockchainName,
                uint.MaxValue,
                CancellationToken.None));
        }

        [Test]
        [TestCase(22996447, "0x6b8f11638b5904c13f35863fdd312d91728ca7302862b5bb925d715392581f05", 624283, "0xbc31559b44b25a1f947751436cc2906def8b029ae5cd2bc17a7286cf93e10b9f")]
        [TestCase(22666089, "0xd14d9606068b70847edbe551b38e5e9bbd793d49a93f3c5224b194cc66bb2edf", 470942, "0x817077adf0abc312e71e04c8f8c56850ae02d47b21bbf7d7491c1a2ac4d70d3b")]
        [TestCase(23312316, "0x2c91d5b78ab94a352096caec5f89722d7eba12119bdc3fe9384c404a012577a7", 
            778030, "0x1e3c16acb6b3849b95759495b630b205c98830fe849b814c77a9002f74317743")] // https://polkadot.subscan.io/block/23312316 | https://people-polkadot.subscan.io/block/778030
        [TestCase(23312315, "0x749b042c2b8a0345cb2efce4a8c8d1afc419b22df344477949afffe13aba4314", 
            778029, "0xf5bd022ebc188e6887bbbf50716457c2222aed5c5c978792ce0b143bfdf365bb")] // https://polkadot.subscan.io/block/23312315 | https://people-polkadot.subscan.io/block/778029
        public async Task CurrentBlockForSystemChain_FromCalculation_ShouldSucceedAsync(
            int polkadotBlockNumber, 
            string polkadotBlockHash, 
            int expectedPeopleChainBlockNumber, 
            string expectedPeopleChainBlockHash)
        {
            var blockPeopleChain = await _delegateSystemChain.CurrentBlockForSystemChainAsync(
                _peopleChainService.AjunaClient,
                "PeopleChain",
                polkadotBlockHash,
                CancellationToken.None);

            Assert.That(blockPeopleChain, Is.EqualTo(expectedPeopleChainBlockNumber));

            var hashPeopleChain = await _delegateSystemChain.GetAssociatedHashFromOtherChainAsync(_peopleChainService.AjunaClient, "PeopleChain", blockPeopleChain, CancellationToken.None);

            Assert.That(hashPeopleChain, Is.Not.Null);
            Assert.That(hashPeopleChain.Value.ToUpper(), Is.EqualTo(expectedPeopleChainBlockHash.ToUpper()));
        }

        [Test]
        [TestCase(21604404, "0x3d4ccbe223b11212d255fb454ea2c83eaf3e72313fb60ba9afc5c3a14cb67093")]
        public void CurrentBlockForSystemChain_WhenParachainDidntExistYet_ShouldThrowException(
            int polkadotBlockNumber,
            string polkadotBlockHash)
        {
            Assert.ThrowsAsync<SystemParachainDidntExistYetException>(async() => await _delegateSystemChain.CurrentBlockForSystemChainAsync(
                _peopleChainService.AjunaClient,
                "PeopleChain",
                polkadotBlockHash,
                CancellationToken.None));
        }
    }
}
