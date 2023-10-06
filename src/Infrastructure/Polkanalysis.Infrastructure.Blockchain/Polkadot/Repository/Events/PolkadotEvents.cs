using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Microsoft.Extensions.Logging;
using Polkanalysis.Domain.Contracts.Core.Map;
using Polkanalysis.Domain.Contracts.Runtime;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using SystemStorageExt = Polkanalysis.Polkadot.NetApiExt.Generated.Storage.SystemStorage;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Mapping;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Events
{
    public partial class PolkadotEvents : IEvents
    {
        protected readonly SubstrateClientExt _client;
        protected readonly ILogger _logger;

        public PolkadotEvents(SubstrateClientExt client, ILogger logger)
        {
            _client = client;
            _logger = logger;
        }

        public async Task SubscribeEventsAsync(Action<BaseVec<EventRecord>> callback, CancellationToken token)
        {
            await _client.SubscribeStorageKeyAsync(
                RequestGenerator.GetStorage("System", "Events", Substrate.NetApi.Model.Meta.Storage.Type.Plain),
                async (subscriptionId, storageChangeSet) =>
                {
                    if (storageChangeSet.Changes == null
                    || storageChangeSet.Changes.Length == 0
                    || storageChangeSet.Changes[0].Length < 2)
                    {
                        throw new InvalidOperationException("Couldn't update account information. Please check 'CallBackAccountChange'");
                    }
                    var hexString = storageChangeSet.Changes[0][1];

                    // No data
                    if (string.IsNullOrEmpty(hexString)) return;

                    var blockData = await _client.Chain.GetBlockAsync();

                    try
                    {
                        //var coreResult = new BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>();
                        //coreResult.Create(hexString);


                        //_logger.LogTrace(
                        //    $"Parsed all the events ({coreResult.Value.Length}) from block {blockData.Block.Header.Number.Value}");

                        //var expectedResult = new List<EventRecord>();
                        //foreach (var coreEvent in coreResult.Value)
                        //{
                        //    var mappedPhase = PolkadotMapping.Instance.Map<EnumPhase>(coreEvent.Phase);
                        //    var mappedTopics = PolkadotMapping.Instance.Map<BaseVec<Hash>>(coreEvent.Topics);
                        //    var maybeMappedEvents = new Maybe<EnumRuntimeEvent>();

                        //    try
                        //    {

                        //        var mappedEvents = PolkadotMapping.Instance.Map<
                        //  Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>(coreEvent.Event);

                        //        maybeMappedEvents = new Maybe<EnumRuntimeEvent>(mappedEvents);
                        //    }
                        //    catch (Exception _)
                        //    {
                        //        maybeMappedEvents.Core = coreEvent;
                        //    }

                        //    var mappedEvent = new EventRecord(mappedPhase, maybeMappedEvents, mappedTopics);
                        //    expectedResult.Add(mappedEvent);
                        //}

                        //callback(new BaseVec<EventRecord>(expectedResult.ToArray()));
                    }
                    catch (System.Exception ex)
                    {
                        _logger.LogError(
                            $"Fail to parse all the events from block {blockData.Block.Header.Number.Value}",
                            ex.InnerException);
                    }
                }, token);
        }
    }
}
