﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Dto.User;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;

namespace Substats.Domain.Contracts.Secondary
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Get account information
        /// </summary>
        /// <param name="accountAddress"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken);

        public Task<UserAddressDto> GetAccountIdentityAsync(AccountId32 account, CancellationToken cancellationToken);
        public Task<UserAddressDto> GetAccountIdentityAsync(string accountAddress, CancellationToken cancellationToken);
    }
}
