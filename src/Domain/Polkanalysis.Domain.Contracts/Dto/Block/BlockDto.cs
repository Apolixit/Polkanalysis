﻿using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Common;
using Polkanalysis.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Core;

namespace Polkanalysis.Domain.Contracts.Dto.Block
{
    public class BlockDto
    {
        /// <summary>
        /// Block number from the beginning
        /// </summary>
        public required ulong Number { get; set; }

        public required DateDto Date { get; set; }

        /// <summary>
        /// Block status
        /// </summary>
        public required GlobalStatusDto.BlockStatusDto Status { get; set; }

        public required string Hash { get; set; }
        public string? ParentHash { get; set; }
        public required string StateRoot { get; set; }
        public required string ExtrinsicsRoot { get; set; }
        public UserAddressDto? Validator { get; set; }
        public uint SpecVersion { get; set; }

        /// <summary>
        /// Number of extrinsic linked to this block
        /// </summary>
        public uint NbExtrinsics { get; set; } = 0;

        /// <summary>
        /// Number of events linked to this block
        /// </summary>
        public uint NbEvents { get; set; } = 0;

        /// <summary>
        /// Number of logs linked to this block
        /// </summary>
        public uint NbLogs { get; set; } = 0;
    }
}
