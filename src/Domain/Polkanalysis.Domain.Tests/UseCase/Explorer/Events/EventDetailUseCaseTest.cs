using Polkanalysis.Domain.UseCase.Explorer.Block;
using Polkanalysis.Domain.UseCase;
using Polkanalysis.Domain.UseCase.Explorer.Events;
using Polkanalysis.Domain.UseCase.Explorer.Extrinsics;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Event;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Event;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Events
{
    public class EventDetailUseCaseTest : UseCaseTest<EventDetailHandler, EventDto, EventDetailQuery>
    {
        private IExplorerService _explorerRepository;

        [SetUp]
        public override void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerService>();
            _logger = Substitute.For<ILogger<EventDetailHandler>>();
            _useCase = new EventDetailHandler(_explorerRepository, _logger);
        }

        [Test]
        public async Task EventDetailsUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerRepository.GetEventAsync(Arg.Any<uint>(), Arg.Any<uint>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase.Handle(new EventDetailQuery() { 
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
            var useCase = new EventDetailHandler(_explorerRepository, _logger);

            _explorerRepository.GetEventAsync(Arg.Is<uint>(x => x > 0), Arg.Is<uint>(x => x > 0), CancellationToken.None).Returns(Substitute.For<EventDto>());

            var result = await useCase.Handle(new EventDetailQuery()
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
            var result = await _useCase.Handle(new EventDetailQuery()
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
            var result = await _useCase.Handle(new EventDetailQuery()
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
