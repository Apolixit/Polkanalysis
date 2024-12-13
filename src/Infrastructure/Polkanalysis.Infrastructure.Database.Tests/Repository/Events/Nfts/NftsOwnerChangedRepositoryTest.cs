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
    public class NftsOwnerChangedRepositoryTest : EventsDatabaseTests
    {
        private NftsOwnerChangedRepository _nftsOwnerChangedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsOwnerChangedRepository = new NftsOwnerChangedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsOwnerChangedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsOwnerChanged.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "OwnerChanged", 10, Bob.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsOwnerChangedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockAddress2)]
        public async Task BuildModel_WhenValidOwnerChanged_ShouldBuildModelSuccessfullyAsync(double collection, string new_owner)
        {
            var enumOwnerChanged = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumOwnerChanged.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.OwnerChanged,
                    new BaseTuple<IncrementableU256, SubstrateAccount>(
                        new IncrementableU256(collection), new SubstrateAccount(new_owner)
                        )

            );

            var model = await _nftsOwnerChangedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "OwnerChanged"),
                enumOwnerChanged,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("OwnerChanged"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.New_owner, Is.EqualTo(new_owner));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsOwnerChangedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				New_owner = Bob.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
