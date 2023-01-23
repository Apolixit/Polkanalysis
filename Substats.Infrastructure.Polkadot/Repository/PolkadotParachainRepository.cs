using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Dto.Parachain;
using Substats.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotParachainRepository : IParachainRepository
    {
        private readonly ISubstrateRepository _substrateNodeRepository;

        public PolkadotParachainRepository(ISubstrateRepository substrateNodeRepository)
        {
            _substrateNodeRepository = substrateNodeRepository;
        }

        public async Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken)
        {
            var res24 = await _substrateNodeRepository.Client.ParasStorage.Parachains(cancellationToken);

            var paraId = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            var paraU32 = new U32();
            paraU32.Create(parachainId);
            paraId.Value = paraU32;

            var accountRegistar = await _substrateNodeRepository.Client.RegistrarStorage.Paras(paraId, cancellationToken);
            //var accountRegistar = await _substrateNodeRepository.Client.RegistrarStorage.PendingSwap(paraId, cancellationToken);

            return null;
        }
    }
}
