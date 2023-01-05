using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Model.polkadot_runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.Runtime.Event
{
    public class BalancesEventListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/balances/src/lib.rs#L469
        /// Balances pallet
        /// Withdraw
        /// Alice to Charlie
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000508D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D1ECE240500000000000000000000000000")]
        public void Balances_Withdraw_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Balances));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Withdraw));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/balances/src/lib.rs#L446
        /// 2/3
        /// Transfer balance (1000), Charlie to Ferdie (Ferdie new account)
        /// Pallet Balances
        /// Endowed
        /// Address
        /// 1000
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000005001CBD2D43530A44705AD088AF313E18F80B53EF16B36177CD4B77B846F2A5F07CE803000000000000000000000000000000")]
        public void Balances_Endowed_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Balances));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Endowed));

        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/balances/src/lib.rs#L451
        /// 3/3
        /// Transfer balance (1000), Charlie to Ferdie (Ferdie new account)
        /// Pallet Balances
        /// Transfer
        /// from ?
        /// to ?
        /// 1000
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x0001000000050290B5AB205C6974C9EA841BE688864633DC9CA8A357843EEACF2314649965FE221CBD2D43530A44705AD088AF313E18F80B53EF16B36177CD4B77B846F2A5F07CE803000000000000000000000000000000")]
        public void Balances_Transfer_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);

            //Charlie   SS58 Address:   5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y
            //Ferdie    SS58 Address:   5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            //Amount    1000

            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Balances));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Transfer));

        }

        [TestCase("0x000200000005076D6F646C70792F74727372790000000000000000000000000000000000000000840C540600000000000000000000000000")]
        public void Balances_Deposit_ShouldBeParsed(string hex)
        {
            //		currentValue.GetType().FullName	"Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall"	string

            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Balances));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.Deposit));
        }

        [TestCase("0x000200000005013DEF8519FB4F9A5FA7456D38B97C65B3463A8F0259B45B595AA4CDE5367179FA66A9800500000000000000000000000000")]
        public void Balances_DustLost_ShouldBeParsed(string hex)
        {
            //		currentValue.GetType().FullName	"Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall"	string

            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Balances));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_balances.pallet.Event.DustLost));
        }


        [Test]
        [TestCase("0x00020000001306B109518212000000000000000000000000")]
        public void Treasury_Deposit_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.Treasury));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_treasury.pallet.Event.Deposit));
        }
    }
}
