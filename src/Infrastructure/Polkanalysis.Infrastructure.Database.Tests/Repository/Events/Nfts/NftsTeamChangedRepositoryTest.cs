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
    public class NftsTeamChangedRepositoryTest : EventsDatabaseTests
    {
        private NftsTeamChangedRepository _nftsTeamChangedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsTeamChangedRepository = new NftsTeamChangedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsTeamChangedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsTeamChanged.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "TeamChanged", 10, Bob.ToString(), Charlie.ToString(), Dave.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsTeamChangedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockAddress2, null, null)]
        public async Task BuildModel_WhenValidTeamChanged_Null_ShouldBuildModelSuccessfullyAsync(double collection, string? issuer, string? admin, string? freezer)
        {
            var enumTeamChanged = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumTeamChanged.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TeamChanged,
                    new BaseTuple<IncrementableU256, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>>(
                        new IncrementableU256(collection), new BaseOpt<SubstrateAccount>(new SubstrateAccount(issuer)), new BaseOpt<SubstrateAccount>(), new BaseOpt<SubstrateAccount>()
                        )

            );

            await _nftsTeamChangedRepository.InsertAsync(BuildEventModel("Nfts", "TeamChanged"), enumTeamChanged, CancellationToken.None);
            _substrateDbContext.SaveChanges();

            var lastEntry = _substrateDbContext.EventNftsTeamChanged.Last();
            Assert.That(lastEntry.Issuer, Is.Not.Null);
            Assert.That(lastEntry.Admin, Is.Empty);
        }
        [Test]
        [TestCase(0, MockAddress2, MockAddress3, MockAddress4)]
        public async Task BuildModel_WhenValidTeamChanged_ShouldBuildModelSuccessfullyAsync(double collection, string? issuer, string? admin, string? freezer)
        {
            var enumTeamChanged = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumTeamChanged.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TeamChanged,
                    new BaseTuple<IncrementableU256, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>, BaseOpt<SubstrateAccount>>(
                        new IncrementableU256(collection), new BaseOpt<SubstrateAccount>(new SubstrateAccount(issuer)), new BaseOpt<SubstrateAccount>(new SubstrateAccount(admin)), new BaseOpt<SubstrateAccount>(new SubstrateAccount(freezer))
                        )

            );

            var model = await _nftsTeamChangedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "TeamChanged"),
                enumTeamChanged,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("TeamChanged"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Issuer, Is.EqualTo(issuer));
Assert.That(model.Admin, Is.EqualTo(admin));
Assert.That(model.Freezer, Is.EqualTo(freezer));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsTeamChangedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Issuer = Bob.ToString(),
				Admin = Charlie.ToString(),
				Freezer = Dave.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
