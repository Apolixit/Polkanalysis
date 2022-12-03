
using Blazscan.SubstrateDecode.Event;

namespace Blazscan.SubstrateDecode.Test.Event
{
    public class TransactionPaymentListenerTest
    {
        private readonly IEventListener _eventListener;

        public TransactionPaymentListenerTest()
        {
            _eventListener = new EventListener();
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
            var nodeResult = _eventListener.Read(hex);
            var result = EventResult.Create(nodeResult);
            Assert.IsNotNull(result);

            var expectedResult = EventResult.Create("TransactionPayment", "TransactionFeePaid", new List<EventDetailsResult>()
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
                    Value = (uint)86298155
                },
                new EventDetailsResult()
                {
                    ComponentName = "Component_U128",
                    Title = "Amount",
                    Value = (uint)0
                },
            });
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
