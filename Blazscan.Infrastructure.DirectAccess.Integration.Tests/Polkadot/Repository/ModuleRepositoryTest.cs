using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Contracts.Secondary;
using Blazscan.Infrastructure.DirectAccess.Repository;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using Blazscan.Integration.Tests.Contracts;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Repository
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
