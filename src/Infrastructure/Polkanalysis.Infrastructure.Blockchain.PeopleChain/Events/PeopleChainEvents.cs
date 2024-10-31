using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Pallet.System.Enums;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Mapping;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi.Model.Types.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain.Events
{
    [ExcludeFromCodeCoverage]
    internal class PeopleChainEvents : IEvents
    {
        protected readonly SubstrateClientExt _client;
        protected readonly PeopleChainMapping _mapper;
        protected readonly ILogger _logger;

        public PeopleChainEvents(SubstrateClientExt client, PeopleChainMapping mapper, ILogger logger)
        {
            _client = client;
            _mapper = mapper;
            _logger = logger;
        }

        public Task SubscribeEventsAsync(Action<BaseVec<EventRecord>> callback, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
