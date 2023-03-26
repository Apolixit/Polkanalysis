using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Core;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Infrastructure.Tests.Polkadot.Repository;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;

namespace Substats.Infrastructure.Tests.Polkadot.Mapping
{
    public class PolkadotMappingTests : PolkadotRepositoryMock
    {
        [Test]
        [Ignore("Todo: debug")]
        public void PolkadotMapping_ShouldBeValid()
        {
            SubstrateMapper.Instance.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void SubstrateAccount_ToAccountId32_ShouldWork()
        {
            var substrateAccount = new SubstrateAccount(MockAddress);
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(substrateAccount);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void AccountId32_ToSubstrateAccount_ShouldWork()
        {
            var accountId32 = new AccountId32();
            var publicKey = Utils.GetPublicKeyFrom(MockAddress);
            accountId32.Create(publicKey);

            var substrateAccount = SubstrateMapper.Instance.Map<AccountId32, SubstrateAccount>(accountId32);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void Perbill_ShouldWork()
        {
            var p1 = new Substats.Polkadot.NetApiExt.Generated.Model.sp_arithmetic.per_things.Perbill();
            p1.Create("0x00000000");

            var p2 = new Perbill(new U32(0));

            Assert.That(p2, Is.EqualTo(SubstrateMapper.Instance.Map<Perbill>(p1)));
        }

        [Test]
        public void ParachainId_ShouldWork()
        {
            var s1 = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            s1.Create("0x01000000");

            var d1 = SubstrateMapper.Instance.Map<
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id,
                Domain.Contracts.Core.Id>(s1);

            Assert.That(s1.Value, Is.EqualTo(d1.Value));

            // Reverse
            var s2 = new Domain.Contracts.Core.Id(1);

            var d2 = SubstrateMapper.Instance.Map<
                Domain.Contracts.Core.Id,
                Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>(s2);

            Assert.That(s2.Value, Is.EqualTo(d2.Value));
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
            BaseVec<AccountId32> dest = SubstrateMapper.Instance.Map<BaseVec<SubstrateAccount>, BaseVec<AccountId32>>(source);
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

            var mapU64 = SubstrateMapper.Instance.Map<BaseCom<U64>, U64>(baseCom);

            Assert.That(targetValue, Is.EqualTo(u64));
            Assert.That(targetValue, Is.EqualTo(mapU64));
            
            
        }
    }
}
