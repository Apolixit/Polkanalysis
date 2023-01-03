
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Polkadot.NetApiExt.Generated.Model.polkadot_runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;

namespace Blazscan.Domain.Tests.Runtime.Event
{
    public class TransactionPaymentListenerTest : MainEventTest
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
        /// https://github.com/paritytech/substrate/blob/master/frame/transaction-payment/src/lib.rs#L381
        /// TransactionFeePaid { who: T::AccountId, actual_fee: BalanceOf<T>, tip: BalanceOf<T> },
        /// </summary>
        /// <param name="hex"></param>
        [Test]
        [TestCase("0x00010000000700D43593C715FDD31C61141ABD04A99FD6822C8558854CCDE39A5684E7A56DA27D2BCE24050000000000000000000000000000000000000000000000000000000000")]
        public void TransactionPayment_TransactionFeePaid_ShouldBeParsed(string hex)
        {
            var nodeResult = _substrateDecode.DecodeEvent(hex);
            var eventRes = PrerequisiteEvent(nodeResult);

            Assert.That(eventRes.runtimeEvent.HumanData, Is.EqualTo(RuntimeEvent.TransactionPayment));
            Assert.That(eventRes.palletEvent.HumanData, Is.EqualTo(Polkadot.NetApiExt.Generated.Model.pallet_transaction_payment.pallet.Event.TransactionFeePaid));

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
