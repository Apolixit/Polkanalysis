using Substrate.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Sp;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet
{
    /// <summary>
    /// Test if the block hash is correctly passed to each storage
    /// So we return null for storage call without blockhash and a simple value with
    /// </summary>
    public class BlockHashStorageTests : PolkadotRepositoryMock
    {
        private const string BlockHash = "IAmABlockHash";

        protected override void MockStorageAndVersion<T>(T storageResult, uint version)
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<T>(Arg.Any<string>(), null, CancellationToken.None).ReturnsNull();

            _substrateRepository.PolkadotClient.GetStorageAsync<T>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), CancellationToken.None).Returns(storageResult);


            _substrateRepository.AjunaClient.InvokeAsync<Substrate.NetApi.Model.Rpc.RuntimeVersion>("state_getRuntimeVersion", Arg.Any<object>(), CancellationToken.None).Returns(new Substrate.NetApi.Model.Rpc.RuntimeVersion()
            {
                SpecVersion = version
            });
        }

        [Test]
        public async Task AuctionStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Auctions.AuctionCounterAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task AuthorshipStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new Bool(true);

            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Authorship.DidSetUnclesAsync(CancellationToken.None);

            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new Bool().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Authorship.DidSetUnclesAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task BabeStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U64(100);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Babe.EpochIndexAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U64().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Babe.EpochIndexAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task BalancesStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U128(new BigInteger(10));
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U128().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Balances.TotalIssuanceAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task CrowdloanStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Crowdloan.EndingsCountAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Crowdloan.EndingsCountAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test, Ignore("Changer avec objet core et non domain")]
        public async Task IdentityStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<BaseOpt<RegistrarInfo>>(new BaseOpt<RegistrarInfo>[] {
                new BaseOpt<RegistrarInfo>(new RegistrarInfo()
                {
                    Account = new SubstrateAccount(MockAddress),
                    Fee = new U128(new BigInteger(10)),
                    Fields = new U64(100)
                })
            });

            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Identity.RegistrarsAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash, Is.EqualTo(new RegistarInfo()));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Identity.RegistrarsAsync(CancellationToken.None);
            Assert.That(resWithBlockHash.Encode(), Is.EqualTo(expectedResult.Encode()));
        }

        [Test]
        public async Task NominationPoolStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.NominationPools.MaxPoolsAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.NominationPools.MaxPoolsAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task ParaSessionInfoStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.ParaSessionInfo.EarliestStoredSessionAsync(CancellationToken.None);
            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task ParaStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Paras.FutureCodeUpgradesAsync(new Id(1), CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Paras.FutureCodeUpgradesAsync(new Id(1), CancellationToken.None);
            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task RegistarStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id();
            expectedResult.Create("0x01000000");
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Registrar.NextFreeParaIdAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new Id().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Registrar.NextFreeParaIdAsync(CancellationToken.None);
            Assert.That(resWithBlockHash.Value.Value, Is.EqualTo(expectedResult.Value.Value));
        }

        [Test]
        public async Task SessionStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Session.CurrentIndexAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Session.CurrentIndexAsync(CancellationToken.None);
            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task Stakingtorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Staking.CounterForValidatorsAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Staking.CounterForValidatorsAsync(CancellationToken.None);
            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task SystemStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.System.NumberAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U32().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.System.NumberAsync(CancellationToken.None);
            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task TimestampStorage_BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U64(10);
            MockStorageAndVersion(expectedResult, 9370);

            //var resWithoutBlockHash = await _substrateRepository.Storage.Timestamp.NowAsync(CancellationToken.None);
            //Assert.That(resWithoutBlockHash.Bytes, Is.EqualTo(new U64().Bytes));

            var resWithBlockHash = await _substrateRepository.At(BlockHash).Storage.Timestamp.NowAsync(CancellationToken.None);
            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }
    }
}
