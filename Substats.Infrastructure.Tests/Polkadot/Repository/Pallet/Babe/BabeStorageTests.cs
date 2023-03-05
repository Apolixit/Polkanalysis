﻿using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.Random;
using Substats.Domain.Contracts.Secondary.Pallet.Babe;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.bounded.weak_bounded_vec;
using Substats.Polkadot.NetApiExt.Generated.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Tests.Polkadot.Repository.Pallet.Babe
{
    public class BabeStorageTests : PolkadotRepositoryMock
    {
        [Test]
        [TestCaseSource(nameof(U64TestCase))]
        public async Task EpochIndex_ShouldWorkAsync(U64 epochIndexValue)
        {
            await MockStorageCallAsync(epochIndexValue, _substrateRepository.Storage.Babe.EpochIndexAsync);
        }

        [Test]
        public async Task EpochIndexNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.EpochIndexAsync);
        }

        [Test]
        public async Task Authorities_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<BaseTuple<PublicSr25519, U64>>(
                new BaseTuple<PublicSr25519, U64>[]
                {
                    new (new (PublicSr25519_Signature_U8Array(PublicSr25519_Signature_1)), new (1)),
                    new (new (PublicSr25519_Signature_U8Array(PublicSr25519_Signature_2)), new (1))
                }
            );

            var resCore = new WeakBoundedVecT2();
            resCore.Create("0x0866F60202B962C40E58FCF3481F5773DC178B9FE096F81511EAA4C7BAD20E612001000000000000009C40155989F6072E82CABA245D7DB7E40A60F866B403257976B89ABA6BE2B55B0100000000000000");
            _substrateRepository.AjunaClient.GetStorageAsync<WeakBoundedVecT2>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(resCore);

            await MockStorageCallAsync(resCore, expectedResult, _substrateRepository.Storage.Babe.AuthoritiesAsync);
        }

        [Test]
        public async Task AuthoritiesNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<WeakBoundedVecT2>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.AuthoritiesAsync);
        }

        [Test]
        [TestCaseSource(nameof(U64TestCase))]
        public async Task GenesisSlot_ShouldWorkAsync(U64 expectedOutput)
        {
            await MockStorageCallAsync(expectedOutput, _substrateRepository.Storage.Babe.GenesisSlotAsync);
        }

        [Test]
        public async Task GenesisSlotNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.GenesisSlotAsync);
        }

        [Test]
        [TestCaseSource(nameof(U64TestCase))]
        public async Task CurrentSlot_ShouldWorkAsync(U64 expectedOutput)
        {
            await MockStorageCallAsync(expectedOutput, _substrateRepository.Storage.Babe.CurrentSlotAsync);
        }

        [Test]
        public async Task CurrentSlotNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.CurrentSlotAsync);
        }

        [Test]
        public async Task Randomness_ShouldWorkAsync()
        {
            var extResult = new Arr32U8();
            extResult.Create(Utils.HexToByteArray("0x00"));

            var expectedResult = new Hexa();
            expectedResult.Create(Utils.HexToByteArray("0x00"));

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.RandomnessAsync);
        }

        [Test]
        public async Task RandomnessNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<Arr32U8>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.RandomnessAsync);
        }

        [Test]
        public async Task PendingEpochConfigChange_ShouldWorkAsync()
        {
            var extResult = new Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration();
            extResult.Create(Utils.HexToByteArray("0x0100000000000000040000000000000002"));

            var expectedResult = new BabeEpochConfiguration();
            expectedResult.C = new BaseTuple<U64, U64>(new U64(1), new U64(4));
            expectedResult.AllowedSlots = new EnumAllowedSlots();
            expectedResult.AllowedSlots.Create(AllowedSlots.PrimaryAndSecondaryVRFSlots);

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.EpochConfigAsync);
        }

        [Test]
        public async Task PendingEpochConfigChangeNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration>
                (Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.EpochConfigAsync);
        }
        
        [Test]
        public async Task NextRandomness_ShouldWorkAsync()
        {
            var extResult = new Arr32U8();
            extResult.Create(Utils.HexToByteArray("0x00"));

            var expectedResult = new Hexa();
            expectedResult.Create(Utils.HexToByteArray("0x00"));

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.NextRandomnessAsync);
        }

        [Test]
        public async Task NextRandomnessNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<Arr32U8>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.NextRandomnessAsync);
        }

        [Test]
        public async Task NextAuthorities_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<BaseTuple<PublicSr25519, U64>>(
                new BaseTuple<PublicSr25519, U64>[]
                {
                    new (new (PublicSr25519_Signature_U8Array(PublicSr25519_Signature_1)), new (1)),
                    new (new (PublicSr25519_Signature_U8Array(PublicSr25519_Signature_2)), new (1))
                }
            );

            var resCore = new WeakBoundedVecT2();
            resCore.Create("0x0866F60202B962C40E58FCF3481F5773DC178B9FE096F81511EAA4C7BAD20E612001000000000000009C40155989F6072E82CABA245D7DB7E40A60F866B403257976B89ABA6BE2B55B0100000000000000");
            _substrateRepository.AjunaClient.GetStorageAsync<WeakBoundedVecT2>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(resCore);

            await MockStorageCallAsync(resCore, expectedResult, _substrateRepository.Storage.Babe.NextAuthoritiesAsync);
        }

        [Test]
        public async Task NextAuthoritiesNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<WeakBoundedVecT2>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.NextAuthoritiesAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task SegmentIndex_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Babe.SegmentIndexAsync);
        }

        [Test]
        public async Task SegmentIndexNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.SegmentIndexAsync);
        }

        [Test]
        public async Task UnderConstruction_ShouldWorkAsync()
        {
            var extResult = new BoundedVecT5();
            extResult.Create(Utils.HexToByteArray("0x089A24025AD716349176BD6F75EDBC971D6BB5D970BB2A89A490AFA0A93709F75898B0603D0E55EA7E16E86DE8D6037C39B4F3E68EB18C6ABE4A8D5E837AEC2DFC"));

            var expectedResult = new BaseVec<Hexa>(new Hexa[]
            {
                new Hexa("0x9a24025ad716349176bd6f75edbc971d6bb5d970bb2a89a490afa0a93709f758"),
                new Hexa("0x98b0603d0e55ea7e16e86de8d6037c39b4f3e68eb18c6abe4a8d5e837aec2dfc"),
            });

            await MockStorageCallWithInputAsync(
                new U32(0), 
                extResult, 
                expectedResult, 
                _substrateRepository.Storage.Babe.UnderConstructionAsync);
        }

        [Test]
        public async Task UnderConstructionNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<BoundedVecT5>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullWithInputAsync(new U32(0), _substrateRepository.Storage.Babe.UnderConstructionAsync);
        }

        [Test]
        public async Task Initialized_ShouldWorkAsync()
        {
            //var extResult = new BaseOpt<Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumPreDigest>();

            //var expectedResult = new EnumPreDigest();
            //var expectedEnumData = new PrimaryPreDigest();

            //expectedResult.Create(PreDigest.Primary, expectedEnumData);
            //await MockStorageCallAsync(_substrateRepository.Storage.Babe.InitializedAsync);
        }

        [Test]
        public async Task InitializedNull_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task AuthorVrfRandomness_ShouldWorkAsync()
        {
            //var res = await _substrateRepository.Storage.Babe.AuthorVrfRandomnessAsync(CancellationToken.None);
            //Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task AuthorVrfRandomnessNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<BaseOpt<Arr32U8>>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Babe.AuthorVrfRandomnessAsync(CancellationToken.None);
            Assert.That(res, Is.EqualTo(new BaseOpt<Hexa>()));
        }

        [Test]
        public async Task EpochStart_ShouldWorkAsync()
        {
            var expectedResult = new BaseTuple<U32, U32>(new U32(10), new U32(20));
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.Babe.EpochStartAsync);
        }

        [Test]
        public async Task EpochStartNull_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task Lateness_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task LatenessNull_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task EpochConfig_ShouldWorkAsync()
        {
            //var res = await _substrateRepository.Storage.Babe.EpochConfigAsync(CancellationToken.None);
            //Assert.That(res, Is.Not.Null);
        }

        [Test]
        public async Task EpochConfigNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.BabeEpochConfiguration>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var res = await _substrateRepository.Storage.Babe.EpochConfigAsync(CancellationToken.None);
            Assert.That(res, Is.EqualTo(new BabeEpochConfiguration()));
        }

        [Test]
        public async Task NextEpochConfig_ShouldWorkAsync()
        {
            Assert.Fail();
        }

        [Test]
        public async Task NextEpochConfigNull_ShouldWorkAsync()
        {
            Assert.Fail();
        }
    }
}