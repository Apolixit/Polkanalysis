using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Repository;
using Blazscan.Infrastructure.DirectAccess.Helpers;
using Blazscan.NetApiExt.Generated.Model.frame_system;
using Blazscan.NetApiExt.Generated.Storage;
using Blazscan.SubstrateDecode.Abstract;
using Blazscan.SubstrateDecode.Event;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Infrastructure.DirectAccess.Repository
{
    public class EventRepositoryDirectAccess : IEventRepository
    {
        private readonly ISubstrateNodeRepository _substrateService;
        private readonly ISubstrateDecoding _decode;
        private readonly IList<EventLightDto> _events = new List<EventLightDto>();
        private readonly ILogger<EventRepositoryDirectAccess> _logger;

        public EventRepositoryDirectAccess(
            ISubstrateNodeRepository substrateService, 
            ISubstrateDecoding decode,
            ILogger<EventRepositoryDirectAccess> logger)
        {
            _substrateService = substrateService;
            _decode = decode;
            _logger = logger;
        }

        public async Task SubscribeEventAsync(Action<EventLightDto> eventCallback)
        {
            Action<string, StorageChangeSet> eventChangeset = (subscriptionId, storageChangeSet) =>
            {
                var hexString = SubstrateHelper.getChangesetData(storageChangeSet);

                // No data
                if (string.IsNullOrEmpty(hexString)) return;

                var eventsReceived = new BaseVec<EventRecord>();
                eventsReceived.Create(hexString);

                foreach (EventRecord eventReceived in eventsReceived.Value)
                {
                    try
                    {
                        var eventNode = _decode.DecodeEvent(eventReceived.Event);

                        var palletName = eventNode.HumanData;
                        var eventName = eventNode.Children.First().HumanData;
                        //eventNode.Children.First().Children.First().HumanData
                        // Mapping
                        var eventDto = new EventLightDto()
                        {
                            Block = new Domain.Contracts.Dto.Block.BlockDto(),
                            PalletName = eventNode.HumanData.ToString(),
                            EventName = eventNode.Children.First().HumanData.ToString(),
                            Description = string.Empty,
                        };


                        eventCallback(eventDto);
                    } catch(Exception ex)
                    {
                        _logger.LogWarning($"Hexa: {Utils.Bytes2HexString(eventReceived.Encode())}");
                        _logger.LogError($"Read event failed : {ex}");
                    }
                }
            };

            await _substrateService.Client.SubscribeStorageKeyAsync(SystemStorage.EventsParams(), eventChangeset, CancellationToken.None);
        }
    }
}
