using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Dto.Block;
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
using Polkanalysis.Domain.Contracts.Primary.Result;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Service;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Block
{
    public class BlockDetailUseCaseTest : UseCaseTest<BlockDetailHandler, BlockDto, BlockDetailsQuery>
    {
        protected IExplorerService _explorerService;

        [SetUp]
        public void Setup()
        {
            _explorerService = Substitute.For<IExplorerService>();
            _logger = Substitute.For<ILogger<BlockDetailHandler>>();
            _useCase = new BlockDetailHandler(_explorerService, _logger);
            //base.Setup();
        }

        [Test]
        public async Task BlockDetailUseCaseReturnNullDto_ShouldFailedAsync()
        {
            _explorerService.GetBlockDetailsAsync(Arg.Any<uint>(), CancellationToken.None).ReturnsNull();

            var result = await _useCase.Handle(new BlockDetailsQuery(1), CancellationToken.None);

            Assert.That(result.IsError, Is.True);
            Assert.That(result.Value, Is.Null);
            Assert.That(result.Error, Is.Not.Null);
            Assert.That(result.Error.Status == ErrorResult.ErrorType.EmptyModel);
        }

        [Test]
        public async Task BlockDetailUseCaseWithBlockNumber_ShouldSucceedAsync()
        {
            _explorerService.GetBlockDetailsAsync(Arg.Any<uint>(), CancellationToken.None).Returns(Substitute.For<BlockDto>());

            var result = await _useCase.Handle(new BlockDetailsQuery(1), CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.Not.Null);
        }

        [Test]
        public async Task BlockDetailCaseWithBlockHash_ShouldSucceedAsync()
        {
            _explorerService.GetBlockDetailsAsync(Arg.Any<string>(), CancellationToken.None).Returns(Substitute.For<BlockDto>());

            var result = await _useCase.Handle(new BlockDetailsQuery("0x00"), CancellationToken.None);

            Assert.That(result.IsSuccess, Is.True);
            Assert.That(result.Value, Is.Not.Null);
        }
    }
}
