using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Adapter.Block
{
    public interface IBlockParameterLike
    {
        public BlockNumber ToBlockNumber();
        public Hash ToBlockHash();
    }
}
