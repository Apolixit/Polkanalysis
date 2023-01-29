﻿using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Dto.Block;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Runtime;

namespace Substats.Domain.Contracts.Dto.Extrinsic
{
    public class ExtrinsicDto
    {
        public required string Number { get; set; }
        public required BlockLightDto Block { get; set; }
        public IList<BlockLightDto>? Lifetime { get; set; }
        public required Hash Hash { get; set; }
        public required string PalletName { get; set; }
        public required string PalletCall { get; set; }
        public AccountDto? Caller { get; set; }
        public double EstimatedFees { get; set; }
        public double RealFees { get; set; }
        public int Nonce { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// Decoded extrinsic displayed as a tree
        /// </summary>
        public required INode Decoded { get; set; }

    }
}