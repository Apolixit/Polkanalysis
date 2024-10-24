using Substrate.NetApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class UserIdentityDto
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public UserIdentityTypeDto IdentityType { get; set; } = UserIdentityTypeDto.Anonymous;
        public string SubstrateAddress { 
            get
            {
                return Utils.GetAddressFrom(Utils.HexToByteArray(PublicKey), 42);
            }
        }
        public string PublicKey { get; set; } = string.Empty;

        /// <summary>
        /// Default empty user identity
        /// </summary>
        public static readonly UserIdentityDto Empty = new UserIdentityDto() { Name = " - ", Address = " - ", IdentityType = UserIdentityTypeDto.Anonymous };
        public override string ToString()
        {
            return Name;
        }
    }

    public enum UserIdentityTypeDto
    {
        Anonymous,
        IdentitySet,
        SuperOf,
        SubOf
    }
}
