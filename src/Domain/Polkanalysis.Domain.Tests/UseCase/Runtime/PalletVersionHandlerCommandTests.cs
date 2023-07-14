using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.UseCase.Runtime.PalletVersion;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class PalletVersionHandlerCommandTests
        : UseCaseTest<PalletVersionCommandHandler, bool, PalletVersionCommand>
    {
        private SubstrateDbContext _substrateDbContext;
        private ISubstrateService _substrateService;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<PalletVersionCommandHandler>>();

            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;

            _substrateService = Substitute.For<ISubstrateService>();
            _substrateService.BlockchainName.Returns("Polkadot");
            _substrateService.RuntimeMetadata.NodeMetadata.Modules.Returns(
                new Dictionary<uint, Substrate.NetApi.Model.Meta.PalletModule>()
                {{ 1, new Substrate.NetApi.Model.Meta.PalletModule() {
                    Index = 1,
                    Name = "TestPallet"
                } }});

            _substrateDbContext = new SubstrateDbContext(contextOption);

            _useCase = new PalletVersionCommandHandler(_substrateDbContext, _logger, _substrateService);
            base.Setup();
        }

        [Test]
        public async Task SpecVersionHandlerCommand_InsertNewSpecVersion_ShouldSuceedAsync()
        {
            var res = await _useCase!.Handle(new PalletVersionCommand()
            {
                PalletId = 1,
                PalletVersion = 2,
                BlockStart = 10000,
                BlockEnd = 100_000,
            }, CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);

            var lastRecord = _substrateDbContext.PalletVersionModels.Last();
            Assert.That(lastRecord.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(lastRecord.BlockStart, Is.EqualTo(10_000));
            Assert.That(lastRecord.BlockEnd, Is.EqualTo(100_000));
            Assert.That(lastRecord.PalletName, Is.EqualTo("TestPallet"));
        }
    }
}
