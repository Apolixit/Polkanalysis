using Polkanalysis.Configuration.Contracts.Information;
using Polkanalysis.Domain.Contracts.Dto.Informations;
using Polkanalysis.Domain.Contracts.Dto.Parachain;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Auction;
using Polkanalysis.Domain.Contracts.Dto.Parachain.Crowdloan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Contracts.Secondary.Repository
{
    public interface IParachainRepository
    {
        public Task<IEnumerable<ParachainLightDto>> GetParachainsAsync(CancellationToken cancellationToken);
        public Task<ParachainDto> GetParachainDetailAsync(uint parachainId, CancellationToken cancellationToken);

        public Task<IEnumerable<AuctionLightDto>> GetAuctionsAsync(CancellationToken cancellationToken);
        public Task<AuctionDto> GetAuctionDetailAsync(uint auctionId, CancellationToken cancellationToken);

        public Task<IEnumerable<CrowdloanLightDto>> GetCrowdloansAsync(CancellationToken cancellationToken);
        public Task<CrowdloanDto> GetCrowdloanDetailAsync(uint crowdloanId, CancellationToken cancellationToken);

        /// <summary>
        /// Get static information about a project (come from configs)
        /// </summary>
        /// <param name="relayChain"></param>
        /// <param name="parachainId"></param>
        /// <returns></returns>
        public BlockchainProject? GetBlockchainProject(string relayChain, uint parachainId);
        public Task<BlockchainDetailsDto?> GetCurrentBlockchainDetailProjectAsync(CancellationToken cancellationToken);
    }
}
