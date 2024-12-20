﻿using NUnit.Framework;
using Substrate.NetApi;

namespace Polkanalysis.Domain.Integration.Tests.Service.Explorer
{
    [CancelAfter(RepositoryMaxTimeout)]
    public class ExplorerEventsTests : ExplorerRepositoryTest
    {
        /// <summary>
        /// https://polkadot.js.org/apps/?rpc=wss%3A%2F%2Frpc.polkadot.io#/explorer/query/0x787cc6071e318539a9c35624bc7966ab046051c7205917fd89d96c3f97500898
        /// </summary>
        /// <param name="blockId"></param>
        /// <returns></returns>
        [Test]
        [TestCase(20681308, 53)]
        [TestCase(14000001, 30)]
        [TestCase(13564726, 34)]
        [TestCase(14063202, 39)]
        [TestCase(14063226, 37)]
        [TestCase(14063234, 37)]
        public async Task GetEventsAssociateToBlock_WithValidBlockNumber_ShouldWorkAsync(
            int blockId, int nbEvent)
        {
            var eventInfoWithNumber = await _explorerRepository.GetEventsAsync((uint)blockId, CancellationToken.None);

            Assert.That(eventInfoWithNumber, Is.Not.Null);
            Assert.That(eventInfoWithNumber.Count(), Is.EqualTo(nbEvent));
        }

        [Test]
        [TestCase(14033244)]
        public async Task GetEventsAssociatedByExtrinsic_ShouldWorkAsync(int blockId)
        {
            var extrinsics = await _explorerRepository.GetExtrinsicsAsync((uint)blockId, CancellationToken.None);
            var extrinsicList = extrinsics.ToList();

            var events_0 = await _explorerRepository.GetEventsLinkedToExtrinsicsAsync(extrinsicList[0], CancellationToken.None);
            var events_1 = await _explorerRepository.GetEventsLinkedToExtrinsicsAsync(extrinsicList[1], CancellationToken.None);
            var events_2 = await _explorerRepository.GetEventsLinkedToExtrinsicsAsync(extrinsicList[2], CancellationToken.None);

            Assert.That(events_0!.Count() + events_1!.Count() + events_2!.Count(), Is.EqualTo(38));
        }

        [Test]
        [TestCase(
            "0x6de17e76b2b5d40b51e9276406ffee4e37662366d5faa73babe3c3a359df5ebd",
            Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.RuntimeEvent.Scheduler,
            Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.Event.Dispatched)]
        [TestCase(
            "0x18c0f457ee51eab5ff309fdfb01d49a83b8b696cfaffcdf549057a5e87b1f085",
            Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.RuntimeEvent.Scheduler,
            Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.Event.Scheduled)]
        public async Task FilterEventScheduler_FromBlock_ShouldWorkAsync(
            string blockHash,
            Infrastructure.Blockchain.Contracts.Pallet.PolkadotRuntime.RuntimeEvent runtimeEvent,
            Infrastructure.Blockchain.Contracts.Pallet.Scheduler.Enums.Event eventEnum)
        {
            var from = _substrateService.At(blockHash);
            var events = await from.Storage.System.EventsAsync(CancellationToken.None);
            var metadata = await from.GetMetadataAsync(CancellationToken.None);

            var filteredEvent = await _explorerRepository.FindEventAsync(events, metadata, runtimeEvent, eventEnum, CancellationToken.None);

            Assert.That(filteredEvent, Is.Not.Null);
            Assert.That(filteredEvent.Count(), Is.EqualTo(1));

            var scheduledEvent = filteredEvent.First();
            var nodeEvent = await _substrateDecoding.DecodeEventAsync(scheduledEvent, metadata, CancellationToken.None);

            Assert.That(nodeEvent.Module.ToString(), Is.EqualTo("Scheduler"));
            Assert.That(nodeEvent.Method.ToString(), Is.EqualTo(eventEnum.ToString()));
        }
    }
}
