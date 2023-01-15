using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Dto;
using Substats.Domain.Runtime;
using Substats.Infrastructure.DirectAccess.Repository;
using Substats.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Integration.Tests.Polkadot.Block
{
    public class ExplorerEventsTests : ExplorerRepositoryTest
    {
        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(13564726, "0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898")]
        public async Task GetEventsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(
            int blockId,
            string blockHash)
        {
            var eventInfoWithNumber = await _blockRepository.GetEventsAsync((uint)blockId, CancellationToken.None);
            var eventInfoWithHash = await _blockRepository.GetEventsAsync(blockHash, CancellationToken.None);

            Assert.IsNotNull(eventInfoWithNumber);
            Assert.IsNotNull(eventInfoWithHash);
            Assert.That(eventInfoWithNumber.Count(), Is.EqualTo(34));
            Assert.That(eventInfoWithHash.Count(), Is.EqualTo(34));

        }
    }
}
