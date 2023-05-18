using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Parachain.Auction
{
    public class AuctionDetailQuery : IRequest<Result<AuctionDto, ErrorResult>>
    {
        public uint AuctionId { get; set; }
    }
}
