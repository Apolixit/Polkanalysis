using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.System
{
    public class AccountInfo
    {
        public U32 Nonce { get; set; }
        public U32 Consumers { get; set; }
        public U32 Providers { get; set; }
        public U32 Sufficients { get; set; }
        public AccountData Data { get; set; } = new AccountData();

    }
}
