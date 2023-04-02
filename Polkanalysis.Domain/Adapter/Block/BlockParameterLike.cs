using Ajuna.NetApi.Model.Types.Base;
using Org.BouncyCastle.Crypto;
using Polkanalysis.Domain.Contracts.Adapter.Block;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Adapter.Block
{
    public class BlockParameterLike : IBlockParameterLike
    {
        private uint? _blockNumber;
        private Hash? _blockHash;
        private readonly ISubstrateRepository _substrateService;

        public BlockParameterLike(ISubstrateRepository substrateService)
        {
            _substrateService = substrateService;
        }

        public BlockParameterLike FromBlockNumber(uint blockNumber)
        {
            _blockNumber = blockNumber;
            return this;
        }

        public BlockParameterLike FromBlockHash(Hash blockHash)
        {
            _blockHash = blockHash;
            return this;
        }

        public BlockParameterLike FromBlockHash(string blockAddress)
        {
            _blockHash = new Hash(blockAddress);
            return this;
        }

        private void EnsureDataIsSet()
        {
            if (_blockHash == null && _blockNumber == null)
                throw new InvalidOperationException("No block has been set");
        }

        public async Task<Hash> ToBlockHashAsync()
        {
            EnsureDataIsSet();

            if (_blockHash != null)
                return _blockHash;

            var blockNumber = new BlockNumber();
            blockNumber.Create(_blockNumber!.Value);
            var blockHash = await _substrateService.Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None);

            if (blockHash == null)
                throw new BlockException($"{nameof(blockHash)} from given blockId (={_blockNumber}) is null");

            return blockHash;
        }

        public async Task<BlockNumber> ToBlockNumberAsync()
        {
            EnsureDataIsSet();

            if (_blockNumber != null)
            {
                var blockNumber1 = new BlockNumber();
                blockNumber1.Create(_blockNumber!.Value);
                return blockNumber1;
            }

            var blockHash = await _substrateService.Rpc.Chain.GetBlockAsync(_blockHash, CancellationToken.None);

            var blockNumber = new BlockNumber();
            
            if (blockHash == null)
                throw new BlockException($"{nameof(blockNumber)} from given blockId (={blockHash}) is null");

            blockNumber.Create((uint)blockHash.Block.Header.Number.Value);

            return blockNumber;
        }
    }
}
