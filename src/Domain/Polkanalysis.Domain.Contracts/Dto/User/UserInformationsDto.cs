using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class UserInformationsDto
    {
        public string Name { get; set; } = "Unknown";
        public string? Email { get; set; }
        public string? Twitter { get; set; }
        public string? Image { get; set; }
        public string? Legal { get; set; }
        public string? Website { get; set; }
        public string? Matrix { get; set; }
        public string? Other { get; set; }
        public EnumJudgement? IdentityLevel { get; set; }
    }
}
