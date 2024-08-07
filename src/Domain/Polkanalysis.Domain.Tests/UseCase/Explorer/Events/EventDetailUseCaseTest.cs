﻿using Polkanalysis.Domain.UseCase.Explorer.Block;
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
using Microsoft.Extensions.Caching.Distributed;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Events
{
    public class EventDetailUseCaseTest : UseCaseTest<EventDetailHandler, EventDto, EventDetailQuery>
    {
        private IExplorerService _explorerService;

        [SetUp]
        public void Setup()
        {
            _explorerService = Substitute.For<IExplorerService>();
            _logger = Substitute.For<ILogger<EventDetailHandler>>();
            _useCase = new EventDetailHandler(_explorerService, _logger, Substitute.For<IDistributedCache>());
        }

        [Test]
        public async Task EventDetailsUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerService.GetEventAsync(Arg.Any<uint>(), Arg.Any<uint>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase.HandleInnerAsync(new EventDetailQuery() { 
                BlockNumber = 1, 
                EventIndex = 1 
            }, CancellationToken.None);

            Assert.That(result.IsError, Is.True);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task EventDetailsUseCaseWithValidParameters_ShouldSucceedAsync()
        {
            var useCase = new EventDetailHandler(_explorerService, _logger!, Substitute.For<IDistributedCache>());

            _explorerService.GetEventAsync(Arg.Is<uint>(x => x > 0), Arg.Is<uint>(x => x > 0), CancellationToken.None).Returns(new EventDto(1, "1", "2", "PalletName", "EventName", "Description", new List<Contracts.Dto.Common.TreeDto>()));

            var result = await useCase.HandleInnerAsync(new EventDetailQuery()
            {
                BlockNumber = 1,
                EventIndex = 1,
            }, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task EventDetailsUseCaseWithInvalidBlockNumber_ShouldFailedAsync()
        {
            var result = await _useCase.HandleInnerAsync(new EventDetailQuery()
            {
                BlockNumber = 0,
                EventIndex = 1,
            }, CancellationToken.None);

            Assert.That(result.IsError, Is.True);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.InvalidParam);
        }

        [Test]
        public async Task EventDetailsUseCaseWithInvalidExtrinsicIndex_ShouldFailedAsync()
        {
            var result = await _useCase.HandleInnerAsync(new EventDetailQuery()
            {
                BlockNumber = 1,
                EventIndex = 0,
            }, CancellationToken.None);

            Assert.That(result.IsError, Is.True);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.InvalidParam);
        }
    }
}
