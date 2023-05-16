using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Auctions;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Tests.Polkadot.Repository.Pallet.Auctions
{
    public class AuctionsStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task AuctionCounter_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Auctions.AuctionCounterAsync);
        }

        [Test]
        public async Task AuctionCounterNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Auctions.AuctionCounterAsync);
        }

        [Test]
        public async Task AuctionInfo_ShouldWorkAsync()
        {
            var expectedResult = new BaseTuple<U32, U32>();
            expectedResult.Create("0x0B00000038ACD900");

            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Auctions.AuctionInfoAsync);

            Assert.That(((U32)expectedResult.Value[0]).Value, Is.EqualTo(11));
            Assert.That(((U32)expectedResult.Value[1]).Value, Is.EqualTo(14265400));
        }

        [Test]
        public async Task AuctionInfoNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Auctions.AuctionInfoAsync);
        }

        [Test]
        public async Task ReservedAmounts_ShouldWorkAsync()
        {
            var expectedResult = new U128(new BigInteger(10));

            await MockStorageCallWithInputAsync(
                new BaseTuple<SubstrateAccount, Id>(new SubstrateAccount(MockAddress), new Id(1)), 
                expectedResult, 
                _substrateRepository.Storage.Auctions.ReservedAmountsAsync);
        }

        [Test]
        public async Task ReservedAmountsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(
                new BaseTuple<SubstrateAccount, Id>(new SubstrateAccount(MockAddress), new Id(1)), _substrateRepository.Storage.Auctions.ReservedAmountsAsync);
        }

        [Test]
        [Ignore("Todo debug")]
        public async Task Winning_ShouldWorkAsync()
        {
            // Let's build the output we want
            var testAccount = new SubstrateAccount("13b9d23v1Hke7pcVk8G4gh3TBckDtrwFZUnqPkHezq4praEY");
            var accountId32TestAccount = PolkadotMapping.Instance.Map<SubstrateAccount, Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> (testAccount);
            var testId = new Id(1);
            var idExt = PolkadotMapping.Instance.Map<Id, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(testId);
            var baseTuple = new BaseTuple<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, U128>(accountId32TestAccount, idExt, new U128(10));

            var extResult = new Arr36BaseOpt();
            extResult.Create(new[] { new BaseOpt<BaseTuple<
                        Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32,
                        Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, 
                        U128>
                    >(baseTuple) });

            _substrateRepository.AjunaClient.GetStorageAsync<Arr36BaseOpt>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(extResult);

            var res = await _substrateRepository.Storage.Auctions.WinningAsync(new U32(1), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value.Length, Is.EqualTo(1));
            Assert.That(res.Value.First().OptionFlag, Is.True);
        }

        [Test]
        public async Task WinningNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<U32, Arr36BaseOpt, Winning>
                (new U32(1), _substrateRepository.Storage.Auctions.WinningAsync);
        }
    }
}
