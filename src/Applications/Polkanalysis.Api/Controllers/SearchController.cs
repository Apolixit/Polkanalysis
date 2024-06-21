using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.Search;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Primary.Search;
using System.ComponentModel;

namespace Polkanalysis.Api.Controllers
{
    public class SearchController : MasterController
    {

        public SearchController(IMediator mediator, ILogger<SearchController> logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Produces(typeof(IEnumerable<SearchResultDto>))]
        [Description("Search on Polkanalysis")]
        public async Task<ActionResult<IEnumerable<SearchResultDto>>> SearchAsync(string query)
        {
            return await SendAndHandleResponseAsync(new SearchQuery(query));
        }
    }
}
