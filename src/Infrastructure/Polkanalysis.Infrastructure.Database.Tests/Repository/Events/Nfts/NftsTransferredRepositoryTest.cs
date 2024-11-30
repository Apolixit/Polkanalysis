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
    public class NftsTransferredRepositoryTest : EventsDatabaseTests
    {
        private NftsTransferredRepository _nftsTransferredRepository;

        [SetUp]
        public void Setup()
        {
            _nftsTransferredRepository = new NftsTransferredRepository(
                _substrateDbContext,
                _substrateService,
                Substitute.For<ILogger<NftsTransferredRepository>>());
        }

        protected override void mockDatabase()
        {
            _substrateDbContext.EventNftsTransferred.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "Transferred", 10, MockItemNft, Charlie.ToString(), Dave.ToString()));
        }

        [Test]
        public void BasicInformationsAreProperlySet()
        {
            Assert.That(_nftsTransferredRepository.SearchName, Is.Not.Empty);
        }

        [Test]
        [TestCase(0, MockItemNft, MockAddress3, MockAddress4, MockItemNft)]
        public async Task BuildModel_WhenValidTransferred_ShouldBuildModelSuccessfullyAsync(double collection, string item, string from, string to, string expected1)
        {
            var enumTransferred = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumTransferred.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.Transferred,
                    new BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount>(
                        new IncrementableU256(collection), new U128(BigInteger.Parse(item)), new SubstrateAccount(from), new SubstrateAccount(to)
                        )

            );

            var model = await _nftsTransferredRepository.BuildModelAsync(
                BuildEventModel("Nfts", "Transferred"),
                enumTransferred,
                CancellationToken.None);

            Assert.That(model, Is.Not.Null);
            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
            Assert.That(model.ModuleEvent, Is.EqualTo("Transferred"));
            Assert.That(model.Collection, Is.EqualTo(collection));
            Assert.That(model.From, Is.EqualTo(from));
            Assert.That(model.To, Is.EqualTo(to));
            Assert.That(model.ItemValue(), Is.EqualTo(BigInteger.Parse(expected1)));
        }

        [Test]
        [TestCase(0, "310789037729451024594500450253905211276", MockAddress3, MockAddress4, "310789037729451024594500450253905211276")]
        public async Task BuildModel_WhenValidTransferred_ShouldInsertSuccessfullyAsync(double collection, string item, string from, string to, string expected1)
        {
            var enumTransferred = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
            enumTransferred.Create(
                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.Transferred,
                    new BaseTuple<IncrementableU256, U128, SubstrateAccount, SubstrateAccount>(
                        new IncrementableU256(collection), new U128(BigInteger.Parse(item)), new SubstrateAccount(from), new SubstrateAccount(to)
                        )

            );

            await _nftsTransferredRepository.InsertAsync(
                BuildEventModel("Nfts", "Transferred"),
                enumTransferred,
                CancellationToken.None);

            var lastEntry = _substrateDbContext.EventNftsTransferred.Last();
            Assert.That(lastEntry.Collection, Is.EqualTo(collection));
            Assert.That(lastEntry.ItemValue, Is.EqualTo(BigInteger.Parse(expected1)));
        }

        [Test]
        public async Task Search_WithValidParameter_ShouldSuceedAsync()
        {
            var res = await _nftsTransferredRepository.SearchAsync(new()
            {
                Collection = NumberCriteria<double>.Equal(10),
                Item = MockItemNft,
                From = Charlie.ToString(),
                To = Dave.ToString()
            }, CancellationToken.None);

            Assert.That(res.Count(), Is.EqualTo(1));
        }
    }
}
