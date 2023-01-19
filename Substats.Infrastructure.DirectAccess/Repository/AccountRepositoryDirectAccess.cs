using Ajuna.NetApi;
using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Dto.User;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated.Model.sp_core.crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class AccountRepositoryDirectAccess : IAccountRepository
    {
        private readonly ISubstrateNodeRepository _substrateNodeRepository;

        public AccountRepositoryDirectAccess(ISubstrateNodeRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<AccountDto> GetAccountDetailAsync(string accountAddress, CancellationToken cancellationToken)
        {
            if (accountAddress == null) throw new ArgumentNullException($"{nameof(accountAddress)}");

            var accountId32 = new AccountId32();
            accountId32.Create(Utils.GetPublicKeyFrom(accountAddress));

            var res = await _substrateNodeRepository.Client.BalancesStorage.Account(accountId32, cancellationToken);
            var res1 = await _substrateNodeRepository.Client.BalancesStorage.Locks(accountId32, cancellationToken);

            var res2 = await _substrateNodeRepository.Client.BalancesStorage.Reserves(accountId32, cancellationToken);
            var res3 = await _substrateNodeRepository.Client.BalancesStorage.StorageVersion(cancellationToken);
            var res4 = await _substrateNodeRepository.Client.BalancesStorage.TotalIssuance(cancellationToken);

            var res5 = await _substrateNodeRepository.Client.SystemStorage.Account(accountId32, cancellationToken);
            var res6 = await _substrateNodeRepository.Client.SystemStorage.Digest(cancellationToken);
            var res7 = await _substrateNodeRepository.Client.SystemStorage.ExecutionPhase(cancellationToken);
            var res8 = await _substrateNodeRepository.Client.System.NodeRolesAsync(cancellationToken);
            var res9 = await _substrateNodeRepository.Client.System.ChainAsync(cancellationToken);
            var res10 = await _substrateNodeRepository.Client.System.NameAsync(cancellationToken);
            var res11 = await _substrateNodeRepository.Client.System.ChainTypeAsync(cancellationToken);
            var res12 = await _substrateNodeRepository.Client.System.AccountNextIndexAsync(accountAddress, cancellationToken);
            var res13 = await _substrateNodeRepository.Client.System.HealthAsync(cancellationToken);
            var res14 = await _substrateNodeRepository.Client.System.SyncStateAsync(cancellationToken);
            var res15 = await _substrateNodeRepository.Client.System.VersionAsync(cancellationToken);
            var res16 = await _substrateNodeRepository.Client.System.NodeRolesAsync(cancellationToken);
            var res17 = await _substrateNodeRepository.Client.State.GetRuntimeVersionAsync();

            var res18 = await _substrateNodeRepository.Client.StakingStorage.Bonded(accountId32, cancellationToken);
            var res19 = await _substrateNodeRepository.Client.StakingStorage.BondedEras(cancellationToken);
            var res20 = await _substrateNodeRepository.Client.StakingStorage.CurrentEra(cancellationToken);
            var res21 = await _substrateNodeRepository.Client.StakingStorage.Nominators(accountId32, cancellationToken);
            var res22 = await _substrateNodeRepository.Client.StakingStorage.Payee(accountId32, cancellationToken);
            var res23 = await _substrateNodeRepository.Client.StakingStorage.Validators(accountId32, cancellationToken);
            var res24 = await _substrateNodeRepository.Client.ParasStorage.Parachains(cancellationToken);
            var res25 = await _substrateNodeRepository.Client.IdentityStorage.IdentityOf(accountId32, cancellationToken);

            var res26 = await _substrateNodeRepository.Client.NominationPoolsStorage.PoolMembers(accountId32, cancellationToken);
            var accountInfo = await _substrateNodeRepository.Client.SystemStorage.Account(accountId32, cancellationToken);
            var accountNextindex = await _substrateNodeRepository.Client.System.AccountNextIndexAsync(accountAddress, cancellationToken);
            var chainInfo = await _substrateNodeRepository.Client.System.PropertiesAsync(cancellationToken);
            if (chainInfo == null)
                throw new InvalidOperationException($"{chainInfo}");


            var ajunaParaId = new Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            var ajunaIdU32 = new U32();
            ajunaIdU32.Create(2051);
            
            ajunaParaId.Value = ajunaIdU32;

            var baseTuplePara = new BaseTuple<AccountId32, Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>();
            baseTuplePara.Create(accountId32, ajunaParaId);

            var apoBidAjunaAction = await _substrateNodeRepository.Client.AuctionsStorage.ReservedAmounts(baseTuplePara, cancellationToken);
            var xx = await _substrateNodeRepository.Client.AuctionsStorage.AuctionInfo(cancellationToken);
            //_substrateNodeRepository.Client.ParasStorage.
            var freeAmount = (double)(
                (double)accountInfo.Data.Free.Value / 10000000000);
            var otherAmount = (double)(
                (
                    (double)accountInfo.Data.FeeFrozen.Value + 
                    (double)accountInfo.Data.MiscFrozen.Value + 
                    (double)accountInfo.Data.Reserved.Value) 
                    / 10000000000);

            var account = new AccountDto()
            {
                Name = "Unknown",
                Address = new AddressDto()
                {
                    Address = accountAddress
                },
                AccountIndex = accountNextindex,
                Nonce = accountInfo.Nonce.Value,
                Balances = new Domain.Contracts.Dto.Balances.BalancesDto()
                {
                    Transferable = freeAmount,
                    Stacking = 0,
                    Others = otherAmount
                }
            };
            return account;
        }
    }
}
