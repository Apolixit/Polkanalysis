using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Domain.Contracts.Dto.Parachain;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Repository
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
            //if(_substrateNodeRepository.Api.Storage.ParasStorage == null)
            var res24 = await _substrateNodeRepository.Storage.Paras.ParachainsAsync(cancellationToken);

            var paraId = new Substats.Polkadot.NetApiExt.Generated.Model.polkadot_parachain.primitives.Id();
            var paraU32 = new U32();
            paraU32.Create(parachainId);
            paraId.Value = paraU32;

            var accountRegistar = await _substrateNodeRepository.Storage.Registrar.ParasAsync(paraId, cancellationToken);
            //var accountRegistar = await _substrateNodeRepository.Client.RegistrarStorage.PendingSwap(paraId, cancellationToken);

            return null;
        }
    }
}
