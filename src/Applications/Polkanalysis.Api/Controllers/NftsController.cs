using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Primary.Accounts;
using Polkanalysis.Domain.Contracts.Settings;
using MediatR;

namespace Polkanalysis.Api.Controllers
{
    /// <summary>
    /// Expose datas about Nfts pallet
    /// </summary>
    [Produces("application/json")]
    public class NftsController : MasterController
    {
        /// <summary>
        /// Default <see cref="NftsController" /> constructor
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="logger"></param>
        public NftsController(IMediator mediator, ILogger<NftsController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Return Nfts collections
        /// </summary>
        /// <param name="size">Number of items returned</param>
        /// <param name="page">Page number</param>
        /// <returns>List of accounts with <see cref="AccountLightDto" /> info</returns>
        /// <response code="200">Returns data</response>
        /// <response code="400">An error happened in the backend</response>
        [HttpGet]
        [Produces(typeof(IEnumerable<AccountLightDto>))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResponseDto<AccountLightDto>>> GetCollectionsAsync(
            int size = ConstantsPagination.DefaultPageSize,
            int page = ConstantsPagination.DefaultPageNumber)
        {
            return Ok();
        }
    }
}
