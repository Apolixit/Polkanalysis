using NUnit.Framework;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Integration.Tests.Polkadot.Rpc
{
    internal class RpcChainTests : PolkadotIntegrationTest
    {

        /// <summary>
        /// This test is used to check that Era is working (previously it was not working with this error : Deserializing JSON-RPC result to type TempNewBlockData failed with ArgumentException: 0x0178 is not a valid representation of Era.)
        /// </summary>
        /// <param name="blockNumber"></param>
        /// <returns></returns>
        [Test]
        [TestCase(14003402)]
        public async Task GetBlockAsync_ShouldSuccessAsync(int blockNumber)
        {
            var blockHash = await _substrateRepository.Rpc.Chain.GetBlockHashAsync(new BlockNumber((uint)blockNumber), CancellationToken.None);
            var res = await _substrateRepository.Rpc.Chain.GetBlockAsync(blockHash, CancellationToken.None);

            Assert.That(res, Is.Not.Null);
        }
    }
}
