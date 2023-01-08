using Ajuna.NetApi.Model.Extrinsics;
using Blazscan.Domain.Contracts.Dto.Event;
using Blazscan.Domain.Contracts.Dto.Extrinsic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazscan.Domain.Contracts.Secondary
{
    internal interface IExtrinsicRepository
    {
        /// <summary>
        /// Subscribe for new extrinsic
        /// </summary>
        /// <param name="eventCallback"></param>
        /// <returns></returns>
        Task SubscribeExtrinsicAsync(Action<ExtrinsicLightDto> eventCallback);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="extrinsic"></param>
        /// <returns></returns>
        Task<ExtrinsicDto> GetExtrinsic(Extrinsic extrinsic);
        Task<ExtrinsicLightDto> GetExtrinsicLight(Extrinsic extrinsic);
    }
}
