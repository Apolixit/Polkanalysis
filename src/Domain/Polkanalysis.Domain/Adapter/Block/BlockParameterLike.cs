using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Secondary;
using Substrate.NET.Utils;
using Polkanalysis.Infrastructure.Blockchain.Contracts;

namespace Polkanalysis.Domain.Adapter.Block
{
    public class BlockParameterLike
    {
        private uint? _blockNumber;
        private Hash? _blockHash;

        public static implicit operator BlockParameterLike(uint blockNumber) => new BlockParameterLike(blockNumber);
        public static explicit operator uint(BlockParameterLike blockNumber) => blockNumber._blockNumber ?? throw new NullReferenceException();

        public static implicit operator BlockParameterLike(Hash blockHash) => new BlockParameterLike(blockHash);
        public static explicit operator Hash(BlockParameterLike blockHash) => blockHash._blockHash ?? throw new NullReferenceException();

        public static implicit operator BlockParameterLike(string blockHash) => new BlockParameterLike(blockHash);
        public static explicit operator string(BlockParameterLike blockHash) => blockHash._blockHash?.Value ?? throw new NullReferenceException();

        public BlockParameterLike(uint blockNumber)
        {
            _blockNumber = blockNumber;
        }

        public BlockParameterLike(Hash blockHash)
        {
            _blockHash = blockHash;
        }

        public BlockParameterLike(string blockAddress)
        {
            if (!SubstrateCheck.CheckHash(blockAddress)) throw new BlockException("Invalid block format");
            _blockHash = new Hash(blockAddress);
        }

        public async Task<bool> EnsureBlockNumberIsValidAsync(ISubstrateService substrateService)
        {
            var lastHeader = await substrateService.Rpc.Chain.GetHeaderAsync();

            if (lastHeader.Number.Value < _blockNumber)
                return false;

            return true;
        }

        private async Task EnsureDataIsSetAsync(ISubstrateService substrateService)
        {
            if (_blockHash == null && _blockNumber == null)
                throw new InvalidOperationException("No block has been set");

            if(_blockNumber != null)
            {
                var isBlockValid = await EnsureBlockNumberIsValidAsync(substrateService);
                if (!isBlockValid)
                    throw new BlockException($"Block number {_blockNumber} has not been produced yet");
            }
        }

        private void Reset()
        {
            _blockNumber = null;
            _blockHash = null;
        }

        public async Task<Hash> ToBlockHashAsync(ISubstrateService substrateService)
        {
            await EnsureDataIsSetAsync(substrateService);

            if (_blockHash != null)
                return _blockHash;

            var blockNumber = new BlockNumber(_blockNumber!.Value);
            var blockHash = await substrateService.Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None);

            if (blockHash == null)
                throw new BlockException($"{nameof(blockHash)} from given blockId (={_blockNumber}) is null");

            return blockHash;
        }

        public async Task<BlockNumber> ToBlockNumberAsync(ISubstrateService substrateService)
        {
            await EnsureDataIsSetAsync(substrateService);

            if (_blockNumber != null)
            {
                var blockNumber1 = new BlockNumber();
                blockNumber1.Create(_blockNumber!.Value);
                return blockNumber1;
            }

            var blockHash = await substrateService.Rpc.Chain.GetBlockAsync(_blockHash, CancellationToken.None);

            var blockNumber = new BlockNumber();
            
            if (blockHash == null)
                throw new BlockException($"{nameof(blockNumber)} from given blockId (={blockHash}) is null");

            blockNumber.Create((uint)blockHash.Block.Header.Number.Value);

            return blockNumber;
        }
    }
}
