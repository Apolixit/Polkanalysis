using Substrate.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class UserAddressDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public string SubstrateAddress { 
            get
            {
                return Utils.GetAddressFrom(Utils.HexToByteArray(PublicKey), 42);
            }
        }
        public string PublicKey { get; set; } = string.Empty;
        public static UserAddressDto Empty = new UserAddressDto() { Name = " - ", Address = " - " };
        public override string ToString()
        {
            return Name;
        }
    }
}
