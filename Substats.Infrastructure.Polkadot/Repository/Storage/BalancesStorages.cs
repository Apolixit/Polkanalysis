using AutoMapper;
using Substats.AjunaExtension;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Balances;
using Substats.Infrastructure.Polkadot.Mapper;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using Substats.Polkadot.NetApiExt.Generated.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Substats.Domain.Contracts.Secondary.Pallet.Balances.BalanceLock;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class BalancesStorages : IBalancesStorage
    {
        private readonly SubstrateClientExt _client;

        public BalancesStorages(SubstrateClientExt client)
        {
            _client = client;
        }

        public async Task<AccountData> AccountAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);
            var res = await _client.BalancesStorage.Account(accountId32, token);

            if (res == null)
                throw new InvalidOperationException($"BalancesStorage.Account return null value for account address {account.Value}");

            var accountData = new AccountData()
            {
                Free = res.Free.ToBigInteger(),
                FeeFrozen = res.FeeFrozen.ToBigInteger(),
                MiscFrozen = res.MiscFrozen.ToBigInteger(),
                Reserved = res.Reserved.ToBigInteger()
            };

            return accountData;
        }

        public async Task<BigInteger> InactiveIssuanceAsync(CancellationToken token)
        {
            return (await _client.BalancesStorage.InactiveIssuance(token)).ToBigInteger();
        }

        public async Task<IEnumerable<BalanceLock>> LocksAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);
            var res = await _client.BalancesStorage.Locks(accountId32, token);

            if (res == null || res.Value == null) 
                return Enumerable.Empty<BalanceLock>();

            return res.Value.Value.Select(x =>
            {
                return new BalanceLock()
                {
                    Id = SubstrateMapper.Instance.Map<Arr8U8, string>(x.Id),
                    Amount = x.Amount.ToBigInteger(),
                    Reason = SubstrateMapper.Instance.Map<Substats.Polkadot.NetApiExt.Generated.Model.pallet_balances.Reasons, ReasonType>(x.Reasons.Value)
                };
            });
        }

        public async Task<IEnumerable<ReserveData>> ReservesAsync(SubstrateAccount account, CancellationToken token)
        {
            var accountId32 = SubstrateMapper.Instance.Map<SubstrateAccount, AccountId32>(account);
            var res = await _client.BalancesStorage.Reserves(accountId32, token);

            if (res == null)
                return Enumerable.Empty<ReserveData>();

            return res.Value.Value.Select(x =>
            {
                return new ReserveData()
                {
                    Id = SubstrateMapper.Instance.Map<Arr8U8, string>(x.Id),
                    Amount = x.Amount.ToBigInteger(),
                };
            });
        }

        public async Task<BigInteger> TotalIssuanceAsync(CancellationToken token)
        {
            return (await _client.BalancesStorage.TotalIssuance(token)).ToBigInteger();
        }
    }
}
