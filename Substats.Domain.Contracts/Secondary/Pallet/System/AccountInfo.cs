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
        public uint Nonce { get; set; }
        public uint Consumers { get; set; }
        public uint Providers { get; set; }
        public uint Sufficients { get; set; }
        public AccountData Data { get; set; } = new AccountData();

    }
}
