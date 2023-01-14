using Ajuna.NetApi;
using Ajuna.NetApi.Model.Rpc;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Dto.Event;
using Substats.Domain.Contracts.Runtime;
using Substats.Domain.Contracts.Secondary;
using Substats.Infrastructure.DirectAccess.Helpers;
using Substats.Polkadot.NetApiExt.Generated.Model.frame_system;
using Substats.Polkadot.NetApiExt.Generated.Storage;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    //public class EventRepositoryDirectAccess : IEventRepository
    //{
    //    private readonly ISubstrateNodeRepository _substrateService;
    //    private readonly ISubstrateDecoding _decode;
    //    private readonly ILogger<EventRepositoryDirectAccess> _logger;

    //    public EventRepositoryDirectAccess(
    //        ISubstrateNodeRepository substrateService, 
    //        ISubstrateDecoding decode,
    //        ILogger<EventRepositoryDirectAccess> logger)
    //    {
    //        _substrateService = substrateService;
    //        _decode = decode;
    //        _logger = logger;
    //    }

        
    //}
}
