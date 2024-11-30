using MediatR;
using OperationResult;
using Polkanalysis.Domain.Contracts.Common;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Primary.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Primary.Explorer.Block
{
    public class BlockDetailsQuery : IRequest<Result<BlockDto, ErrorResult>>, ICached
    {
        public uint? BlockNumber { get; }
        public string? BlockHash { get; }

        public BlockDetailsQuery(uint blockNumber)
        {
            BlockNumber = blockNumber;
        }

        public BlockDetailsQuery(string blockHash)
        {
            BlockHash = blockHash;
        }

        [JsonIgnore]
        public bool IsSet => BlockNumber != null && BlockHash != null;

        public int CacheDurationInMinutes => Settings.Constants.Cache.LongCache;

        public string GenerateCacheKey()
            => $"{nameof(BlockDetailsQuery)}_{(BlockNumber is null ? BlockHash! : BlockNumber)}";
    }
}
