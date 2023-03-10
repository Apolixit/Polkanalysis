using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using Substats.Domain.Contracts.Secondary.Pallet.Balances.Enums;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Tests.Polkadot.Repository.Pallet.Balances
{
    public class BalancesStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task TotalIssuance_ShouldWorkAsync(U128 input)
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).Returns(new U128().With(new BigInteger(10)));

            //var res = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            //Assert.That(res.Value, Is.EqualTo(new BigInteger(10)));

            await MockStorageCallAsync(input, _substrateRepository.Storage.Balances.TotalIssuanceAsync);
        }

        [Test]
        public async Task TotalIssuanceNull_ShouldWorkAsync()
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            //var res = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            //Assert.That(res, Is.EqualTo(new U128()));

            await MockStorageCallNullAsync(_substrateRepository.Storage.Balances.TotalIssuanceAsync);
        }

        [Test]
        [TestCaseSource(nameof(U128TestCase))]
        public async Task InactiveIssuance_ShouldWorkAsync(U128 input)
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).Returns(new U128().With(new BigInteger(10)));

            //var res = await _substrateRepository.Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            //Assert.That(res.Value, Is.EqualTo(new BigInteger(10)));

            await MockStorageCallAsync(input, _substrateRepository.Storage.Balances.InactiveIssuanceAsync);
        }

        [Test]
        public async Task InactiveIssuanceNull_ShouldWorkAsync()
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            //var res = await _substrateRepository.Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            //Assert.That(res, Is.EqualTo(new U128()));

            await MockStorageCallNullAsync(_substrateRepository.Storage.Balances.InactiveIssuanceAsync);
        }

        [Test]
        public async Task Account_ShouldWorkAsync()
        {
            var account = new SubstrateAccount(MockAddress);

            var coreRes = new Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData();
            coreRes.Create("0x00CA9A3B000000000000000000000000400D030000000000000000000000000020A1070000000000000000000000000020030000000000000000000000000000");

            var expectedResult = new AccountData()
            {
                Free = new U128(1000000000),
                FeeFrozen = new U128(800),
                MiscFrozen = new U128(500000),
                Reserved = new U128(200000),
            };

            await MockStorageCallWithInputAsync
                (account, coreRes, expectedResult, _substrateRepository.Storage.Balances.AccountAsync);
        }

        [Test]
        public async Task AccountNull_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount(MockAddress);

            //_substrateRepository.AjunaClient.GetStorageAsync<
            //    Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            //var res = await _substrateRepository.Storage.Balances.AccountAsync(testAccount, CancellationToken.None);

            var res = await MockStorageCallNullWithInputAsync(testAccount, _substrateRepository.Storage.Balances.AccountAsync);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Free, Is.EqualTo(new U128()));
            Assert.That(res.Reserved, Is.EqualTo(new U128()));
            Assert.That(res.MiscFrozen, Is.EqualTo(new U128()));
            Assert.That(res.FeeFrozen, Is.EqualTo(new U128()));
        }

        [Test]
        public async Task Locks_ShouldWorkAsync()
        {
            var extResult = new WeakBoundedVecT3();
            extResult.Create("0x0464656D6F6372616300E40B5402000000000000000000000001");

            //_substrateRepository.AjunaClient.GetStorageAsync<
            //    Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT3>(Arg.Any<string>(), CancellationToken.None).Returns(mockLocks);


            //var res = await _substrateRepository.Storage.Balances.LocksAsync(testAccount, CancellationToken.None);

            //Assert.That(res, Is.Not.Null);
            //Assert.That(res.Value, Is.Not.Null);

            var reason = new EnumReasons();
            reason.Create(Reasons.Misc);

            var firstResult = new BalanceLock(
                new Domain.Contracts.Core.Display.Nameable(extResult.Value.Value[0].Id),
                new U128(new BigInteger(10000000000)), 
                reason
            );
            //firstResult.Id = new Domain.Contracts.Core.Display.Nameable(extResult.Value.Value[0].Id);
            //firstResult.Amount = new U128(new BigInteger(10000000000));
            
            //firstResult.Reasons = reason;

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
            //_substrateRepository.AjunaClient.GetStorageAsync<
            //    Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT3>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            //var testAccount = new SubstrateAccount(MockAddress);
            //var res = await _substrateRepository.Storage.Balances.LocksAsync(testAccount, CancellationToken.None);

            //Assert.That(res, Is.Not.Null);
            //Assert.That(res, Is.EqualTo(new BaseVec<BalanceLock>()));

            await MockStorageCallNullWithInputAsync(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Balances.LocksAsync);
        }

        [Test]
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
            //_substrateRepository.AjunaClient.GetStorageAsync<
            //    Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            //var testAccount = new SubstrateAccount(MockAddress);
            //var res = await _substrateRepository.Storage.Balances.ReservesAsync(testAccount, CancellationToken.None);

            //Assert.That(res, Is.Not.Null);
            //Assert.That(res, Is.EqualTo(new BaseVec<ReserveData>()));

            await MockStorageCallNullWithInputAsync(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Balances.ReservesAsync);
        }
    }
}
