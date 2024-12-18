using Algolia.Search.Models.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;
using Substrate.NET.Metadata.Service;
using Substrate.NetApi.Model.Types.Base;
using System.Threading;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class SpecVersionHandlerCommandTests
        : UseCaseTest<SpecVersionCommandHandler, bool, SpecVersionCommand>
    {
        private ICoreService _coreService = default!;
        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SpecVersionCommandHandler>>();

            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;

            _substrateService.BlockchainName.Returns("Polkadot");

            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), CancellationToken.None).Returns(new Hash("0xfc7ed4b4ca798d49e2824868026ddcaf05d7fdd3ebd79a28b5872084c07af210"));
            _substrateService.Rpc.State.GetMetaDataAsync(Arg.Any<byte[]>(), CancellationToken.None).Returns(PalletVersionHandlerCommandTests.MetadataV14_9280);

            _coreService = Substitute.For<ICoreService>();

            _useCase = new SpecVersionCommandHandler(
                _substrateDbContext, 
                _substrateService,
                _logger, 
                Substitute.For<HybridCache>(),
                _coreService);
            //base.Setup();
        }

        [Test]
        public async Task SpecVersionHandlerCommand_InsertNewSpecVersion_ShouldSuceedAsync()
        {
            var res = await _useCase!.HandleInnerAsync(new SpecVersionCommand(1_000, 10_000, MockHash), CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);

            var lastRecord = _substrateDbContext.SpecVersionModels.Last();
            Assert.That(lastRecord.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(lastRecord.BlockStart, Is.EqualTo(10_000));
            Assert.That(lastRecord.BlockEnd, Is.Null);
            Assert.That(lastRecord.MetadataVersion, Is.EqualTo(14));
            Assert.That(lastRecord.Metadata, Is.EqualTo(PalletVersionHandlerCommandTests.MetadataV14_9280));
        }

        [Test]
        public async Task SpecVersionHandlerCommand_InsertNewSpecVersion_WithPreviousVersion_ShouldUpdatePreviousVersionEndBlock_ShouldSuceedAsync()
        {
            _substrateDbContext.SpecVersionModels.Add(new Infrastructure.Database.Contracts.Model.Version.SpecVersionModel()
            {
                BlockchainName = "Polkadot",
                BlockStart = 5_000,
                BlockStartDateTime = new DateTime(2024, 01, 01),
                BlockEnd = null,
                BlockEndDateTime = null,
                Id = 1,
                Metadata = PalletVersionHandlerCommandTests.MetadataV14_9280,
                MetadataVersion = 14,
                SpecVersion = 999
            });
            _substrateDbContext.SaveChanges();
            _coreService.GetDateTimeFromTimestampAsync(9999, CancellationToken.None).Returns(new DateTime(2024, 02, 02));


            var res = await _useCase!.HandleInnerAsync(new SpecVersionCommand(1_000, 10_000, MockHash), CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);

            var firstRecord = _substrateDbContext.SpecVersionModels.First();
            Assert.That(firstRecord.BlockStart, Is.EqualTo(5_000));
            Assert.That(firstRecord.BlockEnd, Is.EqualTo(9_999));
            Assert.That(firstRecord.BlockEndDateTime, Is.EqualTo(new DateTime(2024, 02, 02)));
            Assert.That(firstRecord.SpecVersion, Is.EqualTo(999));

            var lastRecord = _substrateDbContext.SpecVersionModels.Last();
            Assert.That(lastRecord.BlockStart, Is.EqualTo(10_000));
        }
    }
}
