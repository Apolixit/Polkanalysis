using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary;
using Polkanalysis.Domain.UseCase;
using Polkanalysis.Domain.UseCase.Explorer;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Contracts.Primary.Result;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Block
{
    public class BlockDetailUseCaseTest : UseCaseTest<BlockDetailUseCase, BlockDto, BlockCommand>
    {
        protected IExplorerRepository _explorerRepository;

        [SetUp]
        public override void Setup()
        {
            _explorerRepository = Substitute.For<IExplorerRepository>();
            _logger = Substitute.For<ILogger<BlockDetailUseCase>>();
            _useCase = new BlockDetailUseCase(_explorerRepository, _logger);
            base.Setup();
        }

        [Test]
        public async Task BlockDetailUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerRepository.GetBlockDetailsAsync(Arg.Any<uint>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase.ExecuteAsync(new BlockCommand(1), CancellationToken.None);

            Assert.IsTrue(result.IsError);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task BlockDetailUseCaseWithBlockNumber_ShouldSucceedAsync()
        {
            _explorerRepository.GetBlockDetailsAsync(Arg.Any<uint>(), CancellationToken.None).Returns(Substitute.For<BlockDto>());

            var result = await _useCase.ExecuteAsync(new BlockCommand(1), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task BlockDetailCaseWithBlockHash_ShouldSucceedAsync()
        {
            _explorerRepository.GetBlockDetailsAsync(Arg.Any<string>(), CancellationToken.None).Returns(Substitute.For<BlockDto>());

            var result = await _useCase.ExecuteAsync(new BlockCommand("0x00"), CancellationToken.None);

            Assert.IsTrue(result.IsSuccess);
            Assert.That(result.Value, Is.Not.Null);
        }
    }
}
