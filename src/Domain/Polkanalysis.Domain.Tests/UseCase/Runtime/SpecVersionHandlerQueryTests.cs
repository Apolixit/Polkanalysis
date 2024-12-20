﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module.SpecVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Substrate.NetApi.Model.Types.Base;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class SpecVersionHandlerQueryTests :
        UseCaseTest<SpecVersionHandler, IEnumerable<SpecVersionDto>, SpecVersionsQuery>
    {
        [SetUp]
        public void Setup()
        {
            _logger = Substitute.For<ILogger<SpecVersionHandler>>();
            _useCase = new SpecVersionHandler(_substrateDbContext, _substrateService, _logger, Substitute.For<IDistributedCache>());
        }

        private void insertRuntimeVersion(int i)
        {
            var model = new SpecVersionModel()
            {
                BlockchainName = "Polkadot",
                SpecVersion = (uint)(i),
                BlockStart = (uint)(10 * i),
                BlockEnd = (uint)(100 * i),
                Metadata = string.Empty,
            };

            _substrateDbContext.Add(model);
            _substrateDbContext.SaveChanges();
        }

        [Test]
        public async Task SpecVersionHandlerQuery_GetAll_ShouldSuceedAsync()
        {
            _substrateService.Rpc.Chain.GetBlockHashAsync(Arg.Any<BlockNumber>(), Arg.Any<CancellationToken>()).Returns(new Hash("xxxx"));

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(0));

            insertRuntimeVersion(1);

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(1));

            insertRuntimeVersion(2);

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(2));

            insertRuntimeVersion(3);

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(3));

            var res = await _useCase!.HandleInnerAsync(new SpecVersionsQuery(), CancellationToken.None);
            Assert.That(res.IsSuccess, Is.True);

            var lastRecord = res.Value.Last();
            Assert.That(lastRecord.SpecVersion, Is.EqualTo(3));
        }
    }
}
