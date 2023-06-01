using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Informations;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Informations;

namespace Polkanalysis.Api.Controllers
{
    public class InformationController : MasterController
    {
        private readonly ILogger<InformationController> _logger;

        public InformationController(IMediator mediator, ILogger<InformationController> logger) : base(mediator)
        {
            _logger = logger;
        }

        [HttpGet()]
        [Produces(typeof(BlockchainDetailsDto))]
        public async Task<ActionResult<BlockchainDetailsDto>> GetBlockchainInformationAsync()
        {
            return await SendAndHandleResponseAsync(new BlockchainDetailsQuery());
        }
    }
}
