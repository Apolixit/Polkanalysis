using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Exception;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Domain.Adapter.Block
{
    public class BlockParameterLike
    {
        private uint? _blockNumber;
        private Hash? _blockHash;
        private readonly ISubstrateRepository _substrateService;

        public BlockParameterLike(ISubstrateRepository substrateService)
        {
            _substrateService = substrateService;
        }

        public async Task<bool> EnsureBlockNumberIsValidAsync(uint blockNumber)
        {
            var lastHeader = await _substrateService.Rpc.Chain.GetHeaderAsync();

            if (lastHeader.Number.Value < blockNumber)
                return false;

            return true;
        }

        public async Task<BlockParameterLike> FromBlockNumberAsync(uint blockNumber)
        {
            var isBlockValid = await EnsureBlockNumberIsValidAsync(blockNumber);
            if(!isBlockValid)
                throw new BlockException($"Block number {blockNumber} has not been produced yet");

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

            var blockNumber = new BlockNumber(_blockNumber!.Value);
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
