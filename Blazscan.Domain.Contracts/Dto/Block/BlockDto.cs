﻿using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Dto.Block
{
    public class BlockDto
    {
        /// <summary>
        /// Block number from the beginning
        /// </summary>
        public required ulong Number { get; set; }

        /// <summary>
        /// Exact date when block has been started
        /// </summary>
        public required DateTime Date { get; set; }

        /// <summary>
        /// Time from now
        /// </summary>
        public required TimeSpan When { get; set; }

        /// <summary>
        /// Block status
        /// </summary>
        public required StatusDto Status { get; set; }

        public required Hash Hash { get; set; }
        public Hash? ParentHash { get; set; }
        public required Hash StateRoot { get; set; }
        public required Hash ExtrinsicsRoot { get; set; }
        public ValidatorDto? Validator { get; set; }
        public int SpecVersion { get; set; }

        /// <summary>
        /// Number of extrinsic linked to this block
        /// </summary>
        public int NbExtrinsics { get; set; } = 0;

        /// <summary>
        /// Number of events linked to this block
        /// </summary>
        public int NbEvents { get; set; } = 0;

        /// <summary>
        /// Number of logs linked to this block
        /// </summary>
        public int NbLogs { get; set; } = 0;
    }
}
