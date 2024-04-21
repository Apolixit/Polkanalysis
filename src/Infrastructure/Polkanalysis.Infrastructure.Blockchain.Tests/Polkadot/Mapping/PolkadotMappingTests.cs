using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using AutoMapper;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.NominationPools.Enums;
using Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using NSubstitute;
using Microsoft.Extensions.Logging;
using SpCoreExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto;
using Polkanalysis.Domain.Contracts.Core.Public;
using BabeConsensusExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_consensus_babe;
using Substrate.NET.Utils;
using Substrate.NetApi.Model.Types;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Sp;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Mapping
{
    public class PolkadotMappingTests : PolkadotRepositoryMock
    {

        [Test, Ignore("TODO constructor check")]
        public void PolkadotMapping_ShouldBeValid()
        {
            _polkadotMapping.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [Test]
        public void SubstrateAccount_ToAccountId32_ShouldWork()
        {
            var substrateAccount = new SubstrateAccount(MockAddress);
            var accountId32 = _polkadotMapping.MapWithVersion<SubstrateAccount, SpCoreExt.AccountId32>(9370, substrateAccount);

            Assert.That(substrateAccount.ToStringAddress(), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void SubstrateAccount_FromHex_ToAccountId32_ShouldWork()
        {
            var substrateAccount = new SubstrateAccount();
            substrateAccount.Create("0x0000966D74F8027E07B43717B6876D97544FE0D71FACEF06ACC8382749AE944E");

            var accountId32 = new SpCoreExt.AccountId32();
            accountId32.Create("0x0000966D74F8027E07B43717B6876D97544FE0D71FACEF06ACC8382749AE944E");

            var accountId32_2 = _polkadotMapping.MapWithVersion<SubstrateAccount, SpCoreExt.AccountId32>(9370, substrateAccount);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
            Assert.That(substrateAccount.Encode(), Is.EqualTo(accountId32_2.Encode()));
            Assert.That(accountId32_2.Encode(), Is.EqualTo(accountId32_2.Value.Encode()));
        }

        [Test]
        public void AccountId32_ToSubstrateAccount_ShouldWork()
        {
            var accountId32 = new SpCoreExt.AccountId32();
            var publicKey = Utils.GetPublicKeyFrom(MockAddress);
            accountId32.Create(publicKey);

            var substrateAccount = _polkadotMapping.Map<SpCoreExt.AccountId32, SubstrateAccount>(accountId32);

            Assert.That(Utils.GetAddressFrom(substrateAccount.Bytes), Is.EqualTo(Utils.GetAddressFrom(accountId32.Value.Encode())));
        }

        [Test]
        public void PerbillCore_ToDomain_ShouldWork()
        {
            var p1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_arithmetic.per_things.Perbill();
            p1.Create("0x10000000");

            var p2 = new Perbill(new U32(16));

            var mappedPerbill = _polkadotMapping.Map<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_arithmetic.per_things.Perbill, Perbill>(p1);
            Assert.That(p2.Bytes, Is.EqualTo(mappedPerbill.Bytes));
        }

        [Test]
        public void PerbillDomain_ToCore_ShouldWork()
        {
            var perbillCore = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_arithmetic.per_things.Perbill();
            perbillCore.Create("0x10000000");

            var perbillDomain = new Perbill(new U32(16));

            var mappedPerbill = _polkadotMapping.MapWithVersion<Perbill, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_arithmetic.per_things.PerbillBase>(9370, perbillDomain);
            Assert.That(perbillDomain.Bytes, Is.EqualTo(mappedPerbill.Bytes));
        }

        [Test]
        [TestCase("0x82C3C901", 7500000)]
        //[TestCase("0x02C2EB0B", 50000000)]
        public void PerbillDomain_ToCore_RealUseCaseBug_ShouldWork(string hexValue, int value)
        {
            var perbillCore = new BaseCom<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v1001003.sp_arithmetic.per_things.Perbill>();
            perbillCore.Create(hexValue);

            var perbillDomain = new BaseCom<Perbill>(new CompactInteger((uint)value));

            var mappedPerbillDomain = _polkadotMapping.MapWithVersion<BaseCom<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v1001003.sp_arithmetic.per_things.Perbill>, BaseCom<Perbill>>(1001003, perbillCore);
            Assert.That(perbillCore.Bytes, Is.EqualTo(mappedPerbillDomain.Bytes));
            Assert.That(perbillCore.Bytes, Is.EqualTo(perbillDomain.Bytes));

            //var mappedPerbillCore = _polkadotMapping.MapWithVersion< BaseCom<Perbill>, BaseCom<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v1001003.sp_arithmetic.per_things.Perbill>>(1001003, perbillDomain);
            //Assert.That(perbillDomain.Bytes, Is.EqualTo(mappedPerbillCore.Bytes));
        }

        [Test]
        public void PublicCore_ToDomain_ShouldWork()
        {
            var core = new BabeConsensusExt.app.Public();
            core.Create(Utils.HexToByteArray(PublicSr25519_Signature_1));

            var expectedResult = _polkadotMapping.Map<BabeConsensusExt.app.Public, PublicSr25519>(core);

            Assert.That(expectedResult.Key, Is.EqualTo(KeyType.Sr25519));
            Assert.That(Utils.Bytes2HexString(expectedResult.Value.ToBytes()), Is.EqualTo(PublicSr25519_Signature_1));

        }

        [Test]
        public void PublicDomain_ToCore_ShouldWork()
        {
            var domainPublic = new PublicSr25519();
            domainPublic.Create(Utils.HexToByteArray(PublicSr25519_Signature_1));

            var corePublic = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.sr25519.Public();
            corePublic.Create(Utils.HexToByteArray(PublicSr25519_Signature_1));

            var expectedResult = _polkadotMapping.MapWithVersion<PublicSr25519, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_core.sr25519.PublicBase>(9370, domainPublic);

            Assert.That(corePublic.Encode(), Is.EqualTo(expectedResult.Encode()));
        }

        [Test]
        public void SlotCore_ToDomain_ShouldWork()
        {
            var numberResult = new U64(2);
            List<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase> slotBases = new();

            var coreSlotv9140 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.sp_consensus_slots.Slot();
            coreSlotv9140.Create(numberResult.Encode());

            var coreSlotv9230 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9230.sp_consensus_slots.Slot();
            coreSlotv9230.Create(numberResult.Encode());

            var coreSlotv9340 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9340.sp_consensus_slots.Slot();
            coreSlotv9340.Create(numberResult.Encode());

            var coreSlotv9370 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_consensus_slots.Slot();
            coreSlotv9370.Create(numberResult.Encode());

            var coreSlotv9430 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9430.sp_consensus_slots.Slot();
            coreSlotv9430.Create(numberResult.Encode());

            slotBases.Add(coreSlotv9140);
            slotBases.Add(coreSlotv9230);
            slotBases.Add(coreSlotv9340);
            slotBases.Add(coreSlotv9370);
            slotBases.Add(coreSlotv9430);

            foreach (var slot in slotBases)
            {
                var mapped = _polkadotMapping.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase, Slot>(slot);
                Assert.That(mapped.Value.Value, Is.EqualTo(new Slot(numberResult).Value.Value));
            }
        }

        [Test]
        public void SlotDomain_ToCore_ShouldWork()
        {
            var numberResult = new U64(2);
            var slotDomain = new Slot(numberResult);

            var coreSlotv9140 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9140.sp_consensus_slots.Slot();
            coreSlotv9140.Create(numberResult.Encode());

            var mapped = _polkadotMapping.MapWithVersion<Slot, Polkanalysis.Polkadot.NetApiExt.Generated.Model.vbase.sp_consensus_slots.SlotBase>(9140, slotDomain);
            Assert.That(mapped.Encode(), Is.EqualTo(coreSlotv9140.Encode()));
        }

        [Test]
        public void ParachainIdCore_ToDomain_ShouldWork()
        {
            var s1 = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id();
            s1.Create("0x01000000");

            var d1 = _polkadotMapping.Map<
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id,
                Id>(s1);

            Assert.That(s1.Value.Bytes, Is.EqualTo(d1.Value.Bytes));
        }

        [Test]
        public void ParachainIdDomain_ToCore_ShouldWork()
        {
            var s2 = new Id(1);

            var d2 = _polkadotMapping.MapWithVersion<
                Id,
                Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.polkadot_parachain.primitives.Id>(9370, s2);

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
            BaseVec<SpCoreExt.AccountId32> dest = _polkadotMapping.MapWithVersion<BaseVec<SubstrateAccount>, BaseVec<SpCoreExt.AccountId32>>(9370, source);
            Assert.That(source.Value.Select(x => x.Encode()), Is.EquivalentTo(dest.Value.Select(x => x.Encode())));
        }

        [Test]
        public void BaseCom_ShouldWork()
        {
            var targetValue = new U64(10);

            var baseCom = new BaseCom<U64>();
            baseCom.Create(new CompactInteger(targetValue));

            var u64 = new U64();
            u64.Create(baseCom.Value.Value.ToByteArray());

            var mapU64 = _polkadotMapping.Map<BaseCom<U64>, U64>(baseCom);

            Assert.That(targetValue.Bytes, Is.EqualTo(u64.Bytes));
            Assert.That(targetValue.Bytes, Is.EqualTo(mapU64.Bytes));
        }

        //[Test]
        //public void UnmappedEvent_ShouldThrowException()
        //{
        //    var bondExtraCore = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools.EnumBondExtra();
        //    bondExtraCore.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools.BondExtra.FreeBalance, new U128(10));

        //    Assert.Throws<AutoMapperMappingException>(() => _polkadotMapping.Map<
        //        Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_nomination_pools.EnumBondExtra, EnumBondExtra>(bondExtraCore));
        //}

        [Test]
        public void SubsrateAccount_AccountId32_ShouldBeEquivalent()
        {
            var ac = new SpCoreExt.AccountId32();
            ac.Create(Utils.GetPublicKeyFrom(MockAddress));

            var tp1 = new BaseTuple<SpCoreExt.AccountId32, U128>(ac, new U128(10));
            var tp2 = new BaseTuple<SubstrateAccount, U128>(new SubstrateAccount(MockAddress), new U128(10));

            var encoded = tp2.Encode();

            Assert.That(tp1.Encode(), Is.EqualTo(encoded));

            tp1 = new BaseTuple<SpCoreExt.AccountId32, U128>();
            tp1.Create(encoded);

            tp2 = new BaseTuple<SubstrateAccount, U128>();
            tp2.Create(encoded);

            Assert.That(tp1.Encode(), Is.EqualTo(tp2.Encode()));
        }

        [Test]
        public void BaseTupleMapping_ShouldWork()
        {
            var bt2 = new BaseTuple<U32, U32>(new U32(1), new U32(2));
            var bt3 = new BaseTuple<U32, U32, U32>(new U32(1), new U32(2), new U32(3));
            var bt4 = new BaseTuple<U32, U32, U32, U32>(new U32(1), new U32(2), new U32(3), new U32(4));
            var bt5 = new BaseTuple<U32, U32, U32, U32, U32>();
            bt5.Create(new U32(1), new U32(2), new U32(3), new U32(4), new U32(5));

            var mapBt2 = _polkadotMapping.Map<BaseTuple<U32, U32>>(bt2);
            var mapBt3 = _polkadotMapping.Map<BaseTuple<U32, U32, U32>>(bt3);
            var mapBt4 = _polkadotMapping.Map<BaseTuple<U32, U32, U32, U32>>(bt4);
            var mapBt5 = _polkadotMapping.Map<BaseTuple<U32, U32, U32, U32, U32>>(bt5);

            Assert.That(mapBt2, Is.Not.Null);
            Assert.That(mapBt3, Is.Not.Null);
            Assert.That(mapBt4, Is.Not.Null);
            Assert.That(mapBt5, Is.Not.Null);
        }
    }
}
