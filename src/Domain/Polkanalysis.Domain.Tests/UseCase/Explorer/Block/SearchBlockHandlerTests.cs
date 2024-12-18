using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Block;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Block;
using Polkanalysis.Domain.Contracts.Service;
using Polkanalysis.Domain.UseCase.Explorer.Block;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Block
{
    public class SearchBlockHandlerTests : UseCaseTest<SearchBlockHandler, IQueryable<BlockLightDto>, SearchBlocksQuery>
    {
        private IExplorerService _explorerService = default!;
        private IAccountService _accountService = default!;

        [SetUp]
        public void Setup()
        {
            _explorerService = Substitute.For<IExplorerService>();
            _accountService = Substitute.For<IAccountService>();
            var logger = Substitute.For<ILogger<SearchBlockHandler>>();

            _useCase = new SearchBlockHandler(_substrateDbContext, logger, Substitute.For<HybridCache>(), _accountService);
        }

        [Test]
        public async Task SearchBlock_WithValidData_ShouldSucceedAsync()
        {
            _substrateDbContext.BlockInformation.Add(new Infrastructure.Database.Contracts.Model.Blocks.BlockInformationModel() { 
                BlockchainName = "Polkadot", 
                BlockNumber = 1, 
                BlockHash = "0x1234567890", 
                EventsCount = 1, 
                ExtrinsicsCount = 1, 
                LogsCount = 1, 
                BlockDate = DateTime.Now, 
                ValidatorAddress = "Alice" }
            );
            await _substrateDbContext.SaveChangesAsync();

            var res = await _useCase!.Handle(new SearchBlocksQuery(), CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);

            var first = res.Value.ToList()[0];
            Assert.That(first.Hash.Value, Is.EqualTo("0x1234567890"));
            Assert.That(first.Number, Is.EqualTo(1));
            Assert.That(first.NbEvents, Is.EqualTo(1));
            Assert.That(first.NbExtrinsics, Is.EqualTo(1));
            Assert.That(first.NbLogs, Is.EqualTo(1));
            Assert.That(first.ValidatorAddress, Is.EqualTo("Alice"));
        }
    }
}
