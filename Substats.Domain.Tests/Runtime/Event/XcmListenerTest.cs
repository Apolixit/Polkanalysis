using Ajuna.NetApi;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Runtime;
using Substats.Polkadot.NetApiExt.Generated.Model.polkadot_runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Tests.Runtime.Event
{
    public class XcmListenerTest : MainEventTest
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

        [Test]
        [TestCase("0x08000101C91F00010200C41C44BAD5EB2BD68F248485F13EFB760E9E0DFE30E2F2C067C7A5B0351C770900040A000700E87648170000000000")]
        public void Xcm_LimitedReserveTransferAssetsCall_ShouldBeParsed(string hex)
        {
            var call = new Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumCall();
            try
            {
                call.Create(Utils.HexToByteArray(hex));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"{nameof(call)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
            }
            var nodeResult = _substrateDecode.DecodeEvent(call);
            Assert.That(nodeResult, Is.Not.Null);

        }
    }
}
