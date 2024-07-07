using Polkanalysis.Domain.Contracts.Dto.User;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.Block
{
    public class BlockLightDto
    {
        public required uint Number { get; set; }
        public required Hash Hash { get; set; }
        public required DateTime BlockDate { get; set; }
        public required string When { get; set; }
        public required GlobalStatusDto.BlockStatusDto Status { get; set; }
        public uint NbExtrinsics { get; set; } = 0;
        public uint NbEvents { get; set; } = 0;
        public uint NbLogs { get; set; } = 0;
        public string? ValidatorAddress { get; set; }
        public UserIdentityDto? ValidatorIdentity { get; set; }
    }
}
