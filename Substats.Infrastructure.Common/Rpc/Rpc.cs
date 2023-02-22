using Ajuna.NetApi.Modules;
using Substats.Domain.Contracts.Secondary.Rpc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Common.Rpc
{
    public class Rpc : IRpc
    {
        public IChain Chain => throw new NotImplementedException();

        public IState State => throw new NotImplementedException();

        public Author Author => throw new NotImplementedException();

        public ISystem System => throw new NotImplementedException();

        Ajuna.NetApi.Modules.Chain IRpc.Chain => throw new NotImplementedException();

        State IRpc.State => throw new NotImplementedException();

        Ajuna.NetApi.Modules.System IRpc.System => throw new NotImplementedException();
    }
}
