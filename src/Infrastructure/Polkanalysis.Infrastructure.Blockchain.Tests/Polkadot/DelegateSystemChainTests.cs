using Castle.Core.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Infrastructure.Blockchain.Common;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot.Repository;
using Polkanalysis.Infrastructure.Database;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Tests.Polkadot
{
    internal class DelegateSystemChainTests : PolkadotMock
    {
        private DelegateSystemChain _delegateSystemChain;
        private SubstrateDbContext _substrateDbContext;

        [SetUp]
        public void SetupDelegateSystemChain()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;
            _substrateDbContext = new SubstrateDbContext(contextOption);

            _delegateSystemChain = new DelegateSystemChain(_substrateService, _substrateDbContext, Substitute.For<ILogger<DelegateSystemChain>>());
        }

        [TearDown]
        public void TearDownDelegateSystemChain()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }

        [Test]
        public async Task CurrentBlockForSystemChain_FromDatabase_ShouldSucceedAsync()
        {
            _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
            {
                BlockchainName = "PeopleChain",
                BlockNumber = 1000,
                BlockDate = new DateTime(2024, 01, 01, 01, 00, 00).ToUniversalTime(),
                BlockHash = "don't care",
                EventsCount = 0,
                ExtrinsicsCount = 0,
                LogsCount = 0,
                ValidatorAddress = "don't care"
            });
            _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
            {
                BlockchainName = "PeopleChain",
                BlockNumber = 1001,
                BlockDate = new DateTime(2024, 01, 01, 01, 00, 12).ToUniversalTime(),
                BlockHash = "don't care",
                EventsCount = 0,
                ExtrinsicsCount = 0,
                LogsCount = 0,
                ValidatorAddress = "don't care"
            });
            _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
            {
                BlockchainName = "PeopleChain",
                BlockNumber = 1002,
                BlockDate = new DateTime(2024, 01, 01, 01, 00, 25).ToUniversalTime(), // A bit more than 12s
                BlockHash = "don't care",
                EventsCount = 0,
                ExtrinsicsCount = 0,
                LogsCount = 0,
                ValidatorAddress = "don't care"
            });
            _substrateDbContext.BlockInformation.Add(new Database.Contracts.Model.Blocks.BlockInformationModel()
            {
                BlockchainName = "PeopleChain",
                BlockNumber = 1003,
                BlockDate = new DateTime(2024, 01, 01, 01, 00, 40).ToUniversalTime(), // More than 12s
                BlockHash = "don't care",
                EventsCount = 0,
                ExtrinsicsCount = 0,
                LogsCount = 0,
                ValidatorAddress = "don't care"
            });
            _substrateDbContext.SaveChanges();

            var timestamp = (ulong)new DateTimeOffset(new DateTime(2024, 01, 01, 01, 00, 22).ToUniversalTime()).ToUnixTimeMilliseconds();
            _substrateService.AjunaClient.GetStorageAsync<U64>(Arg.Any<string>(), "blockHashFromPolkadot", CancellationToken.None).Returns(new U64(timestamp));

            var res = await _delegateSystemChain.CurrentBlockForSystemChainAsync(
                _peopleChainService.AjunaClient,
                "PeopleChain",
                "blockHashFromPolkadot",
                CancellationToken.None);

            Assert.That(res, Is.EqualTo(1002));
        }

    }
}
