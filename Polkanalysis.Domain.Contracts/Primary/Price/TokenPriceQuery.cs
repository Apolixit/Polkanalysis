using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Price
{
    public class TokenPriceQuery : IRequest<Result<TokenPriceDto, ErrorResult>>
    {
        /// <summary>
        /// CoinId from Coingecko ("polkadot")
        /// </summary>
        public required string CoinId { get; set; }

        /// <summary>
        /// Date of the snapshot. Only work with days (not hours / minutes)
        /// If not set, get today's date
        /// </summary>
        public DateTime Date { get; set; } = DateTime.Now;

    }
}
