using Ajuna.NetApi.Model.Extrinsics;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Runtime;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Domain.Contracts.Runtime.Module;

namespace Substats.Domain.Tests.Runtime.Extrinsic
{
    public class ExtrinsicTest
    {

        private ISubstrateDecoding _substrateDecode;

        [SetUp]
        public void Setup()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateRepository>(),
                Substitute.For<IPalletBuilder>(),
                Substitute.For<ICurrentMetaData>(),
                Substitute.For<ILogger<SubstrateDecoding>>());
        }

        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        public async Task GetExtrinsic_ShouldWork(string extrinsicHash)
        {
            //var extrinsic = new Extrinsic();
            //_substrateDecode.DecodeExtrinsic()
        }
    }
}
