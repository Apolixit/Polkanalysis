﻿using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Runtime;

namespace Polkanalysis.Domain.Contracts.Dto.Extrinsic
{
    public class ExtrinsicDto
    {
        public required string ExtrinsicId { get; set; }
        public required uint Index { get; set; }
        public required uint BlockNumber { get; set; }
        public IList<BlockLightDto>? Lifetime { get; set; }
        public required string Hash { get; set; }
        public required string CallEventName { get; set; }
        public required string PalletName { get; set; }
        public AccountDto? Caller { get; set; }
        public double EstimatedFees { get; set; }
        public double RealFees { get; set; }
        public int Nonce { get; set; }
        public bool Status { get; set; }

        /// <summary>
        /// Decoded extrinsic displayed as a tree
        /// </summary>
        //public required INode Decoded { get; set; }

    }
}
