using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using PolkadotRuntime = Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using SystemEvent = Polkanalysis.Domain.Contracts.Secondary.Pallet.TransactionPayment.Enums;

namespace Polkanalysis.Domain.Tests.Runtime.Event
{
    public class TransactionPaymentListenerTest : MainEventTest
    {
        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateRepository>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        /// <summary>
        /// https://github.com/paritytech/substrate/blob/master/frame/transaction-payment/src/lib.rs#L381
        /// TransactionFeePaid { who: T::AccountId, actual_fee: BalanceOf<T>, tip: BalanceOf<T> },
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00020000002000B72301EEEF1DCF828B9D361323ADBCE10333AC6A12D7390F5E34659C5DAF702BA1BC82090000000000000000000000000000000000000000000000000000000000")]
        public void TransactionPayment_TransactionFeePaid_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            PrerequisiteEvent(nodeResult);

            Assert.That(nodeResult.Module, Is.EqualTo(PolkadotRuntime.RuntimeEvent.TransactionPayment));
            Assert.That(nodeResult.Method, Is.EqualTo(SystemEvent.Event.TransactionFeePaid));

            //var expectedResult = EventResult.Create("TransactionPayment", "TransactionFeePaid", new List<EventDetailsResult>()
            //{
            //    new EventDetailsResult()
            //    {
            //        ComponentName = "Component_AccountId32",
            //        Title = "Account",
            //        Value = "5GrwvaEF5zXb26Fz9rcQpDWS57CtERHpNehXCPcNoHGKutQY"
            //    },
            //    new EventDetailsResult()
            //    {
            //        ComponentName = "Component_U128",
            //        Title = "Amount",
            //        Value = (uint)86298155
            //    },
            //    new EventDetailsResult()
            //    {
            //        ComponentName = "Component_U128",
            //        Title = "Amount",
            //        Value = (uint)0
            //    },
            //});
        }
    }
}
