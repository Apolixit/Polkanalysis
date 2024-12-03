using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Informations;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Primary.Informations;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class InformationController : MasterController
    {
        public InformationController(IMediator mediator, ILogger<InformationController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Return current connected blockchain global informations
        /// </summary>
        /// <returns>Blockchain informations</returns>
        [HttpGet()]
        [Produces(typeof(BlockchainDetailsDto))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Description("Return current connected blockchain global informations")]
        public async Task<ActionResult<BlockchainDetailsDto>> GetBlockchainInformationAsync()
        {
            return await SendAndHandleResponseAsync(new BlockchainDetailsQuery());
        }
    }
}
