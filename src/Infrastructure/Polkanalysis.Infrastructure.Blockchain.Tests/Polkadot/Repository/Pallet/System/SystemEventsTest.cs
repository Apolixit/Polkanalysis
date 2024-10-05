using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using NSubstitute;
using Microsoft.Extensions.Logging;
using EventExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.frame_system;
using AccountIdExt = Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.sp_core.crypto.AccountId32;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntimeParachain;
using Substrate.NET.Utils;
using Newtonsoft.Json.Linq;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.System
{
    public class SystemEventsTest : PolkadotMock
    {
        private IBlockchainMapping _blockchainMapping;

        [SetUp]
        public void SetupChild()
        {
            _blockchainMapping = new PolkadotMapping(Substitute.For<ILogger<PolkadotMapping>>());
        }

        [Test]
        [TestCase("0x0002000000050848020D0712411B7EBF7F757F9F0D3F69F1660D636FB2C9811D81140CF84F561D70D8890F00000000000000000000000000")]
        public void Balances_Withdraw_Core_ShouldBeInstanciated(string hex)
        {
            var coreEvent = new EventExt.EventRecord();
            coreEvent.Create(hex);

            var automappedEvent = _blockchainMapping.Map<EventExt.EventRecord, EventRecord>(coreEvent);
            
            var bytesMapped = automappedEvent.Encode();
            var hexMapped = Utils.Bytes2HexString(bytesMapped);

            var mappedEventHex = new EventRecord();
            mappedEventHex.Create(hexMapped);

            var mappedEventBytes = new EventRecord();
            mappedEventBytes.Create(bytesMapped);

            Assert.That(automappedEvent.Bytes, Is.EqualTo(mappedEventHex.Bytes));
            Assert.That(automappedEvent.Bytes, Is.EqualTo(mappedEventBytes.Bytes));
        }

        [Test]
        [TestCase("0x00010000003500D2070000569443704D65208FC2B79AEE6D072934CC4C35C47734973D86E5C43C8A4F063FB48BD5B696D07CD6A332C559F58D3DA058E3B1779950E4B605B0E6EA77CFC75F89BA8D9CE29BDD68C0D4C78D9EDB829FE0BCD5500CE37903AF4922FB41265266A782F202F1A6C0D5BCF70687E5E993456FE19A81195E69214517006147A40FC867B0776114F47A2D018EC5EC4392C600BA6CAED2E1E2158257455CE6E472F7A44CDBC0B0A0984A4BBD48B4CCF7037D3F04496F97BC11EAC72141F5C738B1C775D5906B29CE3E662454B7BA8249821A4561BD40DECCB24DF76C3465AB69D68989699BDE26125E72C7A057E3C527420586D0AA7DAD118C178C7E14E449D5A5FB1E32283647AC87830D1B136BCE5FE3BAD5ACBA67ADD2A89F005497D93FAC9E5D20C1A4B661E74721D5A2FD537E155E22ADFF145024DE0FCAA9C41E14432AD70CCE89036BCAD8CD2E57D1FECCAD32E200C443AC8A71FEFC26D83DD392D91232870A422C0E2EC200019372F886C4DEE04D8B867D5810B5063D1813EE117125B5F2DF94B8C7BED6EBC8A6F1278357066AE8D4B2EABE55FCC59731D9263E0B082B394A0143AC2C25990C0661757261200667B110000000000466726F6E880153A6F3FCF48A3F15A27E5746E60EDA9A683BA674D040030A57BAB1D1A6AC6DD00005617572610101C659384F9967D8F8BBC584A6C1A59E7C96C3FFB4867E96CFE5987F00E1BDC27A98AF400D05BBDF2119C7F50AC06E125EEEBC6833D0AF10C9F5E871393FD1E18B030000001E00000000")]
        public void TestParaInclusionEvent_ShouldBeInstanciated(string hex)
        {
            var coreEvent = new EventExt.EventRecord();
            coreEvent.Create(hex);

            var automappedEvent = _blockchainMapping.Map<EventExt.EventRecord, EventRecord>(coreEvent);

            var bytesMapped = automappedEvent.Encode();
            var hexMapped = Utils.Bytes2HexString(bytesMapped);

            var mappedEventHex = new EventRecord();
            mappedEventHex.Create(hexMapped);

            var mappedEventBytes = new EventRecord();
            mappedEventBytes.Create(bytesMapped);

            Assert.That(automappedEvent.Bytes, Is.EqualTo(mappedEventHex.Bytes));
            Assert.That(automappedEvent.Bytes, Is.EqualTo(mappedEventBytes.Bytes));

            Assert.That(automappedEvent.Event.Value!.GetEnumValue(), Is.EqualTo(RuntimeEvent.ParaInclusion));

            var subEnum = (Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.EnumEvent)automappedEvent.Event.Value!.GetValue2();
            Assert.That(subEnum.GetEnumValue(), Is.EqualTo(Contracts.Pallet.PolkadotRuntimeParachain.Inclusion.Enums.Event.CandidateBacked));

            var globalAnswer = subEnum.GetValue2().As<BaseTuple<CandidateReceipt, HeadData, CoreIndex, GroupIndex>>();
            var candidateReceipt = globalAnswer.Value[0].As<CandidateReceipt>();
            var headData = globalAnswer.Value[1].As<HeadData>();
            var coreIndex = globalAnswer.Value[2].As<CoreIndex>();
            var groupIndex = globalAnswer.Value[3].As<GroupIndex>();

            Assert.That(candidateReceipt.Descriptor.ParaId.ToHuman(), Is.EqualTo(2002));
            Assert.That(candidateReceipt.Descriptor.RelayParent.ToString(), Is.EqualTo("0x569443704D65208FC2B79AEE6D072934CC4C35C47734973D86E5C43C8A4F063F"));
            Assert.That(candidateReceipt.Descriptor.Collator.ToString(), Is.EqualTo("0xB48BD5B696D07CD6A332C559F58D3DA058E3B1779950E4B605B0E6EA77CFC75F"));
            Assert.That(candidateReceipt.Descriptor.ErasureRoot.ToString(), Is.EqualTo("0x67B0776114F47A2D018EC5EC4392C600BA6CAED2E1E2158257455CE6E472F7A4"));
            Assert.That(candidateReceipt.Descriptor.PersistedValidationDataHash.ToString(), Is.EqualTo("0x89BA8D9CE29BDD68C0D4C78D9EDB829FE0BCD5500CE37903AF4922FB41265266"));
            Assert.That(candidateReceipt.Descriptor.ParaHead.ToString(), Is.EqualTo("0x699BDE26125E72C7A057E3C527420586D0AA7DAD118C178C7E14E449D5A5FB1E"));
            Assert.That(candidateReceipt.Descriptor.PovHash.ToString(), Is.EqualTo("0xA782F202F1A6C0D5BCF70687E5E993456FE19A81195E69214517006147A40FC8"));
            Assert.That(Utils.Bytes2HexString(candidateReceipt.Descriptor.Signature.Value.ToBytes()), Is.EqualTo("0x4CDBC0B0A0984A4BBD48B4CCF7037D3F04496F97BC11EAC72141F5C738B1C775D5906B29CE3E662454B7BA8249821A4561BD40DECCB24DF76C3465AB69D68989"));
            Assert.That(candidateReceipt.Descriptor.ValidationCodeHash.ToString(), Is.EqualTo("0x32283647AC87830D1B136BCE5FE3BAD5ACBA67ADD2A89F005497D93FAC9E5D20"));
            Assert.That(candidateReceipt.CommitmentsHash.ToString(), Is.EqualTo("0xC1A4B661E74721D5A2FD537E155E22ADFF145024DE0FCAA9C41E14432AD70CCE"));
            
            Assert.That(Utils.Bytes2HexString(headData.Value.Bytes), Is.EqualTo("0x89036BCAD8CD2E57D1FECCAD32E200C443AC8A71FEFC26D83DD392D91232870A422C0E2EC200019372F886C4DEE04D8B867D5810B5063D1813EE117125B5F2DF94B8C7BED6EBC8A6F1278357066AE8D4B2EABE55FCC59731D9263E0B082B394A0143AC2C25990C0661757261200667B110000000000466726F6E880153A6F3FCF48A3F15A27E5746E60EDA9A683BA674D040030A57BAB1D1A6AC6DD00005617572610101C659384F9967D8F8BBC584A6C1A59E7C96C3FFB4867E96CFE5987F00E1BDC27A98AF400D05BBDF2119C7F50AC06E125EEEBC6833D0AF10C9F5E871393FD1E18B"));

            Assert.That(coreIndex.Value.Value, Is.EqualTo(3));
            Assert.That(groupIndex.Value.Value, Is.EqualTo(30));
        }

        [Test]
        public void BalanceWithdraw_ShouldBeMapped()
        {
            var account = new AccountIdExt();
            account.Create(Utils.GetPublicKeyFrom(MockAddress));

            var bt = new BaseTuple<AccountIdExt, U128>(account, new U128(10));

            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_balances.pallet.EnumEvent();
            coreEvent.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_balances.pallet.Event.Withdraw, bt);

            var expectedResult = new Contracts.Pallet.Balances.Enums.EnumEvent();
            expectedResult.Create(Contracts.Pallet.Balances.Enums.Event.Withdraw, new BaseTuple<SubstrateAccount, U128>(new SubstrateAccount(MockAddress), new U128(10)));

            var expectedResultFromSource = new Contracts.Pallet.Balances.Enums.EnumEvent();
            expectedResultFromSource.Create(coreEvent.Encode());

            Assert.That(expectedResultFromSource.Bytes, Is.Not.Null);
            Assert.That(coreEvent.Bytes, Is.EqualTo(expectedResult.Bytes));
            Assert.That(expectedResultFromSource.Bytes, Is.EqualTo(expectedResult.Bytes));
        }

        [Test]
        public void Event_BalanceWithdraw_ShouldBeEncodedAndDecodedCorrectly()
        {
            var account = new AccountIdExt();
            account.Create(Utils.GetPublicKeyFrom(MockAddress));

            var bt = new BaseTuple<AccountIdExt, U128>(account, new U128(10));

            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_balances.pallet.EnumEvent();
            coreEvent.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_balances.pallet.Event.Withdraw, bt);

            var enumRuntimeEvent = new Contracts.Core.Maybe<EnumRuntimeEvent>(coreEvent);

            var enumPhase = new EnumPhase();
            enumPhase.Create(Phase.ApplyExtrinsic, new U32(4));

            var topic = new BaseVec<Hash>(new Hash[0]);
            var ev = new EventRecord(enumPhase, enumRuntimeEvent, topic);

            var eventDecoded = new EventRecord();
            eventDecoded.Create(ev.Encode());

            Assert.That(ev.Phase.Value, Is.EqualTo(eventDecoded.Phase.Value));
            Assert.That(ev.Phase.Value2.As<U32>().Value, Is.EqualTo(eventDecoded.Phase.Value2.As<U32>().Value));

            Assert.That(ev.Event.Core.GetValue(), Is.EqualTo(eventDecoded.Event.Core.GetValue()));
            Assert.That(ev.Event.Core.GetValue2().As<BaseTuple<AccountIdExt, U128>>().Value[1].As<U128>().Value, 
                Is.EqualTo(eventDecoded.Event.Core.GetValue2().As<BaseTuple<AccountIdExt, U128>>().Value[1].As<U128>().Value));
        }

        [Test]
        public void BagListEnum_ShouldBeMapped()
        {
            var account = new AccountIdExt();
            account.Create(Utils.GetPublicKeyFrom(MockAddress));

            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_bags_list.pallet.EnumEvent();
            var dataAssociated = new BaseTuple<AccountIdExt, U64, U64>(account, new U64(10), new U64(20));
            coreEvent.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.v9370.pallet_bags_list.pallet.Event.Rebagged, dataAssociated);

            var mapped = new Contracts.Pallet.BagsList.Enums.EnumEvent();
            mapped.Create(coreEvent.Bytes);

            Assert.That(mapped, Is.Not.Null);
            Assert.That(mapped.Value2, Is.InstanceOf<BaseTuple<SubstrateAccount, U64, U64>>());
        }

        [Test]
        public void ExtrinsicFailed_ShouldBeMapped()
        {
            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.v1002006.polkadot_runtime.EnumRuntimeEvent();
            coreEvent.Create("0x00010708E283573F25380000");

            var res = _blockchainMapping.Map<Polkanalysis.Polkadot.NetApiExt.Generated.Model.v1002006.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>(coreEvent);

            Assert.That(res, Is.Not.Null);
            Assert.That(res.Value, Is.EqualTo(RuntimeEvent.System));
            Assert.That(res.Value2.GetValue(), Is.EqualTo(Event.ExtrinsicFailed));
        }
    }
}
