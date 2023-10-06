using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;
using Substrate.NET.Utils;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Auctions
{
    public class AuctionsStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task AuctionCounter_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
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
        [Category("NO_DATA")]
        public async Task ReservedAmounts_ShouldWorkAsync()
        {
            //var blockHashWithAuction = "0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926";
            //var res = await _substrateRepository.At(blockHashWithAuction).Storage.Auctions.ReservedAmountsAsync(CancellationToken.None);
            //Assert.That(res, Is.Not.Null);
            Assert.Fail();
        }

        [Test]
        [Category("NO_DATA")]
        public async Task AuctionWinning_ShouldWorkAsync()
        {
            /* Test case
             * Auction num 40 (https://polkadot.subscan.io/auction/40)
             * Start block = 14238400 (hash : 0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926)
             */
            var blockHashWithAuction = "0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926";
            var u32 = new U32();
            u32.Create(1);
            var res = await _substrateRepository.At(blockHashWithAuction).Storage.Auctions.WinningAsync(u32, CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }
    }
}
