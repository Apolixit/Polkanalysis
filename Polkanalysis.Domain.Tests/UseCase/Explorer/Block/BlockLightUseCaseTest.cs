using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Polkanalysis.Domain.UseCase;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute.ReturnsExtensions;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.Contracts.Secondary.Repository;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Block
{
    public class BlockLightUseCaseTest : UseCaseTest<BlockLightUseCase, BlockLightDto, BlockCommand>
    {
        private IExplorerRepository _explorerRepository;

        [SetUp]
        public override void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerRepository>();
            _logger = Substitute.For<ILogger<BlockLightUseCase>>();
            _useCase = new BlockLightUseCase(_explorerRepository, _logger);
        }

        [Test]
        public async Task BlockLightUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerRepository.GetBlockLightAsync(Arg.Any<uint>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase.ExecuteAsync(new BlockCommand(1), CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task BlockLightUseCaseWithBlockNumber_ShouldSucceedAsync()
        {
            _explorerRepository.GetBlockLightAsync(1, CancellationToken.None).Returns(Substitute.For<BlockLightDto>());

            var result = await _useCase.ExecuteAsync(new BlockCommand(1), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task BlockLightUseCaseWithBlockHash_ShouldSucceedAsync()
        {
            _explorerRepository.GetBlockLightAsync(Arg.Any<string>(), CancellationToken.None).Returns(Substitute.For<BlockLightDto>());

            var result = await _useCase.ExecuteAsync(new BlockCommand("0x00"), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }
    }
}
