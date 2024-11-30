//using Microsoft.Extensions.Logging;
//using NSubstitute;
//using Polkanalysis.Domain.Contracts.Common.Search;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Core;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
//using Polkanalysis.Infrastructure.Database.Repository.Events.Nfts;
//using Substrate.NetApi.Model.Types.Base;
//using Substrate.NetApi.Model.Types.Primitive;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Numerics;
//using System.Text;
//using System.Threading.Tasks;
//using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Types;

//namespace Polkanalysis.Infrastructure.Database.Tests.Repository.Events.Nfts
//{
//    public class NftsOwnershipAcceptanceChangedRepositoryTest : EventsDatabaseTests
//    {
//        private NftsOwnershipAcceptanceChangedRepository _nftsOwnershipAcceptanceChangedRepository;

//        [SetUp]
//        public void Setup()
//        {
//            _nftsOwnershipAcceptanceChangedRepository = new NftsOwnershipAcceptanceChangedRepository(
//                _substrateDbContext,
//                _substrateService,
//                Substitute.For<ILogger<NftsOwnershipAcceptanceChangedRepository>>());
//        }

//        protected override void mockDatabase()
//        {
//            _substrateDbContext.EventNftsOwnershipAcceptanceChanged.Add(new("Polkadot", 0, new DateTime(2024, 01, 01), 0, "Nfts", "OwnershipAcceptanceChanged", Alice.ToString(), 20));
//        }

//        [Test]
//        public void BasicInformationsAreProperlySet()
//        {
//            Assert.That(_nftsOwnershipAcceptanceChangedRepository.SearchName, Is.Not.Empty);
//        }

//        [Test]
//        [TestCase(MockAddress, 10)]
//        public async Task BuildModel_WhenValidOwnershipAcceptanceChanged_ShouldBuildModelSuccessfullyAsync(string who, double? maybe_collection)
//        {
//            var enumOwnershipAcceptanceChanged = new Blockchain.Contracts.Pallet.Nfts.Enums.EnumEvent();
//            enumOwnershipAcceptanceChanged.Create(
//                   Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.Nfts.Enums.Event.OwnershipAcceptanceChanged,
//                    new BaseTuple<SubstrateAccount, BaseOpt<IncrementableU256>>(
//                        new SubstrateAccount(who), new BaseOpt<IncrementableU256>(new IncrementableU256(maybe_collection!.Value))
//                        )
//            );

//            var model = await _nftsOwnershipAcceptanceChangedRepository.BuildModelAsync(
//                BuildEventModel("Nfts", "OwnershipAcceptanceChanged"),
//                enumOwnershipAcceptanceChanged,
//                CancellationToken.None);

//            Assert.That(model, Is.Not.Null);
//            Assert.That(model.ModuleName, Is.EqualTo("Nfts"));
//            Assert.That(model.ModuleEvent, Is.EqualTo("OwnershipAcceptanceChanged"));
//            Assert.That(model.Who, Is.EqualTo(who));
//Assert.That(model.Maybe_collection, Is.EqualTo(maybe_collection));
//        }

//        [Test]
//        public async Task Search_WithValidParameter_ShouldSuceedAsync()
//        {
//            var res = await _nftsOwnershipAcceptanceChangedRepository.SearchAsync(new()
//            {
//                Who = Alice.ToString(),
//				Maybe_collection = NumberCriteria<double>.Equal(20)
//            }, CancellationToken.None);

//            Assert.That(res.Count(), Is.EqualTo(1));
//        }
//    }
//}
