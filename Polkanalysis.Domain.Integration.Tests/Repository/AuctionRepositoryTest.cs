using NUnit.Framework;
using Polkanalysis.Domain.Contracts.Secondary.Repository;
using Polkanalysis.Domain.Repository;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Integration.Tests.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Domain.Integration.Tests.Repository
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
