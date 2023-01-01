using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Domain.Contracts.Runtime;
using Blazscan.Domain.Runtime;
using Blazscan.Infrastructure.DirectAccess.Runtime;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Tests.Runtime.Extrinsic
{
    public class ExtrinsicTest
    {

        private ISubstrateDecoding _substrateDecode;

        public ExtrinsicTest()
        {
            _substrateDecode = new SubstrateDecoding(
                new EventMapping(),
                Substitute.For<ISubstrateNodeRepository>(),
                Substitute.For<IPalletBuilder>());
        }

        [Test]
        [TestCase("0x280403000b207eba5c8501")]
        public async Task GetExtrinsic_ShouldWork(string extrinsicHash)
        {
            // TODO
        }
    }
}
