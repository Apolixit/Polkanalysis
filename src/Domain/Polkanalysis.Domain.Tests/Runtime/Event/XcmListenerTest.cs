using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class XcmListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventNodeMapping(),
                Substitute.For<ISubstrateService>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        //[Test]
        //[TestCase("0x08000101C91F00010200C41C44BAD5EB2BD68F248485F13EFB760E9E0DFE30E2F2C067C7A5B0351C770900040A000700E87648170000000000")]
        //public void Xcm_LimitedReserveTransferAssetsCall_ShouldBeParsed(string hex)
        //{
        //    var nodeResult = _substrateDecode.DecodeEvent(hex);
        //    PrerequisiteEvent(nodeResult);

        //    Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.XcmPallet));
        //    Assert.That(nodeResult.Method, Is.EqualTo(SystemEvent.Event.TransactionFeePaid));
        //    //var call = new Polkadot.NetApiExt.Generated.Model.pallet_xcm.pallet.EnumCall();
        //    //try
        //    //{
        //    //    call.Create(Utils.HexToByteArray(hex));
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw new InvalidOperationException($"{nameof(call)} has not been instanciate properly, maybe due to invalid hex parameter", ex);
        //    //}
        //    //var nodeResult = _substrateDecode.Decode(call);
        //    //Assert.That(nodeResult, Is.Not.Null);

        //}
    }
}
