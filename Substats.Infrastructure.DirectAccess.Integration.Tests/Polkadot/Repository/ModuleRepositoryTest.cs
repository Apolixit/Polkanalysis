using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Infrastructure.DirectAccess.Runtime;
using Substats.Integration.Tests.Contracts;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Repository
{
    public class ModuleRepositoryTest : PolkadotIntegrationTest
    {
        private IModuleRepository _moduleRepository;

        [SetUp]
        public void Setup()
        {
            _moduleRepository = new ModuleRepository(
                new CurrentMetaData(
                    _substrateRepository,
                    Substitute.For<ILogger<CurrentMetaData>>()
                )
            );
        }


    }
}
