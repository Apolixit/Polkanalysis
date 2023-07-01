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
    public class TokenPriceCommand : IRequest<Result<bool, ErrorResult>>
    {
        public required TokenPriceDto TokenPrice { get; set; }
        public required string BlockchainName { get; set; }
    }
}
