using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion
{
    public class CompareSpecVersionsQuery : IRequest<Result<CompareSpecVersionDto, ErrorResult>>
    {
        protected CompareSpecVersionsQuery() { }

        public static CompareSpecVersionsQuery FromSpecVersions(uint specVersionSource, uint specVersionTarget)
        {
            return new CompareSpecVersionsQuery()
            {
                SpecVersionSource = specVersionSource,
                SpecVersionTarget = specVersionTarget
            };
        }

        public static CompareSpecVersionsQuery FromBlockNumber(uint blockNumberSource, uint blockNumberTarget)
        {
            return new CompareSpecVersionsQuery()
            {
                BlockNumberSource = blockNumberSource,
                BlockNumberTarget = blockNumberTarget
            };
        }

        public static CompareSpecVersionsQuery FromBlockHash(string blockHashSource, string blockHashTarget)
        {
            return new CompareSpecVersionsQuery()
            {
                BlockHashSource = blockHashSource,
                BlockHashTarget = blockHashTarget
            };
        }

        public uint? SpecVersionSource { get; set; }
        public uint? SpecVersionTarget { get; set; }
        
        public uint? BlockNumberSource { get; set; }
        public uint? BlockNumberTarget { get; set; }

        public string? BlockHashSource { get; set; }
        public string? BlockHashTarget { get; set; }

    }
}
