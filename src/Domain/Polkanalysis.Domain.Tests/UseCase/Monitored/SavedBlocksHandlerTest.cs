using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Dto.User;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Blocks;
using Polkanalysis.Domain.Contracts.Primary.Monitored.Events;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.Service;
using Polkanalysis.Domain.UseCase.Monitored;
using Polkanalysis.Domain.UseCase.Runtime;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Substrate.NetApi;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Monitored
{
    public class SavedBlocksHandlerTest : UseCaseTest<SavedBlocksHandler, bool, SavedBlocksCommand>
    {
        private IExplorerService _explorerService;

        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SavedBlocksHandler>>();
            _explorerService = Substitute.For<IExplorerService>();
            _explorerService.GetBlockLightAsync(Arg.Any<uint>(), Arg.Any<CancellationToken>()).Returns(
                new Contracts.Dto.Block.BlockLightDto()
            {
                Hash = new Hash("0x1234567890"),
                Number = 1,
                Status = Contracts.Dto.GlobalStatusDto.BlockStatusDto.Finalized,
                When = DateTime.Now.ToString(),
                NbEvents = 1,
                NbExtrinsics = 1,
                NbLogs = 1,
                Validator = new UserAddressDto()
                {
                    Name = "Alice",
                    Address = Alice.ToString(),
                    PublicKey = Utils.Bytes2HexString(Alice.Bytes)
                }
            });

            _substrateService.BlockchainName.Returns("Polkadot");

            _useCase = new SavedBlocksHandler(_substrateService,
                                              _substrateDbContext,
                                              _explorerService,
                                              _logger,
                                              Substitute.For<IDistributedCache>());
        }

        [Test]
        public async Task SavedBlocksCommandValidator_WithInvalidData_ShouldFailedAsync()
        {
            _substrateService.Rpc.Chain.GetHeaderAsync(CancellationToken.None)
                .Returns(new Substrate.NetApi.Model.Rpc.Header() { Number = new U64(100) });

            var command = new SavedBlocksCommand(200);

            var validator = new SavedBlocksCommandValidator(_substrateService);

            var result = await validator.ValidateAsync(command);

            Assert.That(result.IsValid, Is.False);
        }

        [Test]
        public async Task SavedBlocksHandler_WithValidData_ShouldSucceedAsync()
        {
            var command = new SavedBlocksCommand(1);

            var result = await _useCase!.Handle(command, CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);

            var lastDbEntry = _substrateDbContext.BlockInformation.Last();
            Assert.That(lastDbEntry.BlockNumber, Is.EqualTo(1));
            Assert.That(lastDbEntry.BlockHash, Is.EqualTo("0x1234567890"));
            Assert.That(lastDbEntry.BlockchainName, Is.EqualTo("Polkadot"));
            Assert.That(lastDbEntry.ValidatorAddress, Is.EqualTo(Alice.ToString()));
        }

        [Test]
        public async Task SavedBlocksHandler_WithDuplicateData_ShouldSucceedButNotInsertTwiceAsync()
        {
            Assert.That(_substrateDbContext.BlockInformation.SingleOrDefault(x => x.BlockHash == "0x1234567890"), Is.Null);
            var command = new SavedBlocksCommand(1);

            await _useCase!.Handle(command, CancellationToken.None);
            Assert.That(_substrateDbContext.BlockInformation.SingleOrDefault(x => x.BlockHash == "0x1234567890"), Is.Not.Null);

            var result = await _useCase!.Handle(command, CancellationToken.None);
            Assert.That(result.IsSuccess, Is.True);
            Assert.That(_substrateDbContext.BlockInformation.SingleOrDefault(x => x.BlockHash == "0x1234567890"), Is.Not.Null);
        }
    }
}
