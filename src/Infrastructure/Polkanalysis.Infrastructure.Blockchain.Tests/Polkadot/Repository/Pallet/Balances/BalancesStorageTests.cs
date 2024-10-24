using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Balances.Enums;
using System.Numerics;
using BalancesExtV9122 = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9122.pallet_balances;
using BalancesExtV9370 = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_balances;
using BalancesExtV9430 = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.pallet_balances.types;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.Display;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Balances
{
    public class BalancesStorageTests : PolkadotMock
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
        public async Task Account_9122_ShouldWorkAsync()
        {
            var account = new SubstrateAccount(MockAddress);

            var coreRes = new BalancesExtV9122.AccountData();
            coreRes.Create("0x00CA9A3B000000000000000000000000400D030000000000000000000000000020A1070000000000000000000000000020030000000000000000000000000000");

            var expectedResult = new AccountData();
            expectedResult.Create(new U128(1000000000), new U128(200000), new U128(500000), new U128(800));

            await MockStorageCallWithInputAsync
                (account, coreRes, expectedResult, _substrateRepository.Storage.Balances.AccountAsync, 9122);

            // Old properties have to be set
            Assert.That(expectedResult.FeeFrozen, Is.Not.Null);
            Assert.That(expectedResult.MiscFrozen, Is.Not.Null);

            Assert.That(coreRes.Free.Value, Is.EqualTo(expectedResult.Free.Value));
            Assert.That(coreRes.FeeFrozen.Value, Is.EqualTo(expectedResult.FeeFrozen.Value));
            Assert.That(coreRes.Reserved.Value, Is.EqualTo(expectedResult.Reserved.Value));
            Assert.That(coreRes.MiscFrozen.Value, Is.EqualTo(expectedResult.MiscFrozen.Value));

            // New properties has to be null
            Assert.That(expectedResult.Frozen, Is.Null);
            Assert.That(expectedResult.Flags, Is.Null);
        }

        [Test]
        public async Task Account_9370_ShouldWorkAsync()
        {
            var account = new SubstrateAccount(MockAddress);
            var coreRes = (Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_balances.AccountData)Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.pallet_balances.AccountDataBase.Create(Utils.HexToByteArray("0x00CA9A3B000000000000000000000000400D030000000000000000000000000020A1070000000000000000000000000020030000000000000000000000000000"), 9370);
            //var coreRes = new BalancesExtV9370.AccountData();
            //coreRes.Create("0x00CA9A3B000000000000000000000000400D030000000000000000000000000020A1070000000000000000000000000020030000000000000000000000000000");

            var expectedResult = new AccountData();
            expectedResult.Create(new U128(1000000000), new U128(200000), new U128(500000), new U128(800));

            await MockStorageCallWithInputAsync
                (account, coreRes, expectedResult, _substrateRepository.Storage.Balances.AccountAsync);
        }

        [Test]
        public async Task Account_9430_ShouldWorkAsync()
        {
            var account = new SubstrateAccount(MockAddress);

            var coreRes = new BalancesExtV9430.AccountData();
            coreRes.Create("0x00CA9A3B000000000000000000000000400D030000000000000000000000000020A10700000000000000000000000000C8000000000000000000000000000000");

            var expectedResult = new AccountData();
            expectedResult.Create(new U128(1000000000), new U128(200000), new U128(500000), new ExtraFlags(new U128(200)));

            await MockStorageCallWithInputAsync
                (account, coreRes, expectedResult, _substrateRepository.Storage.Balances.AccountAsync, 9430);

            // New properties has to be set
            Assert.That(expectedResult.Frozen, Is.Not.Null);
            Assert.That(expectedResult.Flags, Is.Not.Null);

            Assert.That(coreRes.Free.Value, Is.EqualTo(expectedResult.Free.Value));
            Assert.That(coreRes.Frozen.Value, Is.EqualTo(expectedResult.Frozen.Value));
            Assert.That(coreRes.Reserved.Value, Is.EqualTo(expectedResult.Reserved.Value));
            Assert.That(coreRes.Flags.Value.Value, Is.EqualTo(expectedResult.Flags.Value.Value));

            // Old properties have to be null
            Assert.That(expectedResult.FeeFrozen, Is.Null);
            Assert.That(expectedResult.MiscFrozen, Is.Null);
        }

        [Test]
        public async Task AccountNull_ShouldWorkAsync()
        {
            var testAccount = new SubstrateAccount(MockAddress);

            var res = await MockStorageCallNullWithInputAsync<SubstrateAccount,
                BalancesExtV9370.AccountData,
                AccountData>(testAccount, _substrateRepository.Storage.Balances.AccountAsync);
        }

        [Test]
        public async Task Locks_9122_ShouldWorkAsync()
        {
            var extResult = new BaseVec<BalancesExtV9122.BalanceLock>();
            extResult.Create("0x0464656D6F6372616300E40B5402000000000000000000000001");

            var reason = new EnumReasons();
            reason.Create(Reasons.Misc);

            var firstResult = new BalanceLock();
            var name = new NameableSize8();
            name.Create(extResult.Value[0].Id.Bytes);
            firstResult.Create(name,
                new U128(new BigInteger(10000000000)),
                reason);

            var expectedResult = new BaseVec<BalanceLock>(new BalanceLock[]
            {
                firstResult
            });

            var res = await MockStorageCallWithInputAsync(
                new SubstrateAccount(MockAddress),
                extResult,
                expectedResult,
                _substrateRepository.Storage.Balances.LocksAsync, 9122);

            var balanceLock = res.Value.FirstOrDefault();
            Assert.That(balanceLock, Is.Not.Null);
            Assert.That(balanceLock.Id.Display(), Is.EqualTo("democrac"));
            Assert.That(balanceLock.Reasons.Value, Is.EqualTo(Reasons.Misc));
            Assert.That(balanceLock.Amount.Value, Is.EqualTo(new BigInteger(10000000000)));
        }

        [Test]
        public async Task Locks_9430_ShouldWorkAsync()
        {
            var extResult = new BaseVec<BalancesExtV9430.BalanceLock>();
            extResult.Create("0x0464656D6F6372616300E40B5402000000000000000000000001");

            var reason = new EnumReasons();
            reason.Create(Reasons.Misc);

            var firstResult = new BalanceLock();
            var name = new NameableSize8();
            name.Create(extResult.Value[0].Id.Bytes);
            firstResult.Create(name,
                new U128(new BigInteger(10000000000)),
                reason);

            var expectedResult = new BaseVec<BalanceLock>(new BalanceLock[]
            {
                firstResult
            });

            var res = await MockStorageCallWithInputAsync(
                new SubstrateAccount(MockAddress),
                extResult,
                expectedResult,
                _substrateRepository.Storage.Balances.LocksAsync, 9430);

            var balanceLock = res.Value.FirstOrDefault();
            Assert.That(balanceLock, Is.Not.Null);
            Assert.That(balanceLock.Id.Display(), Is.EqualTo("democrac"));
            Assert.That(balanceLock.Reasons.Value, Is.EqualTo(Reasons.Misc));
            Assert.That(balanceLock.Amount.Value, Is.EqualTo(new BigInteger(10000000000)));
        }

        [Test]
        public async Task LocksNull_ShouldReturnEmptyAsync()
        {
            await MockStorageCallNullWithInputAsync<SubstrateAccount,
                BaseVec<BalancesExtV9370.BalanceLock>,
                BaseVec<BalanceLock>>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Balances.LocksAsync);
        }

        [Test]
        [Ignore("TODO Data")]
        public async Task Reserves_ShouldReturnEmptyAsync()
        {
            //var extResult = new BaseVec<BalancesExt.ReserveData>();
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
                BaseVec<BalancesExtV9370.ReserveData>,
                BaseVec<ReserveData>>(new SubstrateAccount(MockAddress), _substrateRepository.Storage.Balances.ReservesAsync);
        }
    }
}
