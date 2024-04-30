using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Api.Controllers;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Api.Tests
{
    internal class VersionsControllerTests : MasterTests<VersionsController>
    {
        private ILogger<VersionsController> _logger;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<VersionsController>>();
        }

        protected override VersionsController defaultUseCase()
        {
            var controller = new VersionsController(_mediator, _logger);
            controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { }
            };

            return controller;
        }

        [Test]
        public async Task GetModules_WithValidMediatorResponse_ShouldReturn200Async()
        {
            _mediator.Send(Arg.Any<PalletVersionsQuery>(), CancellationToken.None)
                .Returns(GetValidResult(Substitute.For<IEnumerable<PalletVersionDto>>()));

            var res = await defaultUseCase().GetPalletVersionsAsync("myModule");
            Assert.That(res.Result, Is.InstanceOf<OkObjectResult>());
        }

        [Test]
        public async Task CompareSpecVersionByNumberVersion_WithInvalidParam_ShouldReturn400Async()
        {
            var res = await defaultUseCase().CompareSpecVersionByNumberVersionAsync(20, 10);
            Assert.That(res.Result, Is.InstanceOf<BadRequestObjectResult>());
        }

        [Test]
        public async Task CompareSpecVersionByBlockNumber_WithInvalidParam_ShouldReturn400Async()
        {
            var res = await defaultUseCase().CompareSpecVersionByBlockNumberAsync(20, 10);
            Assert.That(res.Result, Is.InstanceOf<BadRequestObjectResult>());
        }
    }
}
