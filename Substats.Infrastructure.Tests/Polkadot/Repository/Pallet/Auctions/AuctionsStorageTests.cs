using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Tests.Polkadot.Repository.Pallet.Auctions
{
    public class AuctionsStorageTests : PolkadotRepositoryMock
    {

        [Test]
        public async Task BlockHashFilled_ShouldWorkAsync()
        {
            var expectedResult = new U32(10);

            _substrateRepository.PolkadotClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Is<string>(x => !string.IsNullOrEmpty(x)), Arg.Is(CancellationToken.None)).Returns(expectedResult);

            var resWithoutBlockHash = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);

            Assert.That(resWithoutBlockHash, Is.Null);

            var resWithBlockHash = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);

            Assert.That(resWithBlockHash, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task AuctionCounter_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Auctions.AuctionCounterAsync);
        }

        [Test]
        public async Task AuctionCounterNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Auctions.AuctionCounterAsync(CancellationToken.None);

            Assert.That(res.Value, Is.EqualTo(0));
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
            _substrateRepository.AjunaClient.GetStorageAsync<BaseTuple<U32, U32>>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Auctions.AuctionInfoAsync(CancellationToken.None);
            Assert.That(res, Is.EqualTo(new BaseTuple<U32, U32>()));
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
            _substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Auctions.ReservedAmountsAsync(new BaseTuple<SubstrateAccount, Id>(new SubstrateAccount(MockAddress), new Id(1)), CancellationToken.None);
            Assert.That(res, Is.EqualTo(new U128()));
        }

        [Test]
        public async Task Winning_ShouldWorkAsync()
        {
            // Let's build the output we want
            var testAccount = new SubstrateAccount("13b9d23v1Hke7pcVk8G4gh3TBckDtrwFZUnqPkHezq4praEY");
            var accountId32TestAccount = SubstrateMapper.Instance.Map<SubstrateAccount, Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32> (testAccount);
            var testId = new Id(1);
            var idExt = SubstrateMapper.Instance.Map<Id, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(testId);
            var baseTuple = new BaseTuple<Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32, Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, U128>(accountId32TestAccount, idExt, new U128(10));

            var extResult = new Arr36BaseOpt();
            extResult.Create(new[] { new BaseOpt<BaseTuple<
                        Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto.AccountId32,
                        Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id, 
                        U128>
                    >(baseTuple) });

            _substrateRepository.AjunaClient.GetStorageAsync<Arr36BaseOpt>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(extResult);

            var res = await _substrateRepository.Storage.Auctions.WinningAsync(new U32(1), CancellationToken.None);

            //await MockStorageCallAsync(new U32(1), extResult, _substrateRepository.Storage.Auctions.ReservedAmountsAsync);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Length, Is.EqualTo(1));
            Assert.That(res.First().OptionFlag, Is.True);
        }

        [Test]
        public async Task WinningNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<Arr36BaseOpt>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Auctions.WinningAsync(new U32(1), CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Length, Is.EqualTo(0));
        }
    }
}
