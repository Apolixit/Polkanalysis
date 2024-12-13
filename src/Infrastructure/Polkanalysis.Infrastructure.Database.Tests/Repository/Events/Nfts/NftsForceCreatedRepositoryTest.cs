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
using Polkanalysis.Hub;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Nfts
{
    public class NftsForceCreatedRepositoryTest : EventsDatabaseTests
    {
        private NftsForceCreatedRepository _nftsForceCreatedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsForceCreatedRepository = new NftsForceCreatedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsForceCreatedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsForceCreated.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ForceCreated", 10, Bob.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsForceCreatedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockAddress2)]
        public async Task BuildModel_WhenValidForceCreated_ShouldBuildModelSuccessfullyAsync(double collection, string owner)
        {
            var enumForceCreated = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumForceCreated.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ForceCreated,
                    new BaseTuple<IncrementableU256, SubstrateAccount>(
                        new IncrementableU256(collection), new SubstrateAccount(owner)
                        )

            );

            var model = await _nftsForceCreatedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ForceCreated"),
                enumForceCreated,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ForceCreated"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Owner, Is.EqualTo(owner));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsForceCreatedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Owner = Bob.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
