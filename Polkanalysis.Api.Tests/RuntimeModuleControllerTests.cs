using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSubstitute;
using OperationResult;
using Polkanalysis.Api.Controllers;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Polkanalysis.Domain.Contracts.Primary.Result.ErrorResult;

namespace Polkanalysis.Api.Tests
{
    [ExcludeFromCodeCoverage]
    public class RuntimeModuleControllerTests
    {
        private IMediator _mediator;
        private ILogger<RuntimeController> _logger;

        [SetUp]
        public void Setup()
        {
            _mediator = Substitute.For<IMediator>();
            _logger = Substitute.For<ILogger<RuntimeController>>();
        }

        private Result<T, ErrorResult> GetValidResult<T>(T result)
        {
            return Helpers.Ok(result);
        }

        private Result<T, ErrorResult> GetInvalidResult_EmptyParam<T>()
        {
            return Helpers.Error(new ErrorResult()
            {
                Status = ErrorType.EmptyParam,
                Description = string.Empty
            });
        }

        private RuntimeController defaultUseCase()
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
            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public async Task GetModules_WithInvalidMediatorResponse_ShouldReturn400Async()
        {
            _mediator.Send(Arg.Any<RuntimeModulesQuery>(), CancellationToken.None)
                .Returns(GetInvalidResult_EmptyParam<IEnumerable<ModuleDetailDto>>());

            var res = await defaultUseCase().GetModulesAsync();
            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }


        [Test]
        public async Task GetModule_WithValidMediatorResponse_ShouldReturn200Async()
        {
            _mediator.Send(Arg.Any<RuntimeModuleDetailQuery>(), CancellationToken.None)
                .Returns(GetValidResult(Substitute.For<ModuleDetailDto>()));

            var res = await defaultUseCase().GetModuleAsync("system");

            Assert.IsInstanceOf<OkObjectResult>(res);
        }

        [Test]
        public async Task GetModule_WithInvalidParam_ShouldReturn400Async()
        {
            var res = await defaultUseCase().GetModuleAsync(string.Empty);
            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }

        [Test]
        public async Task GetModule_WithInvalidMediatorResponse_ShouldReturn400Async()
        {
            _mediator.Send(Arg.Any<RuntimeModuleDetailQuery>(), CancellationToken.None)
                .Returns(GetInvalidResult_EmptyParam<ModuleDetailDto>());

            var res = await defaultUseCase().GetModuleAsync("system");

            Assert.IsInstanceOf<BadRequestObjectResult>(res);
        }
    }
}
