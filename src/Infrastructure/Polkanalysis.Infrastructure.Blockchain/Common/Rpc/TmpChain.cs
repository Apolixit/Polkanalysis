using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polkanalysis.Infrastructure.Blockchain.Common.Rpc
{
    public class TmpChain : ITmpChain
    {
        private readonly bool _checkHash;
        private readonly SubstrateClient _client;
        private Func<string, MetaData> _getMetadataFromHex;

        /// <summary>
        /// Chain Module Constructor
        /// </summary>
        /// <param name="client"></param>
        public TmpChain(SubstrateClient client, Func<string, MetaData> getMetadataFromHex)
        {
            _client = client;
            _getMetadataFromHex = getMetadataFromHex;
        }

        public async Task<Header> GetHeaderAsync(CancellationToken token)
        {
            return await GetHeaderAsync(null, token);
        }

        /// <inheritdoc/>
        public async Task<Header> GetHeaderAsync(Hash hash = null)
        {
            return await GetHeaderAsync(hash, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Header> GetHeaderAsync(Hash hash, CancellationToken token)
        {
            var parameter = hash != null ? hash.Value : null;
            return await _client.InvokeAsync<Header>("chain_getHeader", new object[] { parameter }, token);
        }

        /// <inheritdoc/>
        public async Task<IBlockData> GetBlockAsync()
        {
            return await GetBlockAsync(null, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<IBlockData> GetBlockAsync(CancellationToken token)
        {
            return await GetBlockAsync(null, token);
        }

        /// <inheritdoc/>
        public async Task<IBlockData> GetBlockAsync(Hash hash)
        {
            return await GetBlockAsync(hash, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<IBlockData> GetBlockAsync(Hash? hash, CancellationToken token)
        {
            var parameter = hash != null ? hash.Value : null;

            var fullParams = new object[] { string.IsNullOrEmpty(parameter) ? null : parameter };
            var metadataHex = await _client.InvokeAsync<string>("state_getMetadata", fullParams, token);

            MetaData metadata = _getMetadataFromHex(metadataHex);
            SignedExtensionMetadata[]? signedExtensions = metadata.NodeMetadata.Extrinsic.SignedExtensions;

            if (signedExtensions is not null && signedExtensions.Any(x => x.SignedIdentifier == "CheckMetadataHash"))
            {
                return await _client.InvokeAsync<TempNewBlockData>("chain_getBlock", new object[] { parameter }, token);
            }
            else
            {
                return await _client.InvokeAsync<TempOldBlockData>("chain_getBlock", new object[] { parameter }, token);
            }
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync()
        {
            return await GetBlockHashAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync(BlockNumber blockNumber)
        {
            return await GetBlockHashAsync(blockNumber, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("chain_getBlockHash", new object[] { null }, token);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetBlockHashAsync(BlockNumber blockNumber, CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("chain_getBlockHash",
                new object[] { Utils.Bytes2HexString(blockNumber.Encode()) }, token);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetFinalizedHeadAsync()
        {
            return await GetFinalizedHeadAsync(CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<Hash> GetFinalizedHeadAsync(CancellationToken token)
        {
            return await _client.InvokeAsync<Hash>("chain_getFinalizedHead", null, token);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback)
        {
            return await SubscribeAllHeadsAsync(callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeAllHeadsAsync(Action<string, Header> callback, CancellationToken token)
        {
            var subscriptionId = await _client.InvokeAsync<string>("chain_subscribeAllHeads", null, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId)
        {
            return await UnsubscribeAllHeadsAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeAllHeadsAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("chain_unsubscribeAllHeads", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback)
        {
            return await SubscribeNewHeadsAsync(callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeNewHeadsAsync(Action<string, Header> callback, CancellationToken token)
        {
            var subscriptionId = await _client.InvokeAsync<string>("chain_subscribeNewHeads", null, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnubscribeNewHeadsAsync(string subscriptionId)
        {
            return await UnsubscribeNewHeadsAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeNewHeadsAsync(string subscriptionId, CancellationToken token)
        {
            var result =
                await _client.InvokeAsync<bool>("chain_unsubscribeNewHeads", new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback)
        {
            return await SubscribeFinalizedHeadsAsync(callback, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<string> SubscribeFinalizedHeadsAsync(Action<string, Header> callback, CancellationToken token)
        {
            var subscriptionId = await _client.InvokeAsync<string>("chain_subscribeFinalizedHeads", null, token);
            _client.Listener.RegisterCallBackHandler(subscriptionId, callback);
            return subscriptionId;
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId)
        {
            return await UnsubscribeFinalizedHeadsAsync(subscriptionId, CancellationToken.None);
        }

        /// <inheritdoc/>
        public async Task<bool> UnsubscribeFinalizedHeadsAsync(string subscriptionId, CancellationToken token)
        {
            var result = await _client.InvokeAsync<bool>("chain_unsubscribeFinalizedHeads",
                new object[] { subscriptionId }, token);
            if (result) _client.Listener.UnregisterHeaderHandler(subscriptionId);
            return result;
        }
    }
}
