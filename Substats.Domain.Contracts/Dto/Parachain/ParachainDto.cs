using Substats.Domain.Contracts.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.Parachain
{
    public class ParachainDto
    {
        public int Id { get; set; }
        public AccountDto Owner { get; set; }
        public AccountDto FundAccount { get; set; }
        public int ValidatorCount { get; set; }
        public string SlotType { get; set; }

        // TODO Timeline
    }
}
