using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Api.Controllers;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;

namespace Polkanalysis.Api.Tests
{
    public class RuntimeControllerTests : MasterTests<RuntimeController>
    {
        private ILogger<RuntimeController> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<RuntimeController>>();
        }

        protected override RuntimeController defaultUseCase()
        {
            var controller = new RuntimeController(_mediator, _logger);
            controller.ControllerContext = new ControllerContext() {
                HttpContext = new DefaultHttpContext() { }
            };

            return controller;
        }

        [Test]
        public async Task GetModules_WithValidMediatorResponse_ShouldReturn200Async()
        {
            _mediator.Send(Arg.Any<RuntimeModulesQuery>(), CancellationToken.None)
                .Returns(GetValidResult(Substitute.For<IEnumerable<ModuleDetailDto>>()));

            var res = await defaultUseCase().GetModulesAsync();
            Assert.That(res.Result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetModules_WithInvalidMediatorResponse_ShouldReturn400Async()
        {
            _mediator.Send(Arg.Any<RuntimeModulesQuery>(), CancellationToken.None)
                .Returns(GetInvalidResult_EmptyParam<IEnumerable<ModuleDetailDto>>());

            var res = await defaultUseCase().GetModulesAsync();
            Assert.That(res.Result, Is.InstanceOf<BadRequestObjectResult>());
        }


        [Test]
        public async Task GetModule_WithValidMediatorResponse_ShouldReturn200Async()
        {
            _mediator.Send(Arg.Any<RuntimeModuleDetailQuery>(), CancellationToken.None)
                .Returns(GetValidResult(Substitute.For<ModuleDetailDto>()));

            var res = await defaultUseCase().GetModuleAsync("system");

            Assert.That(res.Result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task GetModule_WithInvalidParam_ShouldReturn400Async()
        {
            var res = await defaultUseCase().GetModuleAsync(string.Empty);
            Assert.That(res.Result, Is.InstanceOf<BadRequestObjectResult>());
            Assert.That(res.Result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task GetModule_WithInvalidMediatorResponse_ShouldReturn400Async()
        {
            _mediator.Send(Arg.Any<RuntimeModuleDetailQuery>(), CancellationToken.None)
                .Returns(GetInvalidResult_EmptyParam<ModuleDetailDto>());

            var res = await defaultUseCase().GetModuleAsync("system");

            Assert.That(res.Result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}
