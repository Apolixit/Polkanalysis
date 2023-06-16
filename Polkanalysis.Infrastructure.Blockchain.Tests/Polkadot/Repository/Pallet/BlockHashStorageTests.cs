using Substrate.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet
{
    /// <summary>
    /// Test if the block hash is correctly passed to each storage
    /// So we return null for storage call without blockhash and a simple value with
    /// </summary>
    public class BlockHashStorageTests : PolkadotRepositoryMock
    {
        private const string BlockHash = "IAmABlockHash";

        [Test]
        public async Task AuctionStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Auctions.AuctionCounterAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task AuthorshipStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new Bool(true);

            _substrateRepository.PolkadotClient.GetStorageAsync<Bool>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<Bool>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Authorship.DidSetUnclesAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new Bool().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Authorship.DidSetUnclesAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task BabeStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U64(100);

            _substrateRepository.PolkadotClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Babe.GenesisSlotAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U64().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Babe.GenesisSlotAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task BalancesStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U128(new BigInteger(10));

            _substrateRepository.PolkadotClient.GetStorageAsync<U128>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U128>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U128().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Balances.TotalIssuanceAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task CrowdloanStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Crowdloan.EndingsCountAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Crowdloan.EndingsCountAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task IdentityStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new RegistrarInfo()
            {
                Account = new SubstrateAccount(MockAddress),
                Fee = new U128(new BigInteger(10)),
                Fields = new U64(100)
            };

            //_substrateRepository.PolkadotClient.GetStorageAsync<RegistarInfo>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Identity.RegistrarsAsync(CancellationToken.None);

            //Assert.That(resWithoutBlockHash, Is.EqualTo(new RegistarInfo()));

            //var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Identity.RegistrarsAsync(CancellationToken.None);

            //Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task NominationPoolStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.NominationPools.MaxPoolsAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.NominationPools.MaxPoolsAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task ParaSessionInfoStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task ParaStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Paras.FutureCodeUpgradesAsync(new Id(1), CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Paras.FutureCodeUpgradesAsync(new Id(1), CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        [Ignore("Todo debug")]
        public async Task RegistarStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new Id(1);

            _substrateRepository.PolkadotClient.GetStorageAsync<Id>(Arg.Any<string>(), Arg.Is<string>(x => x == null), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<Id>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Registrar.NextFreeParaIdAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new Id().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Registrar.NextFreeParaIdAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task SessionStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Session.CurrentIndexAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Session.CurrentIndexAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task Stakingtorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Staking.CounterForValidatorsAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Staking.CounterForValidatorsAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task SystemStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.System.NumberAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.System.NumberAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task TimestampStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U64(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), Arg.Is(CancellationToken.None)).ReturnsNull();
            _substrateRepository.PolkadotClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Timestamp.NowAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U64().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Timestamp.NowAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }
    }
}
