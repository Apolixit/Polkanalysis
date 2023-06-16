using Substrate.NetApi.Model.Types.Primitive;
using NUnit.Framework;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository.Pallet.Auctions
{
    public class AuctionsStorageTests : PolkadotIntegrationTest
    {
        [Test]
        public async Task AuctionCounter_ShouldWorkAsync()
        {
            var res = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        /// <summary>
        /// Get information about current Auction
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task AuctionInformation_ShouldWorkAsync()
        {
            /* Test case
             * Auction num 40 (https://polkadot.subscan.io/auction/40)
             * Start block = 14238400 (hash : 0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926)
             */
            var blockHashWithAuction = "0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926";
            var res = await _substrateRepository.At(blockHashWithAuction).Storage.Auctions.AuctionInfoAsync(CancellationToken.None);
            Assert.That(res, Is.Not.Null);
        }

        [Test]
        [Category("NO_DATA")]
        public async Task ReservedAmounts_ShouldWorkAsync()
        {
            //var blockHashWithAuction = "0x5d257ad59f00bbaaefe7bbc2a170842d77e6ac3d68b140dc4999c2e053209926";
            //var res = await _substrateRepository.At(blockHashWithAuction).Storage.Auctions.ReservedAmountsAsync(CancellationToken.None);
            //Assert.That(res, Is.Not.Null);
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
