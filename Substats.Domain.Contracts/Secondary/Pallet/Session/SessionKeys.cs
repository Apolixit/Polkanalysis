using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Session
{
    public abstract class SessionKeys : BaseType
    {
        public abstract IEnumerable<Public> Publics { get; }
    }
}
