using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Repository
{
    public abstract class PolkadotRepositoryMock
    {
        protected ISubstrateService _substrateRepository;

        [SetUp]
        public void Setup()
        {
            _substrateRepository = new PolkadotService(
                Substitute.For<ISubstrateEndpoint>(),
                Substitute.For<ILogger<PolkadotService>>()
                );
        }
    }
}
