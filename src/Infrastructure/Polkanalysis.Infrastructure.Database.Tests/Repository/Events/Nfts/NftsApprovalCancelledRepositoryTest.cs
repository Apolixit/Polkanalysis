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
    public class NftsApprovalCancelledRepositoryTest : EventsDatabaseTests
    {
        private NftsApprovalCancelledRepository _nftsApprovalCancelledRepository;

        [SetUp]
        public void Setup()
        {
            _nftsApprovalCancelledRepository = new NftsApprovalCancelledRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsApprovalCancelledRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsApprovalCancelled.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "ApprovalCancelled", 10, 20, Charlie.ToString(), Dave.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsApprovalCancelledRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, 200_000, MockAddress3, MockAddress4, 20)]
        public async Task BuildModel_WhenValidApprovalCancelled_ShouldBuildModelSuccessfullyAsync(double collection, double item, string owner, string delegateParam, double expected1)
        {
            var enumApprovalCancelled = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumApprovalCancelled.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.ApprovalCancelled,
                    new BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount>(
                        new IncrementableU256(collection), new U128(new BigInteger(item)), new SubstrateAccount(owner), new SubstrateAccount(delegateParam)
                        )

            );

            var model = await _nftsApprovalCancelledRepository.BuildModelAsync(
                BuildEventModel("Nfts", "ApprovalCancelled"),
                enumApprovalCancelled,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("ApprovalCancelled"));
            Assert.That(model.Collection, Is.EqualTo(collection));
Assert.That(model.Owner, Is.EqualTo(owner));
Assert.That(model.Delegate, Is.EqualTo(delegateParam));
Assert.That(model.Item, Is.EqualTo(expected1));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsApprovalCancelledRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
				Item = NumberCriteria<double>.Equal(20),
				Owner = Charlie.ToString(),
				Delegate = Dave.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
