using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
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
            _substrateService.Storage.System.BlockHashAsync(Arg.Any<U32>(), CancellationToken.None).Returns(new Substrate.NetApi.Model.Types.Base.Hash("0x22959625a0a149e2a5e1a9f05bc645f5742a1331f785e98a5569a4157fb68b69"));
            _substrateService.Rpc.State.GetMetaDataAtAsync(Arg.Any<string>(), CancellationToken.None).Returns("AwesomeMetadata");

            _substrateDbContext = new SubstrateDbContext(contextOption);

            _useCase = new SpecVersionCommandHandler(_substrateDbContext, _substrateService, _metadataService, _logger);
            base.Setup();
        }

        [Test]
        public async Task SpecVersionHandlerCommand_InsertNewSpecVersion_ShouldSuceedAsync()
        {
            var res = await _useCase!.Handle(new SpecVersionCommand()
            {
                SpecVersion = 1_000,
                BlockStart = 10000,
                BlockEnd = 100_000,
            }, CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);

            var lastRecord = _substrateDbContext.SpecVersionModels.Last();
            Assert.That(lastRecord.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(lastRecord.BlockStart, Is.EqualTo(10_000));
            Assert.That(lastRecord.BlockEnd, Is.EqualTo(100_000));
        }
    }
}
