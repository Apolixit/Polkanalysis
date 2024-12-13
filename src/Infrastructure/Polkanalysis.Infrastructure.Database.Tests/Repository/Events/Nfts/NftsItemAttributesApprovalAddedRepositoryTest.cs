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
    public class NftsItemAttributesApprovalAddedRepositoryTest : EventsDatabaseTests
    {
        private NftsItemAttributesApprovalAddedRepository _nftsItemAttributesApprovalAddedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsItemAttributesApprovalAddedRepository = new NftsItemAttributesApprovalAddedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<IHubConnection>(),
                Substitute.For<ILogger<NftsItemAttributesApprovalAddedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsItemAttributesApprovalAdded.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ItemAttributesApprovalAdded", 10, MockItemNft, Charlie.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsItemAttributesApprovalAddedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockItemNft, MockAddress3, MockItemNft)]
        public async Task BuildModel_WhenValidItemAttributesApprovalAdded_ShouldBuildModelSuccessfullyAsync(double collection, string item, string delegateParam, string expected1)
        {
            var enumItemAttributesApprovalAdded = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumItemAttributesApprovalAdded.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ItemAttributesApprovalAdded,
                    new BaseTuple<IncrementableU256, U128, SubstrateAccount>(
                        new IncrementableU256(collection), new U128(BigInteger.Parse(item)), new SubstrateAccount(delegateParam)
                        )

            );

            var model = await _nftsItemAttributesApprovalAddedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ItemAttributesApprovalAdded"),
                enumItemAttributesApprovalAdded,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ItemAttributesApprovalAdded"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Delegate, Is.EqualTo(delegateParam));
Assert.That(model.ItemValue(), Is.EqualTo(BigInteger.Parse(expected1)));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsItemAttributesApprovalAddedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = MockItemNft,
				Delegate = Charlie.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
