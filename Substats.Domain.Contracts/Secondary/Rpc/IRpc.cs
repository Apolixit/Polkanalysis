using Ajuna.NetApi.Modules;
using Ajuna.NetApi.Modules.Contracts;
using Substats.Domain.Contracts.Secondary.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Rpc
{
    public interface IRpc
    {
        public IChain Chain { get; }
        public IState State { get; }
        public IAuthor Author { get; }
        public ISystem System { get; }
    }
}
