﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using NSubstitute;
using Polkanalysis.Abstract.Tests;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository
{
    public abstract class EventsDatabaseTests : GlobalAbstractTest
    {
        protected SubstrateDbContext _substrateDbContext = default!;
        protected ISubstrateService _substrateService = default!;

        public const string MockAddress = "5He5uUCWMLXvfJmSWTcD2ZHDerBU4VH91z92SekRcctuGifV";
        public const string MockAddress2 = "5EerUgnr9WVAgHbynVD4YYDJKzkaCZP7Uz4METJJSk3Jg15x";
        public const string MockAddress3 = "5EU6EyEq6RhqYed1gCYyQRVttdy6FC9yAtUUGzPe3gfpFX8y";
        public const string MockAddress4 = "5Fk8my9a6vFDafsNMxd7q3vM9SsJdFHVyARK6Pw5dLjwxJXw";
        public const string MockAddress5 = "5Fk8my9a6vFDafsNMxd7q3vM9SsJdFHVyARK6Pw5dLjwxJXw";
        
        public const string MockItemNft = "157291066769514669673966718098575209926";
        public const string MockMetadataNft = "test data";
        
        public const double FiveDots = 50_000_000_000;
        public const double TenDots = 100_000_000_000;

        [SetUp]
        public void SetupBase()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
                .Options;

            _substrateDbContext = new SubstrateDbContext(contextOption);

            _substrateService = Substitute.For<ISubstrateService>();
            _substrateService.Rpc.System.PropertiesAsync(CancellationToken.None).Returns(new Substrate.NetApi.Model.Rpc.Properties
                ()
            {
                Ss58Format = 42,
                TokenDecimals = 10,
                TokenSymbol = "DOT"
            });

            mockDatabase();

            _substrateDbContext.SaveChanges();
        }

        protected virtual void mockDatabase() { }

        public EventModel BuildEventModel(string moduleName, string moduleEvent)
        {
            return new EventModel("Polkadot", 10, DateTime.Now, 0, moduleName, moduleEvent);
        }

        [TearDown]
        public void TearDown()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }
    }
}
