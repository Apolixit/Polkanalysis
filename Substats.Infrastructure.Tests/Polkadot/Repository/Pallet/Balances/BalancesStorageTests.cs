using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using Substats.Domain.Contracts.Secondary.Pallet.Balances.Enums;
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
        public async Task TotalIssuance_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).Returns(new U128().With(new BigInteger(10)));

            var res = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            Assert.That(res.Value, Is.EqualTo(new BigInteger(10)));
        }

        [Test]
        public async Task TotalIssuanceNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Balances.TotalIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.EqualTo(new U128()));
        }

        [Test]
        public async Task InactiveIssuance_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).Returns(new U128().With(new BigInteger(10)));

            var res = await _substrateRepository.Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            Assert.That(res.Value, Is.EqualTo(new BigInteger(10)));
        }

        [Test]
        public async Task InactiveIssuanceNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U128>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Balances.InactiveIssuanceAsync(CancellationToken.None);
            Assert.That(res, Is.EqualTo(new U128()));
        }

        [Test]
        public async Task Account_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task AccountNull_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount(MockAddress);

            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.AccountData>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Balances.AccountAsync(testAccount, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Free, Is.EqualTo(new U128().With(BigInteger.Zero)));
            Assert.That(res.Reserved, Is.EqualTo(new U128().With(BigInteger.Zero)));
            Assert.That(res.MiscFrozen, Is.EqualTo(new U128().With(BigInteger.Zero)));
            Assert.That(res.FeeFrozen, Is.EqualTo(new U128().With(BigInteger.Zero)));
        }

        [Test]
        public async Task Locks_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount(MockAddress);

            // Need to mock _client.GetStorageAsync !
            var mockLocks = new Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT3();
            mockLocks.Create("0x0464656D6F6372616300E40B5402000000000000000000000001");

            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT3>(Arg.Any<string>(), CancellationToken.None).Returns(mockLocks);


            var res = await _substrateRepository.Storage.Balances.LocksAsync(testAccount, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value, Is.Not.Null);

            var balanceLock = res.Value.FirstOrDefault();
            Assert.That(balanceLock, Is.Not.Null);
            Assert.That(balanceLock.Reasons.Value, Is.EqualTo(Reasons.Misc));
            Assert.That(balanceLock.Amount.Value, Is.EqualTo(new BigInteger(10000000000)));
        }

        [Test]
        public async Task LocksNull_ShouldReturnEmptyAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec.WeakBoundedVecT3>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var testAccount = new SubstrateAccount(MockAddress);
            var res = await _substrateRepository.Storage.Balances.LocksAsync(testAccount, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res, Is.EqualTo(new BaseVec<BalanceLock>()));
        }

        [Test]
        public async Task Reserves_ShouldReturnEmptyAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task ReservesNull_ShouldReturnEmptyAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec.BoundedVecT6>(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var testAccount = new SubstrateAccount(MockAddress);
            var res = await _substrateRepository.Storage.Balances.ReservesAsync(testAccount, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
            Assert.That(res, Is.EqualTo(new BaseVec<ReserveData>()));
        }
    }
}
