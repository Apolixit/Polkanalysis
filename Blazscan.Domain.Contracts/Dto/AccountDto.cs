﻿using Blazscan.Domain.Contracts.Dto;

namespace Blazscan.Domain.Contracts
{
    public class AccountDto
    {
        public string Name { get; set; } = string.Empty;
        public AddressDto Address { get; set; }
        public string AvatarUrl { get; set; } = string.Empty;
        public double Balance { get; set; }

        public AccountDto() { }

        public AccountDto(string name, string ss58Address, string publicKey)
        {
            Name = name;
            Address = new AddressDto()
            {
                Address = ss58Address,
                PublicKey = publicKey
            };
            Balance = 0;
            AvatarUrl = $"/images/avatars/{name.ToLower()}.png";
        }

        public AccountDto WithBalance(double balance)
        {
            Balance = balance;
            return this;
        }
    }
}
