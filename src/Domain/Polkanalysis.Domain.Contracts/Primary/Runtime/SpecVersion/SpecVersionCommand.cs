using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Dto.Price;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion
{
    public class SpecVersionCommand : IRequest<Result<bool, ErrorResult>>
    {
        public SpecVersionCommand(uint specVersion, uint blockStart, Hash blockHash)
        {
            SpecVersion = specVersion;
            BlockStart = blockStart;
            BlockHash = blockHash;
        }

        public uint SpecVersion { get; set; }

        /// <summary>
        /// Only use for logging purpose
        /// </summary>
        public uint BlockStart { get; set; }
        public Hash BlockHash { get; set; }
    }
}
