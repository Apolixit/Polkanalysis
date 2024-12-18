using MediatR;
using Microsoft.AspNetCore.Mvc;
using Polkanalysis.Api.Dto;
using Polkanalysis.Domain.Contracts.Dto.Informations;

namespace Polkanalysis.Api.Controllers
{
    [Produces("application/json")]
    public class HomeController : MasterController
    {
        public HomeController(IMediator mediator, ILogger<HomeController> logger) : base(mediator, logger)
        {
        }

        /// <summary>
        /// Default json message when calling API with no routes
        /// </summary>
        /// <returns></returns>
        [HttpGet(), Route("/")]
        [Produces(typeof(HomeResponse))]
        public ActionResult<HomeResponse> Index()
        {
            return new HomeResponse("0.1", "Polkanalysis API is currently under developpement. Release date estimated to Q1 2025. Check developpement activity on https://github.com/Apolixit/Polkanalysis");
        }
    }
}
