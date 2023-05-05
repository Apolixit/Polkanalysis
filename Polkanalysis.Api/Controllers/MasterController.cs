using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Polkanalysis.Domain.Contracts.Secondary;

namespace Polkanalysis.Api.Controllers
{
    [ApiController]
    [Route("api/polkadot/[controller]")]
    public class MasterController : Controller
    {
        public MasterController()
        {
        }

        //public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        //{
        //    if(!_substrateRepository.IsConnected())
        //    {
        //        await _substrateRepository.ConnectAsync();
        //    }

        //    await base.OnActionExecutionAsync(context, next);
        //}
    }
}
