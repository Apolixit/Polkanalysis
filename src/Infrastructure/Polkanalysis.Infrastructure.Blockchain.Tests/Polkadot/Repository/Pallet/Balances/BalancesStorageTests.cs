using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using System.Numerics;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Balances
{
    public class BalancesStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task TotalIssuance_ShouldWorkAsync(U128 input)
        {
            await MockStorageCallAsync(input, _substrateRepository.Storage.Balances.TotalIssuanceAsync);
        }

        [Test]
        public async Task TotalIssuanceNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Balances.TotalIssuanceAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task InactiveIssuance_ShouldWorkAsync(U128 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Balances.InactiveIssuanceAsync);
        }

        [Test]
        public async Task InactiveIssuanceNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Balances.InactiveIssuanceAsync);
        }

        [Test]
        public async Task Account_ShouldWorkAsync()
        {
            var account = new SubstrateAccount(MockAddress);

            var coreRes = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData();
            coreRes.Create("0x00CA9A3B000000000000000000000000400D030000000000000000000000000020A1070000000000000000000000000020030000000000000000000000000000");

            var expectedResult = new AccountData();
            expectedResult.Create(new U128(1000000000), new U128(200000), new U128(500000), new U128(800));

            await MockStorageCallWithInputAsync
                (account, coreRes, expectedResult, _substrateRepository.Storage.Balances.AccountAsync);
        }

        [Test]
        public async Task AccountNull_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount(MockAddress);

            var res = await MockStorageCallNullWithInputAsync<SubstrateAccount,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData,
                AccountData>(testAccount, _substrateRepository.Storage.Balances.AccountAsync);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Free.Bytes, Is.EqualTo(new U128().Bytes));
            Assert.That(res.Reserved.Bytes, Is.EqualTo(new U128().Bytes));
            Assert.That(res.MiscFrozen.Bytes, Is.EqualTo(new U128().Bytes));
            Assert.That(res.FeeFrozen.Bytes, Is.EqualTo(new U128().Bytes));
        }

        [Test]
        public async Task Locks_ShouldWorkAsync()
        {
            var extResult = new WeakBoundedVecT3();
            extResult.Create("0x0464656D6F6372616300E40B5402000000000000000000000001");

            var reason = new EnumReasons();
            reason.Create(Reasons.Misc);

            var firstResult = new BalanceLock();
            var name = new Domain.Contracts.Core.Display.NameableSize8();
            name.Create(extResult.Value.Value[0].Id.Bytes);
            firstResult.Create(name,
                new U128(new BigInteger(10000000000)),
                reason);

            var expectedResult = new BaseVec<BalanceLock>(new BalanceLock[]
            {
                firstResult
            });

            await MockStorageCallWithInputAsync(
                new SubstrateAccount(MockAddress),
                extResult,
                expectedResult,
                _substrateRepository.Storage.Balances.LocksAsync);

            var balanceLock = expectedResult.Value.FirstOrDefault();
            Assert.That(balanceLock, Is.Not.Null);
            Assert.That(balanceLock.Id.Display(), Is.EqualTo("democrac"));
            Assert.That(balanceLock.Reasons.Value, Is.EqualTo(Reasons.Misc));
            Assert.That(balanceLock.Amount.Value, Is.EqualTo(new BigInteger(10000000000)));
        }

        [Test]
        public async Task LocksNull_ShouldReturnEmptyAsync()
        {
            await MockStorageCallNullWithInputAsync<SubstrateAccount,
                WeakBoundedVecT3,
                BaseVec<BalanceLock>>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Balances.LocksAsync);
        }

        [Test]
        [Ignore("TODO Data")]
        public async Task Reserves_ShouldReturnEmptyAsync()
        {
            //var extResult = new BoundedVecT6();
            //var expectedResult = new BaseVec<ReserveData>();
            //await MockStorageCallWithInputAsync(
            //    new SubstrateAccount(MockAddress),
            //    extResult,
            //    expectedResult,
            //    _substrateRepository.Storage.Balances.ReservesAsync);
            Assert.Fail();
        }

        [Test]
        public async Task ReservesNull_ShouldReturnEmptyAsync()
        {
            await MockStorageCallNullWithInputAsync<
                SubstrateAccount,
                BoundedVecT6,
                BaseVec<ReserveData>>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Balances.ReservesAsync);
        }
    }
}
