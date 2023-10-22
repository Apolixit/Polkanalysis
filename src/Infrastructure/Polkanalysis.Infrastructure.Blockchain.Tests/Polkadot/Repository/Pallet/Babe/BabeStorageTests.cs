using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Core.Public;
using Polkanalysis.Domain.Contracts.Core.Random;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Babe.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Types.Base;
using BabeConsensusExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_consensus_babe;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Sp;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.Babe
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
            //_substrateRepository.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

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

            var resCore = new BaseVec<BaseTuple<BabeConsensusExt.app.Public, U64>>();
            resCore.Create("0x0866F60202B962C40E58FCF3481F5773DC178B9FE096F81511EAA4C7BAD20E612001000000000000009C40155989F6072E82CABA245D7DB7E40A60F866B403257976B89ABA6BE2B55B0100000000000000");
            _substrateRepository.AjunaClient.GetStorageAsync<BaseVec<BaseTuple<BabeConsensusExt.app.Public, U64>>>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(resCore);

            await MockStorageCallAsync(resCore, expectedResult, _substrateRepository.Storage.Babe.AuthoritiesAsync);
        }

        [Test]
        public async Task AuthoritiesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<BaseTuple<BabeConsensusExt.app.Public, U64>>, BaseVec<BaseTuple<PublicSr25519, U64>>>(_substrateRepository.Storage.Babe.AuthoritiesAsync);
        }

        [Test]
        [TestCaseSource(nameof(U64TestCase))]
        public async Task GenesisSlot_ShouldWorkAsync(Slot expectedOutput)
        {
            await MockStorageCallAsync(expectedOutput, _substrateRepository.Storage.Babe.GenesisSlotAsync);
        }

        [Test]
        public async Task GenesisSlotNull_ShouldWorkAsync()
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.GenesisSlotAsync);
        }

        [Test]
        [TestCaseSource(nameof(U64TestCase))]
        public async Task CurrentSlot_ShouldWorkAsync(Slot expectedOutput)
        {
            await MockStorageCallAsync(expectedOutput, _substrateRepository.Storage.Babe.CurrentSlotAsync);
        }

        [Test]
        public async Task CurrentSlotNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.CurrentSlotAsync);
        }

        [Test]
        public async Task Randomness_ShouldWorkAsync()
        {
            var extResult = new Arr32U8();
            extResult.Create(Utils.HexToByteArray("0xACD9FF8E35EDDED5289E9D4C150A0765B166A469918034651A60B1B33664BF7E"));

            var expectedResult = new Hexa();
            expectedResult.Create(Utils.HexToByteArray("0xACD9FF8E35EDDED5289E9D4C150A0765B166A469918034651A60B1B33664BF7E"));

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.RandomnessAsync);
        }

        [Test]
        public async Task RandomnessNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<Arr32U8, Hexa>(_substrateRepository.Storage.Babe.RandomnessAsync);
        }

        [Test]
        public async Task PendingEpochConfigChange_ShouldWorkAsync()
        {
            var extAllowedSlot = new BabeConsensusExt.EnumAllowedSlots();
            extAllowedSlot.Create(BabeConsensusExt.AllowedSlots.PrimarySlots);
            var extResult = new BabeConsensusExt.digests.EnumNextConfigDescriptor();
            extResult.Create(
                BabeConsensusExt.digests.NextConfigDescriptor.V1,
                new BaseTuple<BaseTuple<U64, U64>, BabeConsensusExt.EnumAllowedSlots>(
                    new BaseTuple<U64, U64>(new U64(2), new U64(4)), extAllowedSlot));

            var allowedSlot = new EnumAllowedSlots();
            allowedSlot.Create(AllowedSlots.PrimarySlots);
            var expectedResult = new EnumNextConfigDescriptor();
            expectedResult.Create(NextConfigDescriptor.V1,
                new BaseTuple<BaseTuple<U64, U64>, EnumAllowedSlots>(
                    new BaseTuple<U64, U64>(new U64(2), new U64(4)), allowedSlot));

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.PendingEpochConfigChangeAsync);
        }

        [Test]
        public async Task PendingEpochConfigChangeNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BabeConsensusExt.digests.EnumNextConfigDescriptor,
                EnumNextConfigDescriptor>(_substrateRepository.Storage.Babe.PendingEpochConfigChangeAsync);
        }

        [Test]
        public async Task NextRandomness_ShouldWorkAsync()
        {
            var extResult = new Arr32U8();
            extResult.Create(Utils.HexToByteArray("0x8E605504927B5C616B25F2C7E6A8FD8F73DCDBD8D2F3A9FEF470B2B253A667C4"));

            var expectedResult = new Hexa();
            expectedResult.Create(Utils.HexToByteArray("0x8E605504927B5C616B25F2C7E6A8FD8F73DCDBD8D2F3A9FEF470B2B253A667C4"));

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.NextRandomnessAsync);
        }

        [Test]
        public async Task NextRandomnessNull_ShouldWorkAsync()
        {
            //_substrateRepository.AjunaClient.GetStorageAsync<Arr32U8>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync<Arr32U8, Hexa>(_substrateRepository.Storage.Babe.NextRandomnessAsync);
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

            var resCore = new BaseVec<BaseTuple<BabeConsensusExt.app.Public, U64>>();
            resCore.Create("0x0866F60202B962C40E58FCF3481F5773DC178B9FE096F81511EAA4C7BAD20E612001000000000000009C40155989F6072E82CABA245D7DB7E40A60F866B403257976B89ABA6BE2B55B0100000000000000");
            _substrateRepository.AjunaClient.GetStorageAsync<BaseVec<BaseTuple<BabeConsensusExt.app.Public, U64>>>
                (Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).Returns(resCore);

            await MockStorageCallAsync(resCore, expectedResult, _substrateRepository.Storage.Babe.NextAuthoritiesAsync);
        }

        [Test]
        public async Task NextAuthoritiesNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BaseVec<BaseTuple<BabeConsensusExt.app.Public, U64>>,
                BaseVec<BaseTuple<PublicSr25519, U64>>>(_substrateRepository.Storage.Babe.NextAuthoritiesAsync);
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
            //_substrateRepository.AjunaClient.GetStorageAsync<U32>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.SegmentIndexAsync);
        }

        [Test]
        public async Task UnderConstruction_ShouldWorkAsync()
        {
            var extResult = new BaseVec<Arr32U8>();
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
            await MockStorageCallNullWithInputAsync<U32, BaseVec<Arr32U8>, BaseVec<Hexa>>(new U32(0), _substrateRepository.Storage.Babe.UnderConstructionAsync);
        }

        [Test]
        [Ignore("Find a good test case")]
        public async Task Initialized_ShouldWorkAsync()
        {
            //var enumPreDigestExt = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumPreDigest();
            //enumPreDigestExt.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.PreDigest.Primary, )
            //var extResult = new BaseOpt<Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_consensus_babe.digests.EnumPreDigest>();
            //extResult.Create();
            //var expectedResult = new EnumPreDigest();
            //var expectedEnumData = new PrimaryPreDigest();

            //expectedResult.Create(PreDigest.Primary, expectedEnumData);
            //await MockStorageCallAsync(_substrateRepository.Storage.Babe.InitializedAsync);
        }

        [Test]
        public async Task InitializedNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseOpt<BabeConsensusExt.digests.EnumPreDigest>,
                BaseOpt<EnumPreDigest>>(_substrateRepository.Storage.Babe.InitializedAsync);
        }

        [Test]
        public async Task AuthorVrfRandomness_ShouldWorkAsync()
        {
            var resCore = new BaseOpt<Arr32U8>();
            var extSubRes = new Arr32U8();
            extSubRes.Create(Utils.HexToByteArray("0xD95389AB38F371D4B960865243B283E995BA3E199F95FDB65E481ECB8A1C951A"));
            resCore.Create(extSubRes);

            var expectedResult = new BaseOpt<Hexa>(new Hexa("0xD95389AB38F371D4B960865243B283E995BA3E199F95FDB65E481ECB8A1C951A"));

            await MockStorageCallAsync(resCore, expectedResult, _substrateRepository.Storage.Babe.AuthorVrfRandomnessAsync);
        }

        [Test]
        public async Task AuthorVrfRandomnessNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BaseOpt<Arr32U8>, BaseOpt<Hexa>>(_substrateRepository.Storage.Babe.AuthorVrfRandomnessAsync);
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
            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.EpochStartAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task Lateness_ShouldWorkAsync(U32 param)
        {
            await MockStorageCallAsync(param, _substrateRepository.Storage.Babe.LatenessAsync);
        }

        [Test]
        public async Task LatenessNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.Babe.LatenessAsync);
        }

        [Test]
        public async Task EpochConfig_ShouldWorkAsync()
        {

            var extResult = new BabeConsensusExt.BabeEpochConfiguration();
            extResult.Create("0x0100000000000000040000000000000002");

            var expectedResult = new BabeEpochConfiguration();
            var allowedSlots = new EnumAllowedSlots();
            allowedSlots.Create(AllowedSlots.PrimaryAndSecondaryVRFSlots);
            expectedResult.Create(new BaseTuple<U64, U64>(new U64(1), new U64(4)), allowedSlots);

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.EpochConfigAsync);
        }

        [Test]
        public async Task EpochConfigNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BabeConsensusExt.BabeEpochConfiguration, BabeEpochConfiguration>(_substrateRepository.Storage.Babe.EpochConfigAsync);
        }

        [Test]
        public async Task NextEpochConfig_ShouldWorkAsync()
        {
            var extResult = new BabeConsensusExt.BabeEpochConfiguration();
            extResult.Create("0x0100000000000000040000000000000002");

            var expectedResult = new BabeEpochConfiguration();
            var allowedSlots = new EnumAllowedSlots();
            allowedSlots.Create(AllowedSlots.PrimaryAndSecondaryVRFSlots);
            expectedResult.Create(new BaseTuple<U64, U64>(new U64(1), new U64(4)), allowedSlots);

            await MockStorageCallAsync(extResult, expectedResult, _substrateRepository.Storage.Babe.NextEpochConfigAsync);
        }

        [Test]
        public async Task NextEpochConfigNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<BabeConsensusExt.BabeEpochConfiguration, BabeEpochConfiguration>(_substrateRepository.Storage.Babe.NextEpochConfigAsync);
        }
    }
}
