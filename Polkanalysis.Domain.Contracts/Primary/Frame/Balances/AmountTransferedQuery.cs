using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Frame.Balances
{
    public class AmountTransferedQuery : IRequest<Result<double, ErrorResult>>
    {
        public SubstrateAccount? fromAccount { get; private set; }
        public SubstrateAccount? toAccount { get; private set; }
        public double? fromBlock { get; private set; }
        public double? toBlock { get; private set; }
        public DateTime? fromDate { get; private set; }
        public DateTime? toDate { get; private set; }

        private void UnsetParams()
        {
            fromBlock = null;
            toBlock = null;
            fromDate = null;
            toDate = null;
        }
        public AmountTransferedQuery From(DateTime dateMin)
        {
            UnsetParams();
            fromDate = dateMin;
            return this;
        }

        public AmountTransferedQuery From(double blockMin)
        {
            UnsetParams();
            fromBlock = blockMin;
            return this;
        }

        public AmountTransferedQuery Between(DateTime dateMin, DateTime dateMax)
        {
            UnsetParams();
            fromDate = dateMin;
            toDate = dateMax;
            return this;
        }

        public AmountTransferedQuery Between(double blockMin, double blockMax)
        {
            UnsetParams();
            fromBlock = blockMin;
            toBlock = blockMax;
            return this;
        }

        public AmountTransferedQuery FromAccount(SubstrateAccount account)
        {
            fromAccount = account;
            return this;
        }

        public AmountTransferedQuery ToAccount(SubstrateAccount account)
        {
            toAccount = account;
            return this;
        }
    }
}   
