using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.SpecVersion;
using Polkanalysis.Domain.UseCase.Runtime.SpecVersion;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using Polkanalysis.Infrastructure.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Domain.Contracts.Dto.Module;
using Polkanalysis.Domain.UseCase.Runtime.PalletVersion;
using Polkanalysis.Domain.Contracts.Primary.RuntimeModule.PalletVersion;

namespace Polkanalysis.Domain.Tests.UseCase.Runtime
{
    public class PalletVersionHandlerQueryTests :
        UseCaseTest<PalletVersionHandler, IEnumerable<PalletVersionDto>, PalletVersionsQuery>
    {
        private SubstrateDbContext _substrateDbContext;

        [SetUp]
        public override void Setup()
        {
            _logger = Substitute.For<ILogger<PalletVersionHandler>>();

            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
            .Options;

            _substrateDbContext = new SubstrateDbContext(contextOption);

            _useCase = new PalletVersionHandler(_substrateDbContext, _logger);
            base.Setup();
        }

        private void insertPalletVersion(int i, string palletName)
        {
            var model = new PalletVersionModel()
            {
                PalletId = Faker.RandomNumber.Next(1000),
                BlockchainName = "Polkadot",
                PalletVersion = i,
                BlockStart = (uint)(10 * i),
                BlockEnd = (uint)(100 * i),
                PalletName = palletName
            };

            _substrateDbContext.Add(model);
            _substrateDbContext.SaveChanges();
        }

        [Test]
        [TestCase("MyAwesomePallet")]
        public async Task PalletVersionHandlerQuery_GetAll_ShouldSuceedAsync(string palletName)
        {
            insertPalletVersion(1, palletName);
            insertPalletVersion(2, palletName);
            insertPalletVersion(3, palletName);

            Assert.That(_substrateDbContext.PalletVersionModels.Count(), Is.EqualTo(3));

            var res = await _useCase!.Handle(new PalletVersionsQuery()
            {
                PalletName = palletName
            }, CancellationToken.None);

            Assert.That(res.IsSuccess, Is.True);

            var lastRecord = res.Value.Last();
            Assert.That(lastRecord.PalletVersion, Is.EqualTo(3));
        }
    }
}
