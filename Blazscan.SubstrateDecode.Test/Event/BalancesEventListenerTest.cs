using Blazscan.SubstrateDecode.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Test.Event
{
    public class BalancesEventListenerTest
    {
        private readonly IEventListener _eventListener;

        public BalancesEventListenerTest()
        {
            _eventListener = new EventListener();
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
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);

            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("Balances", "Withdraw", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_AccountId32",
                    Title = "Account",
                    Value = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_U128",
                    Title = "Amount",
                    Value = (uint)86298142
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
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
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);

            Assert.IsNotNull(result);

            //Ferdie SS58 Address: 5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("Balances", "Endowed", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_AccountId32",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_U128",
                    Title = "Amount",
                    Value = (uint)1000
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
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
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            //Charlie   SS58 Address:   5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y
            //Ferdie    SS58 Address:   5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL
            var expectedResult = EventResult.Create("Balances", "Transfer", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_AccountId32",
                    Title = "Account",
                    Value = "5FLSigC9HGRKVhB9FiEo4Y3koPsNmBmLJbpXg2mp1hXcS59Y"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_AccountId32",
                    Title = "Account",
                    Value = "5CiPPseXPECbkjWCa6MnjNokrgYjMqmKndv2rSnekmSK2DjL"
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_U128",
                    Title = "Amount",
                    Value = (uint)1000
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
