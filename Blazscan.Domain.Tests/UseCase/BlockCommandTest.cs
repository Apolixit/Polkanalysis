using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts;
using Blazscan.Domain.Contracts.Dto.Block;
using Blazscan.Domain.UseCase;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.UseCase
{
    public class BlockCommandTest
    {
        private readonly IBlockRepository _blockRepository;
        protected readonly ILogger<BlockUseCase> _logger;

        public BlockCommandTest()
        {
            _blockRepository = Substitute.For<IBlockRepository>();
            _logger = Substitute.For<ILogger<BlockUseCase>>();
        }

        [Test]
        public async Task BlockUseCaseWithNullRequest_ShouldFailedAsync()
        {
            var useCase = new BlockUseCase(_blockRepository, _logger);
            var result = await useCase.ExecuteAsync(null, CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyParam);
        }

        [Test]
        public async Task BlockUseCaseReturnNullDto_ShouldFailedAsync()
        {
            var useCase = new BlockUseCase(_blockRepository, _logger);
            var result = await useCase.ExecuteAsync(
                new Contracts.Primary.BlockCommand(1), CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task BlockUseCaseWithBlockNumber_ShouldSucceedAsync()
        {
            var useCase = new BlockUseCase(_blockRepository, _logger);

            _blockRepository.GetBlockDetailsAsync(Arg.Any<uint>(), CancellationToken.None).Returns(Substitute.For<BlockDto>());

            var result = await useCase.ExecuteAsync(
                new Contracts.Primary.BlockCommand(1), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task BlockUseCaseWithBlockHash_ShouldSucceedAsync()
        {
            var useCase = new BlockUseCase(_blockRepository, _logger);

            _blockRepository.GetBlockDetailsAsync(Arg.Any<Hash>(), CancellationToken.None).Returns(Substitute.For<BlockDto>());

            var result = await useCase.ExecuteAsync(
                new Contracts.Primary.BlockCommand("0x00"), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }
    }
}
