using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Contracts.Dto.User
{
    public class AddressDto
    {
        public string Address { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
    }
}
