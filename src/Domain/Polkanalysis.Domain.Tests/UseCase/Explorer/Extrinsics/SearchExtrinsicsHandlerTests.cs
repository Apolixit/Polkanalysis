using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Extrinsic;
using Polkanalysis.Domain.Contracts.Primary.Explorer.Extrinsic;
using Polkanalysis.Domain.UseCase.Explorer.Extrinsics;

namespace Polkanalysis.Domain.Tests.UseCase.Explorer.Extrinsics
{
    public class SearchExtrinsicsHandlerTests : UseCaseTest<SearchExtrinsicsHandler, IQueryable<ExtrinsicLightDto>, SearchExtrinsicsQuery>
    {
        [SetUp]
        public void Setup()
        {
            var logger = Substitute.For<ILogger<SearchExtrinsicsHandler>>();

            _useCase = new SearchExtrinsicsHandler(logger, Substitute.For<IDistributedCache>(), _substrateDbContext);
        }

        [Test]
        public async Task SearchExtrinsic_WithValidData_ShouldSuceedAsync()
        {
            PopulateDatabaseWithSomeEvents();

            _substrateDbContext.ExtrinsicsInformation.Add(new Infrastructure.Database.Contracts.Model.Extrinsics.ExtrinsicsInformationModel()
            {
                BlockchainName = "Polkadot",
                BlockNumber = 1,
                BlockDate = DateTime.Now,
                Event = "Event",
                Method = "Method",
                Charge = 0.12,
                ExtrinsicIndex = 1,
                Fees = 0.12,
                IsSigned = true,
                AccountAddress = Alice.ToString(),
                Lifetime = new Infrastructure.Database.Contracts.Model.Staking.EraLifetimeModel()
                {
                    BlockchainName = "Polkadot",
                    IsImmortal = false,
                    StartBlock = 1,
                    EndBlock = 2
                },
                Signature = "0x1234567890",
                Status = "Success",
                StatusMessage = "Success",
                TransactionVersion = 4
            });

            await _substrateDbContext.SaveChangesAsync(CancellationToken.None);

            var res = await _useCase!.Handle(new SearchExtrinsicsQuery(), CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);
        }
    }
}
