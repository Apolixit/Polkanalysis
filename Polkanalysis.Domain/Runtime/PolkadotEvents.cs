//using Ajuna.NetApi.Model.Types;
//using Ajuna.NetApi.Model.Types.Base;
//using Microsoft.Extensions.Logging;
//using Polkanalysis.Domain.Contracts.Runtime;
//using Polkanalysis.Domain.Contracts.Secondary;
//using Polkanalysis.Domain.Contracts.Secondary.Contracts;
//using Polkanalysis.Domain.Contracts.Secondary.Pallet.PolkadotRuntime;
//using Polkanalysis.Domain.Contracts.Secondary.Pallet.SystemCore.Enums;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Polkanalysis.Domain.Runtime
//{
//    public partial class PolkadotEvents : IEvents
//    {
//        private readonly ISubstrateDecoding _substrateDecode;
//        protected readonly ILogger _logger;

//        public PolkadotEvents(ISubstrateDecoding substrateDecode, ILogger logger)
//        {
//            _substrateDecode = substrateDecode;
//            _logger = logger;
//        }

//        public async Task SubscribeAllEventsAsync(Action<BaseVec<EventRecord>> callback, CancellationToken token)
//        {
//            await _client.SubscribeStorageKeyAsync(
//                SystemStorageExt.EventsParams(),
//                async (string subscriptionId, StorageChangeSet storageChangeSet) =>
//                {
//                    if (storageChangeSet.Changes == null
//                    || storageChangeSet.Changes.Length == 0
//                    || storageChangeSet.Changes[0].Length < 2)
//                    {
//                        throw new InvalidOperationException("Couldn't update account information. Please check 'CallBackAccountChange'");
//                    }
//                    var hexString = storageChangeSet.Changes[0][1];

//                    // No data
//                    if (string.IsNullOrEmpty(hexString)) return;

//                    var blockData = await _client.Chain.GetBlockAsync();

//                    try
//                    {
//                        var coreResult = new BaseVec<Polkanalysis.Polkadot.NetApiExt.Generated.Model.frame_system.EventRecord>();
//                        coreResult.Create(hexString);


//                        _logger.LogInformation(
//                            $"Parsed all the events ({coreResult.Value.Length}) from block {blockData.Block.Header.Number.Value}");

//                        var expectedResult = new List<EventRecord>();
//                        foreach (var coreEvent in coreResult.Value)
//                        {
//                            var mappedPhase = SubstrateMapper.Instance.Map<EnumPhase>(coreEvent.Phase);
//                            var mappedTopics = SubstrateMapper.Instance.Map<BaseVec<Hash>>(coreEvent.Topics);
//                            var maybeMappedEvents = new Maybe<EnumRuntimeEvent>();

//                            try
//                            {

//                                var mappedEvents = SubstrateMapper.Instance.Map<
//                            Polkanalysis.Polkadot.NetApiExt.Generated.Model.polkadot_runtime.EnumRuntimeEvent, EnumRuntimeEvent>(coreEvent.Event);

//                                maybeMappedEvents = new Maybe<EnumRuntimeEvent>(mappedEvents);
//                            }
//                            catch (Exception _)
//                            {
//                                maybeMappedEvents.Core = coreEvent;
//                            }

//                            expectedResult.Add(new EventRecord(mappedPhase, maybeMappedEvents, mappedTopics));
//                        }

//                        callback(new BaseVec<EventRecord>(expectedResult.ToArray()));
//                    }
//                    catch (Exception ex)
//                    {
//                        _logger.LogError(
//                            $"Fail to parse all the events from block {blockData.Block.Header.Number.Value}",
//                            ex.InnerException);
//                    }
//                }, token);
//        }

//        public async Task SubscribeSpecificEventAsync(RuntimeEvent palletName, Enum eventName, Action<IType> callback, CancellationToken token)
//        {
//            await SubscribeAllEventsAsync((BaseVec<EventRecord> events) =>
//            {
//                foreach (var ev in events.Value)
//                {
//                    var eventNode = _substrateDecode.DecodeEvent(ev);

//                    if (eventNode.Children != null && eventNode.Children.Count == 3)
//                    {
//                        var runtimeEvent = eventNode.Children.ToList()[1];
//                        var palletChild = runtimeEvent.Children.First();
//                        var bOk1 = palletChild.HumanData == palletName;
//                        var bOk2 = palletChild.Children.First().HumanData == eventName;
//                        if (bOk1 && bOk2)
//                            _logger.LogInformation("Found seeking event !");

//                        callback(ev);
//                    }
//                    //Assert.That(node.Children, Is.Not.Empty);

//                    //// 3 children : Phase / Events / Topic
//                    //Assert.That(node.Children.Count, Is.EqualTo(3));

//                    //Assert.That(node.Has(Phase.ApplyExtrinsic));

//                    //var runtimeEvent = node.Children.ToList()[1];
//                    //Assert.That(runtimeEvent.Name, Is.EqualTo("Event"));

//                    //var palletChild = runtimeEvent.Children.First();
//                    //Assert.IsInstanceOf<Enum>(palletChild.HumanData);

//                    //var palletEvent = palletChild.Children.First();
//                    //Assert.IsInstanceOf<Enum>(palletEvent.HumanData);
//                }
//            }, token);
//        }

//        public Task SubscribeSpecificEventAsync(string palletName, string eventName, ListenerFilter filter)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
