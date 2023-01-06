using Blazscan.Domain.Contracts.Dto.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Secondary
{
    public interface IEventRepository
    {
        /// <summary>
        /// Subscribe for new events
        /// </summary>
        /// <param name="eventCallback"></param>
        /// <returns></returns>
        Task SubscribeEventAsync(Action<EventLightDto> eventCallback);
    }
}
