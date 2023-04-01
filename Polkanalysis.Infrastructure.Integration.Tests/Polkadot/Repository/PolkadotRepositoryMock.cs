using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Integration.Tests.Polkadot.Repository
{
    public abstract class PolkadotRepositoryMock
    {
        protected ISubstrateRepository _substrateRepository;

        [SetUp]
        public void Setup()
        {
            _substrateRepository = new PolkadotRepository(
                Substitute.For<ISubstrateEndpoint>(),
                Substitute.For<ILogger<PolkadotRepository>>()
                );
        }
    }
}
