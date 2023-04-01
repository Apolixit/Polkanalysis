using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Contracts
{
    public interface IBlockchainMapping
    {
        public IMapper Mapper { get; }
    }
}
