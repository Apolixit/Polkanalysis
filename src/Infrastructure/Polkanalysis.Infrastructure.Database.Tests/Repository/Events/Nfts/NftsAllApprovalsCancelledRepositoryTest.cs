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
    public class NftsAllApprovalsCancelledRepositoryTest : EventsDatabaseTests
    {
        private NftsAllApprovalsCancelledRepository _nftsAllApprovalsCancelledRepository;

        [SetUp]
        public void Setup()
        {
            _nftsAllApprovalsCancelledRepository = new NftsAllApprovalsCancelledRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsAllApprovalsCancelledRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsAllApprovalsCancelled.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "AllApprovalsCancelled", 10, 20, Charlie.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsAllApprovalsCancelledRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000_000_000, MockAddress3, 20)]
        public async Task BuildModel_WhenValidAllApprovalsCancelled_ShouldBuildModelSuccessfullyAsync(double collection, double item, string owner, double expected1)
        {
            var enumAllApprovalsCancelled = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumAllApprovalsCancelled.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.AllApprovalsCancelled,
                    new BaseTuple<IncrementableU256, U128, SubstrateAccount>(
                        new IncrementableU256(collection), new U128(new BigInteger(item)), new SubstrateAccount(owner)
                        )

            );

            var model = await _nftsAllApprovalsCancelledRepository.BuildModelAsync(
                BuildEventModel("Nfts", "AllApprovalsCancelled"),
                enumAllApprovalsCancelled,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("AllApprovalsCancelled"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Owner, Is.EqualTo(owner));
Assert.That(model.Item, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsAllApprovalsCancelledRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20),
				Owner = Charlie.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
