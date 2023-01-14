using Substats.Domain.Contracts.Secondary;
using Substats.Domain.UseCase.Explorer.Block;
using Substats.Domain.UseCase;
using Substats.Domain.UseCase.Explorer.Events;
using Substats.Domain.UseCase.Explorer.Extrinsics;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Primary;
using NSubstitute.ReturnsExtensions;

namespace Substats.Domain.Tests.UseCase.Explorer.Events
{
    public class EventDetailUseCaseTest : UseCaseTest<EventDetailUseCase, EventDto, EventCommand>
    {
        private IExplorerRepository _explorerRepository;

        [SetUp]
        public override void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerRepository>();
            _logger = Substitute.For<ILogger<EventDetailUseCase>>();
            _useCase = new EventDetailUseCase(_explorerRepository, _logger);
        }

        [Test]
        public async Task EventDetailsUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerRepository.GetEventAsync(Arg.Any<uint>(), Arg.Any<uint>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase.ExecuteAsync(new EventCommand() { 
                BlockNumber = 1, 
                EventIndex = 1 
            }, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task EventDetailsUseCaseWithValidParameters_ShouldSucceedAsync()
        {
            var useCase = new EventDetailUseCase(_explorerRepository, _logger);

            _explorerRepository.GetEventAsync(Arg.Is<uint>(x => x > 0), Arg.Is<uint>(x => x > 0), CancellationToken.None).Returns(Substitute.For<EventDto>());

            var result = await useCase.ExecuteAsync(new EventCommand()
            {
                BlockNumber = 1,
                EventIndex = 1,
            }, CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task EventDetailsUseCaseWithInvalidBlockNumber_ShouldFailedAsync()
        {
            var result = await _useCase.ExecuteAsync(new EventCommand()
            {
                BlockNumber = 0,
                EventIndex = 1,
            }, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.InvalidParam);
        }

        [Test]
        public async Task EventDetailsUseCaseWithInvalidExtrinsicIndex_ShouldFailedAsync()
        {
            var result = await _useCase.ExecuteAsync(new EventCommand()
            {
                BlockNumber = 1,
                EventIndex = 0,
            }, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.InvalidParam);
        }
    }
}
