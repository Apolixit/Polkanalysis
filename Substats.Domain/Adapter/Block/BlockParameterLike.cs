using Ajuna.NetApi.Model.Types.Base;
using Org.BouncyCastle.Crypto;
using Substats.Domain.Contracts.Adapter.Block;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Adapter.Block
{
    public class BlockParameterLike : IBlockParameterLike
    {
        private readonly uint? _blockNumber;
        private readonly Hash? _blockHash;
        private readonly string? _blockAddress;

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
            _blockAddress = blockAddress;
        }

        public Hash ToBlockHash()
        {
            throw new NotImplementedException();
        }

        public BlockNumber ToBlockNumber()
        {
            throw new NotImplementedException();
        }
    }
}
