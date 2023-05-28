using Polkanalysis.Domain.Contracts.Dto.Balances;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class AccountListDto
    {
        public UserAddressDto Address { get; set; }
        public required BalancesDto Balances { get; set; }
    }
}
