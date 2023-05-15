using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public enum AccountType
    {
        Account,
        Validator,
        Nominator,
        Council,
        TechnicalComitee,
        Registrar,
        PoolMember,
        System,
        OnChainIdentity,
        Proxy,
        Proxied,
        Multisig,
        MultisigMember,
    }
}
