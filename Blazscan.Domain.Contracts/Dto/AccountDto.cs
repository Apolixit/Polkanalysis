namespace Blazscan.Domain.Contracts
{
    public class AccountDto
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PublicKey { get; set; } = string.Empty;
        public string AvatarUrl { get; set; } = string.Empty;
        public double Balance { get; set; }

        public AccountDto() { }

        public AccountDto(string name, string ss58Address, string publicKey)
        {
            this.Name = name;
            this.Address = ss58Address;
            this.PublicKey = publicKey;
            this.Balance = 0;
            this.AvatarUrl = $"/images/avatars/{name.ToLower()}.png";
        }

        public AccountDto WithBalance(double balance)
        {
            Balance = balance;
            return this;
        }
    }
}
