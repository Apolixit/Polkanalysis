using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Mapper;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository.Pallet.System
{
    public class SystemEventsTest : PolkadotRepositoryMock
    {
        [Test]
        [TestCase("0x0002000000050848020D0712411B7EBF7F757F9F0D3F69F1660D636FB2C9811D81140CF84F561D70D8890F00000000000000000000000000")]
        public async Task Balances_Withdraw_Core_ShouldBeInstanciated(string hex)
        {
            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord();
            coreEvent.Create(hex);
            //var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent();
            //coreEvent.Create(hex);

            var automappedEvent = PolkadotMapping.Instance.Map<EventRecord>(coreEvent);
            var hexMapped = Utils.Bytes2HexString(automappedEvent.Encode());

            Assert.That(hex, Is.EqualTo(hexMapped));

            var mappedEvent = new EventRecord();
            mappedEvent.Create(hex);
            //var mappedEvent = new Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent();
            //mappedEvent.Create(hex);

            Assert.That(coreEvent.Bytes, Is.EqualTo(mappedEvent.Bytes));
        }

        [Test]
        [Ignore("TODO debug versionning")]
        [TestCase("0x00010000003500D2070000569443704D65208FC2B79AEE6D072934CC4C35C47734973D86E5C43C8A4F063FB48BD5B696D07CD6A332C559F58D3DA058E3B1779950E4B605B0E6EA77CFC75F89BA8D9CE29BDD68C0D4C78D9EDB829FE0BCD5500CE37903AF4922FB41265266A782F202F1A6C0D5BCF70687E5E993456FE19A81195E69214517006147A40FC867B0776114F47A2D018EC5EC4392C600BA6CAED2E1E2158257455CE6E472F7A44CDBC0B0A0984A4BBD48B4CCF7037D3F04496F97BC11EAC72141F5C738B1C775D5906B29CE3E662454B7BA8249821A4561BD40DECCB24DF76C3465AB69D68989699BDE26125E72C7A057E3C527420586D0AA7DAD118C178C7E14E449D5A5FB1E32283647AC87830D1B136BCE5FE3BAD5ACBA67ADD2A89F005497D93FAC9E5D20C1A4B661E74721D5A2FD537E155E22ADFF145024DE0FCAA9C41E14432AD70CCE89036BCAD8CD2E57D1FECCAD32E200C443AC8A71FEFC26D83DD392D91232870A422C0E2EC200019372F886C4DEE04D8B867D5810B5063D1813EE117125B5F2DF94B8C7BED6EBC8A6F1278357066AE8D4B2EABE55FCC59731D9263E0B082B394A0143AC2C25990C0661757261200667B110000000000466726F6E880153A6F3FCF48A3F15A27E5746E60EDA9A683BA674D040030A57BAB1D1A6AC6DD00005617572610101C659384F9967D8F8BBC584A6C1A59E7C96C3FFB4867E96CFE5987F00E1BDC27A98AF400D05BBDF2119C7F50AC06E125EEEBC6833D0AF10C9F5E871393FD1E18B030000001E00000000")]
        public async Task TestEvent_ShouldBeInstanciated(string hex)
        {
            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord();
            coreEvent.Create(hex);
            //var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent();
            //coreEvent.Create(hex);

            var automappedEvent = PolkadotMapping.Instance.Map<EventRecord>(coreEvent);
            var hexMapped = Utils.Bytes2HexString(automappedEvent.Encode());

            Assert.That(hex, Is.EqualTo(hexMapped));

            var mappedEvent = new EventRecord();
            mappedEvent.Create(hex);
            //var mappedEvent = new Polkanalysis.Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent();
            //mappedEvent.Create(hex);

            Assert.That(coreEvent.Bytes, Is.EqualTo(mappedEvent.Bytes));
        }

        [Test]
        public async Task BalanceWithdraw_ShouldBeMapped()
        {
            var account = new AccountId32();
            account.Create(Utils.GetPublicKeyFrom(MockAddress));

            var bt = new BaseTuple<AccountId32, U128>(account, new U128(10));

            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent();
            coreEvent.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Withdraw, bt);

            var expectedResult = new Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent();
            expectedResult.Create(Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Withdraw, new BaseTuple<SubstrateAccount, U128>(new SubstrateAccount(MockAddress), new U128(10)));

            var expectedResultFromSource = new Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent();
            expectedResultFromSource.Create(coreEvent.Encode());

            Assert.That(expectedResultFromSource.Bytes, Is.Not.Null);
            Assert.That(coreEvent.Bytes, Is.EqualTo(expectedResult.Bytes));
            Assert.That(expectedResultFromSource.Bytes, Is.EqualTo(expectedResult.Bytes));
        }

        [Test]
        public async Task BagListEnum_ShouldBeMapped()
        {
            var account = new AccountId32();
            account.Create(Utils.GetPublicKeyFrom(MockAddress));

            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.EnumEvent();
            var dataAssociated = new BaseTuple<AccountId32, U64, U64>(account, new U64(10), new U64(20));
            coreEvent.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_bags_list.pallet.Event.Rebagged, dataAssociated);

            var mapped = new Domain.Contracts.Secondary.Pallet.BagsList.Enums.EnumEvent();
            mapped.Create(coreEvent.Bytes);

            Assert.That(mapped, Is.Not.Null);
            Assert.IsInstanceOf<BaseTuple<SubstrateAccount, U64, U64>>(mapped.Value2);
        }
    }
}
