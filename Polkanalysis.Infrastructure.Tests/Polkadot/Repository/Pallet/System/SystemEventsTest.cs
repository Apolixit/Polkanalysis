using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Polkanalysis.Domain.Contracts.Core;
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
        [Ignore("Not ready")]
        public async Task BalanceEvents_ShouldBeMapped()
        {
            var coreEvent = new Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent();
            coreEvent.Create("0x05072C2A55B5E0D28CC772B47BB9B25981CBB69ECA73F7C3388FB6464E7D24BE470E387EE301000000000000000000000000");

            var mapped = SubstrateMapper.Instance.Map<Domain.Contracts.Secondary.Pallet.PolkadotRuntime.EnumRuntimeEvent>(coreEvent);

            var x = 1;
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
            var mapped = SubstrateMapper.Instance.Map<Domain.Contracts.Secondary.Pallet.Balances.Enums.EnumEvent>(coreEvent);

            Assert.That(mapped, Is.EqualTo(expectedResult));
        }
    }
}
