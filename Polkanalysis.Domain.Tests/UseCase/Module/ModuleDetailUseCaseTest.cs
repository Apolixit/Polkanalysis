﻿using Polkanalysis.Domain.Contracts.Dto.Module;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Primary.Result;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.UseCase.Runtime;

namespace Polkanalysis.Domain.Tests.UseCase.Module
{
    public class ModuleDetailUseCaseTest : 
        UseCaseTest<RuntimeModuleDetailUseCase, ModuleDetailDto, RuntimeModuleDetailQuery>
    {
        private IModuleInformation _moduleRepository;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<RuntimeModuleDetailUseCase>>();
            _moduleRepository = Substitute.For<IModuleInformation>();

            _useCase = new RuntimeModuleDetailUseCase(_logger, _moduleRepository);
            base.Setup();
        }

        /// <summary>
        /// Test when we pass a valid module name and got a valid DTO
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ModuleDetailUseCaseWithValidModuleName_ShouldSucceedAsync()
        {
            _moduleRepository.GetModuleDetail(Arg.Is("System")).Returns(Substitute.For<ModuleDetailDto>());
            var result = await _useCase.Handle(new RuntimeModuleDetailQuery("System"), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }

        /// <summary>
        /// Test when we pass empty module name in our use case
        /// </summary>
        [Test]
        
        public async Task ModuleDetailUseCaseWithEmptyModuleName_ShouldFailedAsync()
        {
            var result = await _useCase.Handle(new RuntimeModuleDetailQuery(string.Empty), CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyParam);
        }

        /// <summary>
        /// Test when we pass invalid module name in our use case
        /// </summary>
        [Test]
        
        public async Task ModuleDetailUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _moduleRepository.GetModuleDetail(Arg.Any<string>()).ReturnsNull();

            var result = await _useCase.Handle(new RuntimeModuleDetailQuery("System"), CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }
    }
}
