using Substats.Domain.Contracts.Dto.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Parachain
{
    public class CrowdloanDto
    {
        public uint CrowdloanId { get;}
        public required string DepositorAddress { get; set; }
        public string Verifier { get; set; } = string.Empty;

        public uint LeaseStart { get; set; }
        public DateTime LeaseDateStart { get; set; }
        public uint LeaseEnd { get; set; }
        public uint LeaseDateEnd { get; set; }

        public uint? WinningAuction { get; set; }
        public required IEnumerable<uint> ParticipatedAuctions { get; set; }

        public required BigInteger FundTarget { get; set; } = 0;
        public required BigInteger FundRaised { get; set; } = 0;

        public required BlockLightDto BlockStart { get; set; }
        public required BlockLightDto BlockEnd { get; set; }

        public object? CrowdloanStatus { get; set; }
    }
}
