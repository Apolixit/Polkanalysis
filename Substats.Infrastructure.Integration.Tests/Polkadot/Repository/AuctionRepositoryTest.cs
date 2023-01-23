using NUnit.Framework;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Integration.Tests.Polkadot.Repository
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
