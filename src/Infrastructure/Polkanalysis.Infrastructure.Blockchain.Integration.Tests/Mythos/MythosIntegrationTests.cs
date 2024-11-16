using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Blockchain.Mythos.Mapping;
using Polkanalysis.Infrastructure.Blockchain.Mythos;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Mythos
{
    public class MythosIntegrationTests : InfrastructureIntegrationTest
    {
        internal MythosIntegrationTests() : base()
        {
        }

        protected override ISubstrateService MockSubstrateService()
        {
            return new MythosService(
                    _substrateEndpoints,
                    new MythosMapping(Substitute.For<ILogger<MythosMapping>>()),
                    Substitute.For<ILogger<MythosService>>()
                    );
        }

        [SetUp]
        protected void Setup()
        {
            // Just clean blockhash everytime
            _substrateService.Storage.BlockHash = null;
        }

        //public static IEnumerable<int> AllBlockVersionTestCases = FilterTestCase(new List<int>()
        //{
        //    1, 100000, 490000, 637704
        //});
    }
}
