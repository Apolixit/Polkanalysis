using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateDecode.Test.Event
{
    public class BalancesEventListenerTest
    {
        private readonly ISubstrateDecoding _substrateDecode;
        private readonly ISubstrateNodeRepository _substrateRepository;
        public BalancesEventListenerTest()
        {
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();
            _substrateRepository.Client.Returns(new NetApiExt.Generated.SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default()));
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(), 
                _substrateRepository,
                new PalletBuilder(_substrateRepository, Substitute.For<ICurrentMetaData>()));
        }

        [OneTimeSetUp]
        public async Task Connect()
        {
            if (!_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.ConnectAsync();
            }
        }

        [OneTimeTearDown]
        public async Task Disconnect()
        {
            if (_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.CloseAsync();
            }
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
            var nodeResult = _substrateDecode.DecodeEvent(hex);
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
            var nodeResult = _substrateDecode.DecodeEvent(hex);
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

        [TestCase("0x0500002444ED1EEDC416E067C35D986F29D28DC3EA9CB07168926DE1D4ACBBDC2EF6C50700386A3F41")]
        public void Balances_Transfer2_ShouldBeParsed(string hex)
        {
            //		currentValue.GetType().FullName	"Blazscan.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeCall"	string

            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);
        }


        [Test]
        [TestCase("0x00020000001306B109518212000000000000000000000000")]
        public void Treasury_Deposit_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
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
