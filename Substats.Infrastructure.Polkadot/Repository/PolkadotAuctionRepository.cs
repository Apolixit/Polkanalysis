using Ajuna.NetApi.Model.Types.Base;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotAuctionRepository : IAuctionRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;

        public PolkadotAuctionRepository(ISubstrateRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        //var ajunaParaId = new Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
        //var ajunaIdU32 = new U32();
        //ajunaIdU32.Create(2051);

        //    ajunaParaId.Value = ajunaIdU32;

        //    var baseTuplePara = new BaseTuple<AccountId32, Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id>();
        //baseTuplePara.Create(accountId32, ajunaParaId);

        //    var apoBidAjunaAction = await _substrateNodeRepository.Client.AuctionsStorage.ReservedAmounts(baseTuplePara, cancellationToken);
        //var xx = await _substrateNodeRepository.Client.AuctionsStorage.AuctionInfo(cancellationToken);
    }
}
