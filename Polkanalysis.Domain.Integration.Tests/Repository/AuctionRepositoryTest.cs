using NUnit.Framework;
using Substats.Domain.Contracts.Secondary.Repository;
using Substats.Domain.Repository;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Domain.Integration.Tests.Repository
{
    internal class AuctionRepositoryTest : PolkadotIntegrationTest
    {
        private IAuctionRepository _auctionRepository;

        [SetUp]
        public void Setup()
        {
            _auctionRepository = new PolkadotAuctionRepository(_substrateRepository);
        }
    }
}
