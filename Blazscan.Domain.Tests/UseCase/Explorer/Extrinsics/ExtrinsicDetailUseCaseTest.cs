using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Dto.Extrinsic;
using Blazscan.Domain.Contracts.Primary;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Domain.UseCase;
using Blazscan.Domain.UseCase.Explorer.Extrinsics;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace Blazscan.Domain.Tests.UseCase.Explorer.Extrinsics
{
    public class ExtrinsicDetailUseCaseTest : UseCaseTest<ExtrinsicDetailsUseCase, ExtrinsicDto, ExtrinsicCommand>
    {
        private IExplorerRepository _explorerRepository;

        [SetUp]
        public override void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerRepository>();
            _logger = Substitute.For<ILogger<ExtrinsicDetailsUseCase>>();
            _useCase = new ExtrinsicDetailsUseCase(_explorerRepository, _logger);
        }

        [Test]
        public async Task ExtrinsicDetailsUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerRepository.GetExtrinsicAsync(Arg.Is<uint>(x => x > 0), Arg.Is<uint>(x => x > 0), CancellationToken.None).ReturnsNull();

            var result = await _useCase.ExecuteAsync(new ExtrinsicCommand()
            {
                BlockNumber = 1,
                ExtrinsicIndex = 1
            }, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task ExtrinsicDetailsUseCaseWithValidParameters_ShouldSucceedAsync()
        {
            _explorerRepository.GetExtrinsicAsync(Arg.Is<uint>(x => x > 0), Arg.Is<uint>(x => x > 0), CancellationToken.None).Returns(Substitute.For<ExtrinsicDto>());

            var result = await _useCase.ExecuteAsync(new ExtrinsicCommand()
            {
                BlockNumber = 1,
                ExtrinsicIndex = 1,
            }, CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task ExtrinsicDetailsUseCaseWithInvalidBlockNumber_ShouldFailedAsync()
        {
            var result = await _useCase.ExecuteAsync(new ExtrinsicCommand()
            {
                BlockNumber = 0,
                ExtrinsicIndex = 1,
            }, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.InvalidParam);
        }

        [Test]
        public async Task ExtrinsicDetailsUseCaseWithInvalidExtrinsicIndex_ShouldFailedAsync()
        {
            var result = await _useCase.ExecuteAsync(new ExtrinsicCommand()
            {
                BlockNumber = 1,
                ExtrinsicIndex = 0,
            }, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.InvalidParam);
        }
    }
}
