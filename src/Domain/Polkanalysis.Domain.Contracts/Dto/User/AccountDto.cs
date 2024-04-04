using Polkanalysis.Domain.Contracts.Dto.Balances;

namespace Polkanalysis.Domain.Contracts.Dto.User
{
    public class AccountDto
    {
        public required UserInformationsDto InformationsDto { get; set; } = new UserInformationsDto();
        public UserAddressDto Address { get; set; }
        public required BalancesDto Balances { get; set; }
        public uint AccountIndex { get; set; }
        public required uint Nonce { get; set; }
        public string AvatarUrl { get; set; } = string.Empty;
        public List<AccountType> AccountTypes { get; set; } = new List<AccountType>();

        public AccountDto() { }
        //public AccountDto(string name, string ss58Address, string publicKey)
        //{
        //    InformationsDto = new UserInformationsDto() { Name = name };
        //    Address = new AddressDto()
        //    {
        //        Address = ss58Address,
        //        PublicKey = publicKey
        //    };
        //    Balances = new BalancesDto();
        //    AvatarUrl = $"/images/avatars/{name.ToLower()}.png";
        //}

        public AccountDto WithBalance(double balance)
        {
            Balances = new BalancesDto()
            {
                Transferable = balance,
            };
            return this;
        }
    }
}
