using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Substats.Configuration.Contracts;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Integration.Tests.Polkadot.Repository
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
