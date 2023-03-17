using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Org.BouncyCastle.Asn1.Sec;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Core.DispatchInfo;
using Substats.Domain.Contracts.Core.Display;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using Substats.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Substats.Domain.Contracts.Secondary.Pallet.SystemCore;
using Substats.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Substats.Polkadot.NetApiExt.Generated.Model.primitive_types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Tests.Polkadot.Repository.Pallet.System
{
    public class SystemStorageTests : PolkadotRepositoryMock
    {
        [Test]
        public async Task Account_ShouldWorkAsync()
        {
            var extResult = new Substats.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo();
            extResult.Create("0x0F0000000100000001000000000000000276075D0200000000000000000000000000000000000000000000000000000000E40B5402000000000000000000000000000000000000000000000000000000");

            var expectedResult = new AccountInfo();
            var accountData = new AccountData();
            accountData.Create(new U128(new BigInteger(10150704642)), new U128(new BigInteger(0)), new U128(new BigInteger(10000000000)), new U128(new BigInteger(0)));

            expectedResult.Create(new U32(15), new U32(1), new U32(1), new U32(0), accountData);

            await MockStorageCallWithInputAsync(new SubstrateAccount(MockAddress), extResult, expectedResult, _substrateRepository.Storage.System.AccountAsync);
        }

        [Test]
        public async Task AccountNull_ShouldWorkAsync()
        {
            _substrateRepository.AjunaClient.GetStorageAsync<
                Substats.Polkadot.NetApiExt.Generated.Model.frame_system.AccountInfo>(Arg.Any<string>(), Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            await MockStorageCallNullWithInputAsync(new SubstrateAccount(MockAddress), _substrateRepository.Storage.System.AccountAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task ExtrinsicCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.System.ExtrinsicCountAsync);
        }

        [Test]
        public async Task ExtrinsicCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.System.ExtrinsicCountAsync);
        }

        [Test]
        public async Task BlockWeight_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.PerDispatchClassT1();
            coreResult.Create(Utils.HexToByteArray("0x000000000750238E2C7400"));

            var expectedResult = new FrameSupportDispatchPerDispatchClassWeight(
                new Weight(new U64(0), new U64(0)),
                new Weight(new U64(0), new U64(0)),
                new Weight(new U64(498963718992), new U64(0)));

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.System.BlockWeightAsync);
        }

        [Test]
        public async Task BlockWeightNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<Substats.Polkadot.NetApiExt.Generated.Model.frame_support.dispatch.PerDispatchClassT1,
                FrameSupportDispatchPerDispatchClassWeight>(_substrateRepository.Storage.System.BlockWeightAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task AllExtrinsicsLen_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.System.AllExtrinsicsLenAsync);
        }

        [Test]
        public async Task AllExtrinsicsLenNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.System.AllExtrinsicsLenAsync);
        }

        [Test]
        public async Task BlockHash_ShouldWorkAsync()
        {
            var coreResult = new H256();
            coreResult.Create("0xB425DD3C71BE9C7F0B4D3E6D80FE18F72C5002F16DA9929FD3E1C46BAC45EF72");

            var expectedResult = new Hash("0xB425DD3C71BE9C7F0B4D3E6D80FE18F72C5002F16DA9929FD3E1C46BAC45EF72");

            await MockStorageCallWithInputAsync(new U32(10), coreResult, expectedResult, _substrateRepository.Storage.System.BlockHashAsync);
        }

        [Test]
        public async Task BlockHashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<U32, H256, Hash>(new U32(10), _substrateRepository.Storage.System.BlockHashAsync);
        }

        [Test]
        public async Task ExtrinsicData_ShouldWorkAsync()
        {
            var expectedResult = new BaseVec<U8>();
            await MockStorageCallWithInputAsync(new U32(1), expectedResult, _substrateRepository.Storage.System.ExtrinsicDataAsync);
        }

        [Test]
        public async Task ExtrinsicDataNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync(new U32(1), _substrateRepository.Storage.System.ExtrinsicDataAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task Number_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.System.NumberAsync);
        }

        [Test]
        public async Task NumberNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.System.NumberAsync);
        }

        [Test]
        public async Task ParentHash_ShouldWorkAsync()
        {
            var coreResult = new H256();
            coreResult.Create(Utils.HexToByteArray("0x3DFA8D1FDCE8D02C914C91BCE466BD0C01AA428E410F5FC3F16980AFE2D2B86C"));

            var expectedResult = new Hash("0x3DFA8D1FDCE8D02C914C91BCE466BD0C01AA428E410F5FC3F16980AFE2D2B86C");

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.System.ParentHashAsync);
        }

        [Test]
        public async Task ParentHashNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<H256, Hash>(_substrateRepository.Storage.System.ParentHashAsync);
        }

        [Test]
        public async Task Digest_ShouldWorkAsync()
        {
            var coreResult = new Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest();
            coreResult.Create("0x040642414245B501031A0000008609AC100000000076BA4192ED195FA9E3EF8D84158890DE8DB8C120A622E099FBEA285B3088CA11E572C85A8CA3697077E83CEF372C0650C9162F1530F02EBEF579A63736D79F0E28707BED1635DE7C2DA796D1551430DC46B47938C90CE84BBFA35C1F1F222803");

            var name = new Nameable("0x42414245");
            var vec = new BaseVec<U8>();
            vec.Create("0xB501031A0000008609AC100000000076BA4192ED195FA9E3EF8D84158890DE8DB8C120A622E099FBEA285B3088CA11E572C85A8CA3697077E83CEF372C0650C9162F1530F02EBEF579A63736D79F0E28707BED1635DE7C2DA796D1551430DC46B47938C90CE84BBFA35C1F1F222803");

            var preruntimeValue = new BaseTuple<Nameable, BaseVec<U8>>(name, vec);

            var enumDigest = new EnumDigestItem();
            enumDigest.Create(DigestItem.PreRuntime, preruntimeValue);

            var expectedResult = new Digest(new BaseVec<EnumDigestItem>(new EnumDigestItem[] { enumDigest }));
            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.System.DigestAsync);
        }

        [Test]
        public async Task DigestNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<Substats.Polkadot.NetApiExt.Generated.Model.sp_runtime.generic.digest.Digest, Digest>(_substrateRepository.Storage.System.DigestAsync);
        }

        [Test]
        public async Task Events_ShouldWorkAsync()
        {
            var coreResult = new BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>();

            coreResult.Create("0x0400000000000000A20EC53600020000");
            var expectedResult = new BaseVec<EventRecord>();

            var firstEvent = new EventRecord();
            var phase = new EnumPhase();
            phase.Create(Phase.ApplyExtrinsic, new U32(0));
            var topics = new BaseVec<Hash>();
            topics.Create(new byte[] { 0 });

            var runtimeEvent = new EnumRuntimeEvent();
            var systemEvent = new EnumEvent();
            var enumDispatchClass = new EnumDispatchClass();
            enumDispatchClass.Create(DispatchClass.Mandatory);

            var enumPays = new EnumPays();
            enumPays.Create(Pays.Yes);
            var dispatchInfo = new DispatchInfo(
                new Weight(new U64(229721000), new U64(0)), enumDispatchClass, enumPays);
            systemEvent.Create(Event.ExtrinsicSuccess, dispatchInfo);
            runtimeEvent.Create(RuntimeEvent.System, systemEvent);

            firstEvent.Create(phase, runtimeEvent, topics);
            expectedResult.Create(new EventRecord[] { firstEvent });

            await MockStorageCallAsync(coreResult, expectedResult, _substrateRepository.Storage.System.EventsAsync);
        }

        [Test]
        public async Task EventsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<
                BaseVec<Substats.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>,
                BaseVec<EventRecord>>(_substrateRepository.Storage.System.EventsAsync);
        }

        [Test]
        [TestCaseSource(nameof(U32TestCase))]
        public async Task EventCount_ShouldWorkAsync(U32 expectedResult)
        {
            await MockStorageCallAsync(expectedResult, _substrateRepository.Storage.System.EventCountAsync);
        }

        [Test]
        public async Task EventCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.System.EventCountAsync);
        }

        [Test]
        public async Task EventTopics_ShouldWorkAsync()
        {
            var param = new Hash("0x9067c4be52eb091d173f6a3172129da8e29a0bb5dd094e48959007918fcf1dbe");
            var expectedResult = new BaseVec<BaseTuple<U32, U32>>(new[]
            {
                new BaseTuple<U32, U32>(new U32(1), new U32(32))
            });

            await MockStorageCallWithInputAsync(param, expectedResult, _substrateRepository.Storage.System.EventTopicsAsync);
        }

        [Test]
        public async Task EventTopicsNull_ShouldWorkAsync()
        {
            await MockStorageCallNullWithInputAsync<Hash,
                BaseVec<BaseTuple<U32, U32>>,
                BaseVec<BaseTuple<U32, U32>>>(new Hash("0x9067c4be52eb091d173f6a3172129da8e29a0bb5dd094e48959007918fcf1dbe"), _substrateRepository.Storage.System.EventTopicsAsync);
        }

        [Test]
        public async Task LastRuntimeUpgrade_ShouldWorkAsync()
        {
            var resultCore = new Substats.Polkadot.NetApiExt.Generated.Model.frame_system.LastRuntimeUpgradeInfo();
            resultCore.Create("0x699220706F6C6B61646F74");

            var expectedResult = new LastRuntimeUpgradeInfo(new U32(9370), new Str("polkadot"));

            await MockStorageCallAsync(resultCore, expectedResult, _substrateRepository.Storage.System.LastRuntimeUpgradeAsync);
        }

        [Test]
        public async Task LastRuntimeUpgradeNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<Substats.Polkadot.NetApiExt.Generated.Model.frame_system.LastRuntimeUpgradeInfo, LastRuntimeUpgradeInfo>(_substrateRepository.Storage.System.LastRuntimeUpgradeAsync);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpgradedToU32RefCount_ShouldWorkAsync(bool expectedResult)
        {
            await MockStorageCallAsync(new Bool(expectedResult), _substrateRepository.Storage.System.UpgradedToU32RefCountAsync);
        }

        [Test]
        public async Task UpgradedToU32RefCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.System.UpgradedToU32RefCountAsync);
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task UpgradedToTripleRefCount_ShouldWorkAsync(bool expectedResult)
        {
            await MockStorageCallAsync(new Bool(expectedResult), _substrateRepository.Storage.System.UpgradedToTripleRefCountAsync);
        }

        [Test]
        public async Task UpgradedToTripleRefCountNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync(_substrateRepository.Storage.System.UpgradedToTripleRefCountAsync);
        }

        [Test]
        public async Task ExecutionPhase_ShouldWorkAsync()
        {
            var resultCore = new Substats.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase();
            resultCore.Create(Substats.Polkadot.NetApiExt.Generated.Model.frame_system.Phase.ApplyExtrinsic, new U32(1));

            var expectedResult = new EnumPhase();
            expectedResult.Create(Phase.ApplyExtrinsic, new U32(1));

            await MockStorageCallAsync(resultCore, expectedResult, _substrateRepository.Storage.System.ExecutionPhaseAsync);
        }

        [Test]
        public async Task ExecutionPhaseNull_ShouldWorkAsync()
        {
            await MockStorageCallNullAsync<Substats.Polkadot.NetApiExt.Generated.Model.frame_system.EnumPhase, EnumPhase>(_substrateRepository.Storage.System.ExecutionPhaseAsync);
        }
    }
}
