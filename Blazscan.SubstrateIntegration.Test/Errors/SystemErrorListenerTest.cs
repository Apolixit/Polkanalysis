
using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.NetApiExt.Generated;
using Blazscan.NetApiExt.Generated.Model.frame_support.dispatch;
using Blazscan.SubstrateDecode;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.SubstrateIntegration.Test.Errors
{
    public class SystemErrorListenerTest
    {
        private readonly ISubstrateNodeRepository _substrateRepository;
        private readonly IBlockRepository _blockRepository;
        private ISubstrateDecoding _substrateDecode;

        public SystemErrorListenerTest()
        {
            _substrateRepository = Substitute.For<ISubstrateNodeRepository>();
            _substrateRepository.Client.Returns(new NetApiExt.Generated.SubstrateClientExt(new Uri("wss://rpc.polkadot.io"), ChargeTransactionPayment.Default()));
            _substrateDecode = new SubstrateDecode.SubstrateDecoding(Substitute.For<IMapping>(), Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>());
        }
        

        [OneTimeSetUp]
        public async Task Connect()
        {
            if (_substrateRepository.Client != null && !_substrateRepository.Client.IsConnected)
            {
                try
                {
                    await _substrateRepository.Client.ConnectAsync();
                    //_substrateDecode = new SubstrateDecode.SubstrateDecode(_substrateRepository.Client.MetaData);
                }
                catch (Exception _ex)
                {
                    Assert.Ignore("Substrate node is not currently running. All tests are ignore.");
                }
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
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L497
        /// System
        /// Extrinsic failed
        /// Value module error (Money pot index:9 error: 0)
        /// Weight 100
        /// </summary>
        /// <param name="hex"></param>
        //[Test]
        //[TestCase("0x000100000000010309000000006400000000000000000000")]
        //public async Task System_ExtrinsicFailed_MoneyPotErrorMaxOpen_ShouldBeParsed(string hex)
        //{
        //    var nodeResult = _eventListener.Read(hex);
        //    var result = EventResult.Create(nodeResult);
        //    Assert.IsNotNull(result);
        //    var x = _client.MetaData.NodeMetadata;
        //    var expectedResult = EventResult.Create("System", "ExtrinsicFailed", new List<EventDetailsResult>()
        //    {
        //        new EventDetailsResult()
        //        {
        //            ComponentName = "Component_ModuleError",
        //            Title = "Unknown",
        //            Value = new PalletErrorDto()
        //            {
        //                PalletName = "MoneyPot",
        //                EventName = null,
        //                Message = ""
        //            }
        //        },
        //        new EventDetailsResult()
        //        {
        //            ComponentName = "Component_DispatchInfo",
        //            Title = "Unknown",
        //            Value = new DispatchInfoDto()
        //            {
        //                Weight = 100,
        //                Class = DispatchClass.Normal,
        //                PaysFee = Pays.Yes
        //            }
        //        }
        //    });

        //    Assert.That(result, Is.EqualTo(expectedResult));
        //}

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/system/src/lib.rs#L497
        /// System
        /// Extrinsic failed
        /// Value module error (Money pot index:9 error: 5 (::DoesNotExists))
        /// Weight 100
        /// </summary>
        /// <param name="hex"></param>
        //[Test]
        //[TestCase("0x000100000000010309050000006400000000000000000000")]
        //public void System_ExtrinsicFailed_MoneyPotErrorDoesNotExists_ShouldBeParsed(string hex)
        //{
        //    var nodeResult = _eventListener.Read(hex);
        //    var result = EventResult.Create(nodeResult);
        //    Assert.IsNotNull(result);

        //    var expectedResult = EventResult.Create("System", "ExtrinsicFailed", new List<EventDetailsResult>()
        //    {
        //        new EventDetailsResult()
        //        {
        //            ComponentName = "Component_ModuleError",
        //            Title = "Unknown",
        //            Value = new PalletErrorDto()
        //            {
        //                PalletName = "MoneyPot",
        //                EventName= null,
        //                Message = ""
        //            }
        //        },
        //        new EventDetailsResult()
        //        {
        //            ComponentName = "Component_DispatchInfo",
        //            Title = "Unknown",
        //            Value = new DispatchInfoDto()
        //            {
        //                Weight = 100,
        //                Class = DispatchClass.Normal,
        //                PaysFee = Pays.Yes
        //            }
        //        },
        //    });

        //    Assert.That(result, Is.EqualTo(expectedResult));
        //}

        [Test]
        [TestCase("0x00020000000001030504000000D861040D00000000000000")]
        public void System_ExtrinsicFailed_Index_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
        }

        [Test]
        [TestCase("0x000100000000002861D5DD77000000020000")]
        public void RuntimeEvent_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var result = EventResult.Create(nodeResult);
        }
    }
}
