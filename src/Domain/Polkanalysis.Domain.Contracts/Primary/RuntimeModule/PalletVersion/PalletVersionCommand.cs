using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion
{
    public class PalletVersionCommand : IRequest<Result<bool, ErrorResult>>
    {
        public int PalletId { get; set; }
        public int PalletVersion { get; set; }
        public uint BlockStart { get; set; }
        public uint? BlockEnd { get; set; }
    }
}
