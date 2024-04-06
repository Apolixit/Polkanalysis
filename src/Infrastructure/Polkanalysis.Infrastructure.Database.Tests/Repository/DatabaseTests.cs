using Microsoft.EntityFrameworkCore;
using NSubstitute;
using Polkanalysis.Domain.Contracts.Secondary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Database.Tests.Repository
{
    public abstract class DatabaseTests
    {
        protected SubstrateDbContext _substrateDbContext = default!;

        public void SetupBase()
        {
            var contextOption = new DbContextOptionsBuilder<SubstrateDbContext>()
                .UseInMemoryDatabase("SubstrateTest")
                .Options;

            _substrateDbContext = new SubstrateDbContext(contextOption);
        }

        [TearDown]
        public void TearDown()
        {
            _substrateDbContext.Database.EnsureDeleted();
            _substrateDbContext.Dispose();
        }
    }
}
