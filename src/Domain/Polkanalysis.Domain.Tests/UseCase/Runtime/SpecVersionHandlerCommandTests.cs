using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;
using Substrate.NET.Metadata.Service;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class SpecVersionHandlerCommandTests
        : UseCaseTest<SpecVersionCommandHandler, bool, SpecVersionCommand>
    {
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

            _useCase = new SpecVersionCommandHandler(
                _substrateDbContext, 
                _substrateService,
                _logger, 
                Substitute.For<IDistributedCache>(),
                Substitute.For<ICoreService>());
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
    }
}
