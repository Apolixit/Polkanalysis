using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Core.Public;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Session
{
    public abstract class SessionKeys : BaseType
    {
        public abstract IEnumerable<(string name, Public key)> Publics { get; }
    }
}
