using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Secondary.Pallet.Identity
{
    public class IdentityInfo
    {
        public string Display { get; set; } = string.Empty;
        public string Legal { get; set; } = string.Empty;
        public string Web { get; set; } = string.Empty;
        public string Riot { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PgpFingerprint { get; set; } = string.Empty;
        public string Twitter { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
    }
}
