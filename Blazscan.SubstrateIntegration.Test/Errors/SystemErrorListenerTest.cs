
using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.Infrastructure.DirectAccess.Runtime;
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

            _substrateDecode = new SubstrateDecoding(
                new EventMapping(), 
                _substrateRepository,
                new PalletBuilder(_substrateRepository, new CurrentMetaData(_substrateRepository)));
        }
        

        [OneTimeSetUp]
        public async Task ConnectAsync()
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
        public async Task DisconnectAsync()
        {
            if (_substrateRepository.Client.IsConnected)
            {
                await _substrateRepository.Client.CloseAsync();
            }
        }

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
