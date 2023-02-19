using Ajuna.NetApi.Model.Types.Primitive;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Substats.Domain.Contracts.Core;
using Substats.Domain.Contracts.Secondary.Pallet.Authorship;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository.Storage
{
    public class AuthorshipStorage : IAuthorshipStorage
    {
        private readonly SubstrateClientExt _client;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public AuthorshipStorage(SubstrateClientExt client, IMapper mapper, ILogger logger)
        {
            _client = client;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SubstrateAccount> AuthorAsync(CancellationToken token)
        {
            var author = await _client.AuthorshipStorage.Author(token);
            _logger.LogTrace($"Received {nameof(_client.AuthorshipStorage.Author)} call");

            return _mapper.Map<SubstrateAccount>(author);
        }

        public async Task<Bool> DidSetUnclesAsync(CancellationToken token)
        {
            var response = await _client.AuthorshipStorage.DidSetUncles(token);
            _logger.LogTrace($"Received {nameof(_client.AuthorshipStorage.DidSetUncles)} call");

            return response;
        }

        public async Task<IEnumerable<EnumUncleEntryItem>> UnclesAsync(CancellationToken token)
        {
            var response = await _client.AuthorshipStorage.Uncles(token);
            _logger.LogTrace($"Received {nameof(_client.AuthorshipStorage.Uncles)} call");

            return _mapper.Map<IEnumerable<EnumUncleEntryItem>>(response.Value);
        }
    }
}
