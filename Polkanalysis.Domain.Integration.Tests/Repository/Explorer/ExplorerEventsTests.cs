using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Dto;
using Polkanalysis.Domain.Runtime;
using Polkanalysis.Infrastructure.DirectAccess.Repository;
using Polkanalysis.Integration.Tests.Contracts;
using Microsoft.Extensions.Logging;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substrate.NetApi;

namespace Polkanalysis.Domain.Integration.Tests.Repository.Explorer
{
    public class ExplorerEventsTests : ExplorerRepositoryTest
    {
        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(14000001, 30)]
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

        [Test]
        [TestCase(
            "0x6de17e76b2b5d40b51e9276406ffee4e37662366d5faa73babe3c3a359df5ebd",
            Contracts.Secondary.Pallet.PolkadotRuntime.RuntimeEvent.Scheduler,
            Contracts.Secondary.Pallet.Scheduler.Enums.Event.Dispatched)]
        [TestCase(
            "0x18c0f457ee51eab5ff309fdfb01d49a83b8b696cfaffcdf549057a5e87b1f085",
            Contracts.Secondary.Pallet.PolkadotRuntime.RuntimeEvent.Scheduler,
            Contracts.Secondary.Pallet.Scheduler.Enums.Event.Scheduled)]
        public async Task FilterEventScheduler_FromBlock_ShouldWorkAsync(
            string blockHash,
            Contracts.Secondary.Pallet.PolkadotRuntime.RuntimeEvent runtimeEvent,
            Contracts.Secondary.Pallet.Scheduler.Enums.Event eventEnum)
        {
            var events = await _substrateRepository.At(blockHash).Storage.System.EventsAsync(CancellationToken.None);

            var filteredEvent = _explorerRepository.FindEvent(events, runtimeEvent, eventEnum);

            Assert.That(filteredEvent, Is.Not.Null);
            Assert.That(filteredEvent.Count(), Is.EqualTo(1));

            var nodeEvent = _substrateDecoding.DecodeEvent(Utils.Bytes2HexString(filteredEvent.First().Encode()));

            Assert.That(nodeEvent.Module, Is.EqualTo(runtimeEvent));
            Assert.That(nodeEvent.Method, Is.EqualTo(eventEnum));
        }
    }
}
