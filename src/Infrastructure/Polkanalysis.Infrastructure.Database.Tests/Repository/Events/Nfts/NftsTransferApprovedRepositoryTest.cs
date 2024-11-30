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
    public class NftsTransferApprovedRepositoryTest : EventsDatabaseTests
    {
        private NftsTransferApprovedRepository _nftsTransferApprovedRepository;

        [SetUp]
        public void Setup()
        {
            _nftsTransferApprovedRepository = new NftsTransferApprovedRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsTransferApprovedRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsTransferApproved.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "TransferApproved", 10, MockItemNft, Charlie.ToString(), Dave.ToString(), 50));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsTransferApprovedRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockItemNft, MockAddress3, MockAddress4, 40u, MockItemNft)]
        public async Task BuildModel_WhenValidTransferApproved_ShouldBuildModelSuccessfullyAsync(double collection, string item, string owner, string delegateParam, uint? deadline, string expected1)
        {
            var bt = new BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount, BaseOpt<U32>>();
            bt.Create(new IncrementableU256(collection), new U128(BigInteger.Parse(item)), new SubstrateAccount(owner), new SubstrateAccount(delegateParam), new BaseOpt<U32>(new U32(deadline!.Value)));

            var enumTransferApproved = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumTransferApproved.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.TransferApproved, bt);

            var model = await _nftsTransferApprovedRepository.BuildModelAsync(
                BuildEventModel("Nfts", "TransferApproved"),
                enumTransferApproved,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("TransferApproved"));
            Assert.That(model.Collection, Is.EqualTo(collection));
            Assert.That(model.Owner, Is.EqualTo(owner));
            Assert.That(model.Delegate, Is.EqualTo(delegateParam));
            Assert.That(model.Deadline, Is.EqualTo(deadline));
            Assert.That(model.ItemValue(), Is.EqualTo(BigInteger.Parse(expected1)));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsTransferApprovedRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
                Item = MockItemNft,
                Owner = Charlie.ToString(),
                Delegate = Dave.ToString(),
                Deadline = NumberCriteria<uint>.Equal(50)
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
