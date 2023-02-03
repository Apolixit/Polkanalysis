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
        [TestCase(13564726, 34)]
        [TestCase(14063202, 39)]
        [TestCase(14063226, 37)]
        [TestCase(14063234, 37)]
        public async Task GetEventsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(
            int blockId, int nbEvent)
        {
            var eventInfoWithNumber = await _explorerRepository.GetEventsAsync((uint)blockId, CancellationToken.None);

            Assert.IsNotNull(eventInfoWithNumber);
            Assert.That(eventInfoWithNumber.Count(), Is.EqualTo(nbEvent));
        }

        [Test]
        [TestCase(14033244)]
        public async Task GetEventsAssociatedByExtrinsic_ShouldWorkAsync(int blockId)
        {
            var extrinsics = await _explorerRepository.GetExtrinsicsAsync((uint)blockId, CancellationToken.None);

            var events = await _explorerRepository.GetEventsLinkedToExtrinsicsAsync(extrinsics.ToList()[1], CancellationToken.None);

            Assert.That(events, Is.Not.Null);
            Assert.That(events.Count(), Is.EqualTo(9));
        }
    }
}
