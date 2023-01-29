using Substats.Domain.Contracts.Dto.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.User
{
    public class PoolMemberDto
    {
        public required UserAddressDto Account { get; set; }
        public required double Bonded { get; set; }
        public double Claimable { get; set; } = 0;
    }
}
