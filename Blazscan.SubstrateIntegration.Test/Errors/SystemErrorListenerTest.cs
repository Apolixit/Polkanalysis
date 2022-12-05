
using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts;
using Blazscan.NetApiExt.Generated;
using Blazscan.NetApiExt.Generated.Model.frame_support.dispatch;
using Blazscan.SubstrateDecode.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateIntegration.Test.Errors
{
    public class SystemErrorListenerTest
    {
        private IEventListener _eventListener;
        private SubstrateClientExt _client;

        public SystemErrorListenerTest()
        {
            _client = new SubstrateClientExt(new Uri("ws://127.0.0.1:9944"), ChargeTransactionPayment.Default());

        }

        [OneTimeSetUp]
        public async Task ConnectAsync()
        {
            if (_client != null && !_client.IsConnected)
            {
                try
                {
                    await _client.ConnectAsync();
                    _eventListener = new EventListener(_client.MetaData);
                }
                catch (Exception _ex)
                {
                    Assert.Ignore("Substrate node is not currently running. All tests are ignore.");
                }
            }
        }

        [OneTimeTearDown]
        public void DisconnectAsync()
        {
            if (_client != null && _client.IsConnected)
            {
                _client.Dispose();
            }
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L497
        /// System
        /// Extrinsic failed
        /// Value module error (Money pot index:9 error: 0)
        /// Weight 100
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000000010309000000006400000000000000000000")]
        public async Task System_ExtrinsicFailed_MoneyPotErrorMaxOpen_ShouldBeParsed(string hex)
        {
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);
            var x = _client.MetaData.NodeMetadata;
            var expectedResult = EventResult.Create("System", "ExtrinsicFailed", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_ModuleError",
                    Title = "Unknown",
                    Value = new PalletErrorDto()
                    {
                        PalletName = "MoneyPot",
                        EventName = null,
                        Message = ""
                    }
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_DispatchInfo",
                    Title = "Unknown",
                    Value = new DispatchInfoDto()
                    {
                        Weight = 100,
                        Class = DispatchClass.Normal,
                        PaysFee = Pays.Yes
                    }
                }
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L497
        /// System
        /// Extrinsic failed
        /// Value module error (Money pot index:9 error: 5 (::DoesNotExists))
        /// Weight 100
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x000100000000010309050000006400000000000000000000")]
        public void System_ExtrinsicFailed_MoneyPotErrorDoesNotExists_ShouldBeParsed(string hex)
        {
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("System", "ExtrinsicFailed", new List<EventDetailsResult>()
            {
                new EventDetailsResult()
                {
                    ComponentName = "Component_ModuleError",
                    Title = "Unknown",
                    Value = new PalletErrorDto()
                    {
                        PalletName = "MoneyPot",
                        EventName= null,
                        Message = ""
                    }
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_DispatchInfo",
                    Title = "Unknown",
                    Value = new DispatchInfoDto()
                    {
                        Weight = 100,
                        Class = DispatchClass.Normal,
                        PaysFee = Pays.Yes
                    }
                },
            });

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
