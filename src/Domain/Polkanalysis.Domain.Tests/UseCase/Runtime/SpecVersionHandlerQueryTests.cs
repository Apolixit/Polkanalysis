using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.Contracts.Runtime.Module;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.UseCase.Runtime;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Substrate.NetApi.Model.Meta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class SpecVersionHandlerQueryTests :
        UseCaseTest<SpecVersionHandler, IEnumerable<SpecVersionDto>, SpecVersionsQuery>
    {
        private SubstrateDbContext _substrateDbContext;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<SpecVersionHandler>>();

            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;

            _substrateDbContext = new SubstrateDbContext(contextOption);

            _useCase = new SpecVersionHandler(_substrateDbContext, _logger);
            base.Setup();
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
            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(0));

            insertRuntimeVersion(1);

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(1));

            insertRuntimeVersion(2);

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(2));

            insertRuntimeVersion(3);

            Assert.That(_substrateDbContext.SpecVersionModels.Count(), Is.EqualTo(3));

            var res = await _useCase!.Handle(new SpecVersionsQuery(), CancellationToken.None);
            Assert.That(res.IsSuccess, Is.True);

            var lastRecord = res.Value.Last();
            Assert.That(lastRecord.SpecVersion, Is.EqualTo(3));
        }
    }
}
