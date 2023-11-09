using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Substrate.NET.Utils;
using Polkanalysis.Domain.Contracts.Core;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Auctions
{
    public class AuctionsStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task AuctionCounter_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);

            // Nb Auctions
            Assert.That(res.As<U32>().Value, Is.GreaterThan(1));
        }

        public static IEnumerable<int> AuctionInformationTestCases = new List<int>()
        {
            17510400, 17337600, 17164800, 16992000, 13547200, 13374400, 13201600, 12856000, 12683200, 12164800, 11992000, 11128000, 10782400, 10264000, 9745600, 9070110, 8868510, 8263710, 7759710
        };

        /// <summary>
        /// Get information about current Auction
        /// </summary>
        /// <returns></returns>
        [Test]
        [TestCaseSource(nameof(AuctionInformationTestCases))]
        public async Task AuctionInformation_ShouldWorkAsync(int numBlock)
        {
            var res = await _substrateRepository.At((uint)numBlock).Storage.Auctions.AuctionInfoAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);

            // Lease period
            Assert.That(((U32)res.Value[0]).Value, Is.GreaterThan(1));

            // Block end
            Assert.That(((U32)res.Value[1]).Value, Is.GreaterThan(1));
        }

        [Test]
        [Category("NO_DATA"), Ignore(NoTestCase)]
        public async Task ReservedAmounts_ShouldWorkAsync()
        {
            //var blockHashWithAuction = "0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926";
            //var res = await _substrateRepository.At(blockHashWithAuction).Storage.Auctions.ReservedAmountsAsync(CancellationToken.None);
            //Assert.That(res, Is.Not.Null);
            Assert.Fail();
        }

        [Test]
        [TestCase(30)]
        [TestCase(40)]
        [TestCase(45)]
        [TestCase(50)]
        [TestCase(52)]
        public async Task AuctionWinning_ShouldWorkAsync(int num)
        {
            /* Test case
             * Auction num 40 (https://polkadot.subscan.io/auction/40)
             * Start block = 14238400 (hash : 0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926)
             */
            //var blockHashWithAuction = "0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926";
            var res = await _substrateRepository.Storage.Auctions.WinningAsync(new U32((uint)num), CancellationToken.None);
            
            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value[7], Is.Not.Null);

            var first = res.Value[7].Value.Value[0].As<SubstrateAccount>();
            var second = res.Value[7].Value.Value[1].As<Id>();
            var third = res.Value[7].Value.Value[2].As<U128>();
            
            Assert.That(first.ToPolkadotAddress(), Is.EqualTo("13UVJyLnbVp77Z2t6qvevjrhAHvhXzEKzVRLFA8VLSMjLCw7"));
            Assert.That(second.ToHuman(), Is.EqualTo(3350));
            Assert.That(third.Value, Is.EqualTo(new BigInteger(2087624539191036)));
        }
    }
}
