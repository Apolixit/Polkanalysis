using Substats.Domain.Contracts.Secondary.Common;
using Substats.Domain.Contracts.Secondary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Common.Repository.Rpc
{
    internal class SubstrateRpc : IRpc
    {
        public IChain Chain => throw new NotImplementedException();
    }
}
