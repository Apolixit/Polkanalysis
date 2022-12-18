using Blazscan.Domain.Contracts.Dto.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Repository
{
    public interface IEventRepository
    {
        Task SubscribeEventAsync(Action<EventLightDto> eventCallback);
    }
}
