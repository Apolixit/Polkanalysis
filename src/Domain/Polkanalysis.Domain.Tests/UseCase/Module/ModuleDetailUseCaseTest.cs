using Polkanalysis.Domain.Contracts.Dto.Module;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Primary.Result;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.UseCase.Runtime;
using Polkanalysis.Domain.Contracts.Service;
using Microsoft.Extensions.Caching.Distributed;

namespace Polkanalysis.Domain.Tests.UseCase.Module
{
    public class ModuleDetailUseCaseTest : 
        UseCaseTest<RuntimeModuleDetailHandler, ModuleDetailDto, RuntimeModuleDetailQuery>
    {
        private IMetadataService _metadataService;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<RuntimeModuleDetailHandler>>();
            _metadataService = Substitute.For<IMetadataService>();

            _useCase = new RuntimeModuleDetailHandler(_logger, _metadataService, Substitute.For<IDistributedCache>());
            //base.Setup();
        }

        /// <summary>
        /// Test when we pass a valid module name and got a valid DTO
        /// </summary>
        /// <returns></returns>
        [Test]
        public async Task ModuleDetailUseCaseWithValidModuleName_ShouldSucceedAsync()
        {
            _metadataService.GetModuleDetailAsync(Arg.Is("System"), CancellationToken.None).Returns(Substitute.For<ModuleDetailDto>());
            var result = await _useCase!.HandleInnerAsync(new RuntimeModuleDetailQuery("System"), CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.Not.Null);
        }

        /// <summary>
        /// Test when we pass empty module name in our use case
        /// </summary>
        [Test]
        
        public async Task ModuleDetailUseCaseWithEmptyModuleName_ShouldFailedAsync()
        {
            var result = await _useCase!.HandleInnerAsync(new RuntimeModuleDetailQuery(string.Empty), CancellationToken.None);

            Assert.That(result.IsError, Is.True);
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
            _metadataService.GetModuleDetailAsync(Arg.Any<string>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase!.HandleInnerAsync(new RuntimeModuleDetailQuery("System"), CancellationToken.None);

            Assert.That(result.IsError, Is.True);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }
    }
}
