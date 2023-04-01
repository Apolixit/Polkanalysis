using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Polkanalysis.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Tests.Polkadot.Repository.Pallet.System
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
        [Ignore("Not ready")]
        public async Task BalanceWithdraw_ShouldBeMapped()
        {
            var account = new AccountId32();
            account.Create(Utils.GetPublicKeyFrom(MockAddress));

            var bt = new BaseTuple<AccountId32, U128>(account, new U128(10));

            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.EnumEvent();
            coreEvent.Create(Polkanalysis.Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Withdraw, bt);

            var expectedResult = new Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent();
            expectedResult.Create(Domain.Contracts.Secondary.Pallet.Balances.Enums.Event.Withdraw, new BaseTuple<SubstrateAccount, U128>(new SubstrateAccount(MockAddress), new U128(10)));

            var t = (BaseEnumType)coreEvent;
            var mapped = PolkadotMapping.Instance.Map<Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>(coreEvent);

            Assert.That(mapped, Is.EqualTo(expectedResult));
        }
    }
}
