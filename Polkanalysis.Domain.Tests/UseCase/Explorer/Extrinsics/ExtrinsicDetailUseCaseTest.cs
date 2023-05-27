using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Dto.Event;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.UseCase;
using Polkanalysis.Domain.UseCase.Explorer.Extrinsics;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Extrinsics
{
    public class ExtrinsicDetailUseCaseTest : UseCaseTest<ExtrinsicDetailsUseCase, ExtrinsicDto, ExtrinsicDetailQuery>
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

            var result = await _useCase.Handle(new ExtrinsicDetailQuery()
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

            var result = await _useCase.Handle(new ExtrinsicDetailQuery()
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
            var result = await _useCase.Handle(new ExtrinsicDetailQuery()
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
            var result = await _useCase.Handle(new ExtrinsicDetailQuery()
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
