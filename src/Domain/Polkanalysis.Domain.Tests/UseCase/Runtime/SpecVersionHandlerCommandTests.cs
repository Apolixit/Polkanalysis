using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Substrate.NET.Metadata.Service;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class SpecVersionHandlerCommandTests
        : UseCaseTest<SpecVersionCommandHandler, bool, SpecVersionCommand>
    {
        private SubstrateDbContext _substrateDbContext;
        private ISubstrateService _substrateService;
        private IMetadataService _metadataService;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<SpecVersionCommandHandler>>();
            _metadataService = new MetadataService();

            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;

            _substrateService = Substitute.For<ISubstrateService>();
            _substrateService.BlockchainName.Returns("Polkadot");

            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), CancellationToken.None).Returns(new Hash("0xfc7ed4b4ca798d49e2824868026ddcaf05d7fdd3ebd79a28b5872084c07af210"));
            _substrateService.Rpc.State.GetMetaDataAsync(Arg.Any<byte[]>(), CancellationToken.None).Returns(PalletVersionHandlerCommandTests.MetadataV14_9280);

            _substrateDbContext = new SubstrateDbContext(contextOption);

            _useCase = new SpecVersionCommandHandler(
                _substrateDbContext, 
                _substrateService,
                _logger);
            base.Setup();
        }

        [TearDown]
        public void TearDown()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }

        [Test]
        public async Task SpecVersionHandlerCommand_InsertNewSpecVersion_ShouldSuceedAsync()
        {
            var res = await _useCase!.Handle(new SpecVersionCommand()
            {
                SpecVersion = 1_000,
                BlockStart = 10000
            }, CancellationToken.None);

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
