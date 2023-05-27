using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using AutoMapper;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Infrastructure.Tests.Polkadot.Repository;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;

namespace Polkanalysis.Infrastructure.Tests.Polkadot.Mapping
{
    public class PolkadotMappingTests : PolkadotRepositoryMock
    {
        [Test]
        [Ignore("Todo: debug")]
        public void PolkadotMapping_ShouldBeValid()
        {
            PolkadotMapping.Instance.ConfigurationProvider.AssertConfigurationIsValid();
        }

        //[Test]
        //public void CreateAccount_FromHash_ShouldSuceed()
        //{
        //    var subsrateAccount = new SubstrateAccount();
        //    Assert.That(substrateAccount, Is.Not.Null);
        //}

        [Test]
        public void SubstrateAccount_ToAccountId32_ShouldWork()
        {
            var substrateAccount = new SubstrateAccount(MockAddress);
            var accountId32 = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(substrateAccount);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void SubstrateAccount_FromHex_ToAccountId32_ShouldWork()
        {
            var substrateAccount = new SubstrateAccount();
            substrateAccount.Create("0x0000966D74F8027E07B43717B6876D97544FE0D71FACEF06ACC8382749AE944E");

            var accountId32 = new AccountId32();
            accountId32.Create("0x0000966D74F8027E07B43717B6876D97544FE0D71FACEF06ACC8382749AE944E");

            var accountId32_2 = PolkadotMapping.Instance.Map<SubstrateAccount, AccountId32>(substrateAccount);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
            Assert.That(substrateAccount.Encode(), Is.EqualTo(accountId32_2.Encode()));
            Assert.That(accountId32_2.Encode(), Is.EqualTo(accountId32_2.Value.Encode()));
        }

        [Test]
        public void AccountId32_ToSubstrateAccount_ShouldWork()
        {
            var accountId32 = new AccountId32();
            var publicKey = Utils.GetPublicKeyFrom(MockAddress);
            accountId32.Create(publicKey);

            var substrateAccount = PolkadotMapping.Instance.Map<AccountId32, SubstrateAccount>(accountId32);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void Perbill_ShouldWork()
        {
            var p1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill();
            p1.Create("0x00000000");

            var p2 = new Perbill(new U32(0));

            Assert.That(p2.Bytes, Is.EqualTo(PolkadotMapping.Instance.Map<Perbill>(p1).Bytes));
        }

        [Test]
        public void ParachainId_ShouldWork()
        {
            var s1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            s1.Create("0x01000000");

            var d1 = PolkadotMapping.Instance.Map<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Domain.Contracts.Core.Id>(s1);

            Assert.That(s1.Value.Bytes, Is.EqualTo(d1.Value.Bytes));

            // Reverse
            var s2 = new Domain.Contracts.Core.Id(1);

            var d2 = PolkadotMapping.Instance.Map<
                Domain.Contracts.Core.Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(s2);

            Assert.That(s2.Value.Bytes, Is.EqualTo(d2.Value.Bytes));
        }

        [Test]
        public void BaseVec_FromOneToAnother_ShouldWork()
        {
            var source = new BaseVec<SubstrateAccount>(new SubstrateAccount[] 
            { 
                new SubstrateAccount(MockAddress),
                new SubstrateAccount(MockAddress2)
            });

            // Convert BaseVec<SubstrateAccount> to BaseVec<AccountId32>
            BaseVec<AccountId32> dest = PolkadotMapping.Instance.Map<BaseVec<SubstrateAccount>, BaseVec<AccountId32>>(source);
            Assert.That(dest, Is.Not.Null);
        }

        //[Test]
        //public void PublicEd25519_ShouldWork()
        //{
        //    var publicEd = new PublicEd25519();
        //    Assert.Fail();
        //}

        //[Test]
        //public void PublicSr25519_ShouldWork()
        //{
        //    Assert.Fail();
        //}

        [Test]
        public void BaseCom_ShouldWork()
        {
            var targetValue = new U64(10);

            var baseCom = new BaseCom<U64>();
            baseCom.Create(new CompactInteger(targetValue));

            var u64 = new U64();
            u64.Create(baseCom.Value.Value.ToByteArray());

            var mapU64 = PolkadotMapping.Instance.Map<BaseCom<U64>, U64>(baseCom);

            Assert.That(targetValue.Bytes, Is.EqualTo(u64.Bytes));
            Assert.That(targetValue.Bytes, Is.EqualTo(mapU64.Bytes));
        }

        [Test]
        public void UnmappedEvent_ShouldThrowException()
        {
            var bondExtraCore = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.EnumBondExtra();
            bondExtraCore.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_nomination_pools.BondExtra.FreeBalance, new U128(10));

            Assert.Throws<AutoMapperMappingException>(() => PolkadotMapping.Instance.Map<EnumBondExtra>(bondExtraCore));
        }

        [Test]
        public void SubsrateAccount_AccountId32_ShouldBeEquivalent()
        {
            var ac = new AccountId32();
            ac.Create(Utils.GetPublicKeyFrom(MockAddress));

            var tp1 = new BaseTuple<AccountId32, U128>(ac, new U128(10));
            var tp2 = new BaseTuple<SubstrateAccount, U128>(new SubstrateAccount(MockAddress), new U128(10));

            var encoded = tp2.Encode();

            Assert.That(tp1.Encode(), Is.EqualTo(encoded));

            tp1 = new BaseTuple<AccountId32, U128>();
            tp1.Create(encoded);

            tp2 = new BaseTuple<SubstrateAccount, U128>();
            tp2.Create(encoded);

            Assert.That(tp1.Encode(), Is.EqualTo(tp2.Encode()));
        }
    }
}
