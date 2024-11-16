using Microsoft.Extensions.Logging;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Common.Search;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Database.Repository.Events.Nfts;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Nfts
{
    public class NftsCreatedRepositoryTest : EventsDatabaseTests
    {
        private NftsCreatedRepository _nftsCreatedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsCreatedRepository = new NftsCreatedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsCreatedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsCreated.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "Created", 10, Bob.ToString(), Charlie.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsCreatedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockAddress2, MockAddress3)]
        public async Task BuildModel_WhenValidCreated_ShouldBuildModelSuccessfullyAsync(double collection, string creator, string owner)
        {
            var enumCreated = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumCreated.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.Created,
                    new BaseTuple<IncrementableU256, SubstrateAccount, SubstrateAccount>(
                        new IncrementableU256(collection), new SubstrateAccount(creator), new SubstrateAccount(owner)
                        )

            );

            var model = await _nftsCreatedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "Created"),
                enumCreated,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Created"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Creator, Is.EqualTo(creator));
Assert.That(model.Owner, Is.EqualTo(owner));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsCreatedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Creator = Bob.ToString(),
				Owner = Charlie.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
