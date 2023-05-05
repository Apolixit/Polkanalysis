using FluentValidation;
using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Core;
using Polkanalysis.Domain.Contracts.Dto.Stats;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Contracts.Primary.Statistics
{
    public class GlobalStatsQuery : IRequest<Result<GlobalStatsDto, ErrorResult>>
    {
        public string? fromAccount { get; set; }
        public string? toAccount { get; set; }
        public uint? fromBlock { get; set; }
        public uint? toBlock { get; set; }
        public DateTime? fromDate { get; set; }
        public DateTime? toDate { get; set; }

        private void UnsetParams()
        {
            fromBlock = null;
            toBlock = null;
            fromDate = null;
            toDate = null;
        }
        public GlobalStatsQuery From(DateTime dateMin)
        {
            UnsetParams();
            fromDate = dateMin;
            return this;
        }

        public GlobalStatsQuery From(uint blockMin)
        {
            UnsetParams();
            fromBlock = blockMin;
            return this;
        }

        public GlobalStatsQuery Between(DateTime dateMin, DateTime dateMax)
        {
            UnsetParams();
            fromDate = dateMin;
            toDate = dateMax;
            return this;
        }

        public GlobalStatsQuery Between(uint blockMin, uint blockMax)
        {
            UnsetParams();
            fromBlock = blockMin;
            toBlock = blockMax;
            return this;
        }

        public GlobalStatsQuery FromAccount(string account)
        {
            fromAccount = account;
            return this;
        }

        public GlobalStatsQuery ToAccount(string account)
        {
            toAccount = account;
            return this;
        }
    }
}
