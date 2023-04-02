using Ajuna.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Adapter.Block
{
    public interface IBlockParameterLike
    {
        public Task<BlockNumber> ToBlockNumberAsync();
        public Task<Hash> ToBlockHashAsync();
    }
}
