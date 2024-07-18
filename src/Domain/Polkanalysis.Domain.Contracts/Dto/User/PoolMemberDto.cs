using Polkanalysis.Domain.Contracts.Dto.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class PoolMemberDto
    {
        public required UserIdentityDto Account { get; set; }
        public required double Bonded { get; set; }
        public double Claimable { get; set; } = 0;
    }
}
