using Substats.Domain.Contracts.Secondary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Contracts
{
    public interface IRpc
    {
        public IChain Chain { get; }
    }
}
