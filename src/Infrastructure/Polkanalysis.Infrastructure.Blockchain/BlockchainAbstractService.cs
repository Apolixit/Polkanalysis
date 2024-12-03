using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Contracts.Endpoints;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Core.ExtrinsicTmp;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Exceptions;
using Substrate.NET.Metadata;
using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Utils.Address;
using Substrate.NET.Utils.Core;
using Substrate.NetApi;
using Substrate.NetApi.Exceptions;
using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using System.Net.WebSockets;

namespace Polkanalysis.Infrastructure.Blockchain
{
    public abstract class BlockchainAbstractService : ISubstrateService
    {
        public abstract ILogger Logger { get; }
        public abstract IEnumerable<string> DependenciesName { get; }
        public abstract IEnumerable<ISubstrateService> ChainDependencies { get; }
        public abstract string NetApiExtAssembly { get; }
        public abstract string NetApiExtModelNamespace { get; }
        public abstract SubstrateClient AjunaClient { get; }
        public abstract string BlockchainName { get; }
        public abstract IStorage Storage { get; }
        
        private IRpc? _rpc = null;
        public virtual IRpc Rpc
        {
            get
            {
                if (_rpc == null)
                    _rpc = new Rpc(AjunaClient, new TmpChain(AjunaClient, MetadataHelper.GetMetadataFromHex));

                return _rpc;
            }
        }
        public abstract IConstants Constants { get; }
        public abstract ICalls Calls { get; }
        public abstract IEvents Events { get; }
        public abstract IErrors Errors { get; }

        private readonly ILogger _logger;

        protected readonly EndpointInformation _endpointInformation;
        public EndpointInformation EndpointInformation => _endpointInformation;
        private readonly ISubstrateEndpoint _substrateconfiguration;

        protected BlockchainAbstractService(ISubstrateEndpoint substrateconfiguration, ILogger logger)
        {
            _substrateconfiguration = substrateconfiguration;
            _logger = logger;

            _endpointInformation = _substrateconfiguration.GetEndpoint(BlockchainName);
        }

        public ITimeQueryable At(BlockNumber blockNumber)
        {
            var result =    Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None).Result ?? 
                            Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None).Result ?? 
                            Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None).Result ?? 
                            Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None).Result;

            if (result is null)
            {
                var currentBlock = Rpc.Chain.GetBlockAsync().Result.GetBlock().Header.Number.Value;

                // Let check if current block is lower than this block
                if (currentBlock < blockNumber.Value)
                {
                    throw new InvalidOperationException($"Block number {blockNumber.Value} is higher than current block number {currentBlock}");
                }
                else
                {
                    Logger.LogWarning("[{blockChainName}] Unable to get block hash from block number {blockNumber}", BlockchainName, blockNumber);
                }
            }
            else
            {
                Storage.BlockHash = result.Value;
            }
            
            return this;
        }

        public ITimeQueryable At(U32 blockNumber) => At(blockNumber.Value);

        public ITimeQueryable At(uint blockNumber) => At(new BlockNumber(blockNumber));

        public ITimeQueryable At(int blockNumber) => At((uint)blockNumber);

        public ITimeQueryable At(Hash blockHash) => At(blockHash.Value);

        public ITimeQueryable At(string blockHash)
        {
            Storage.BlockHash = blockHash;

            OnBlockHashChanged();
            return this;
        }

        /// <summary>
        /// Triggered when block hash is changed
        /// </summary>
        /// <returns></returns>
        protected virtual void OnBlockHashChanged()
        {
            return;
        }

        public async Task<SignedExtensionMetadata[]?> SignedExtensionMetadataAsync()
        {
            var metadata = await GetMetadataAsync(CancellationToken.None);
            return metadata.NodeMetadata.Extrinsic.SignedExtensions;
        }

        /// <summary>
        /// Build an extrinsic, given the current metadata (potentially old metadata if BlockHash has been set)
        /// </summary>
        /// <param name="hex"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public async Task<IExtrinsic> GetExtrinsicAsync(string hex)
        {
            // Thanks to Rosta : https://github.com/RostislavLitovkin/PlutoWallet/blob/devel/PlutoWallet.Model/AjunaExt/SubstrateClientExt.cs#L62
            var sem = await SignedExtensionMetadataAsync();
            bool checkMetadataHash = sem is not null && sem.Any(x => x.SignedIdentifier == "CheckMetadataHash");
            ChargeType? defaultCharge;
            if (sem.Any(x => x.SignedIdentifier == "ChargeTransactionPayment"))
                defaultCharge = ChargeTransactionPayment.Default();
            else if (sem.Any(x => x.SignedIdentifier == "ChargeAssetTxPayment"))
                defaultCharge = ChargeAssetTxPayment.Default();
            else
                throw new InvalidOperationException("SignedIdentifier is not define");

            if(checkMetadataHash)
               return new TempNewExtrinsic(hex, defaultCharge);
            else
                return new TempOldExtrinsic(hex, defaultCharge);
        }

        public Hash GenesisHash => AjunaClient.GenesisHash;

        protected abstract Task InstanciateSubstrateServiceAsync();

        public bool IsConnected() => AjunaClient.IsConnected;

        public async Task ConnectAsync(CancellationToken token)
        {
            if(AjunaClient.IsConnected && ChainDependencies.All(x => x.IsConnected()))
            {
                _logger.LogWarning("Trying to connect to {blockchainName} but already connected", BlockchainName);
                return;
            }

            try
            {
                AjunaClient.ConnectionSet += (sender, e) 
                    => _logger.LogInformation("Successfully connected to {blockchainName} (endpoint : {providerName} {endpointUri})", BlockchainName, EndpointInformation.Name, EndpointInformation.Uri);

                AjunaClient.ConnectionLost += (sender, e) 
                    => _logger.LogWarning("Connection lost to {blockchainName} (endpoint : {providerName} {endpointUri}), trying to reconnect...", BlockchainName, EndpointInformation.Name, EndpointInformation.Uri);

                AjunaClient.OnReconnected += (sender, e) 
                    => _logger.LogInformation("Reconnected to {blockchainName} (endpoint : {providerName} {endpointUri}) after {nbRetry} retry", BlockchainName, EndpointInformation.Name, EndpointInformation.Uri, (int)e);

                await AjunaClient.ConnectAsync(token);

            } catch(UnableToReconnectException ex)
            {
                _logger.LogError(ex.Message);
                await TryToConnectToAnotherEndpointAsync(token);

                throw new SubstrateErrorNodeConnectionException(BlockchainName, _endpointInformation.Name, _endpointInformation.Uri.ToString(), "Error while trying to reconnect", ex);
            }
            catch (WebSocketException ex)
            {
                if(ex.ErrorCode == 429)
                {
                    _logger.LogError(ex, "Too many request to {blockchainName} (endpoint : {providerName} {endpointUri})", BlockchainName, EndpointInformation.Name, EndpointInformation.Uri);

                    //throw new TooManyRequestsException(EndpointInformation);
                    await TryToConnectToAnotherEndpointAsync(token);
                }
                    
                else
                    _logger.LogError(ex, "Error while trying to connect to {blockchainName}", BlockchainName);

                throw new SubstrateErrorNodeConnectionException(BlockchainName, _endpointInformation.Name, _endpointInformation.Uri.ToString(), $"Error while trying to connect", ex);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Error while trying to connect to {blockchainName}", BlockchainName);

                throw new SubstrateErrorNodeConnectionException(BlockchainName, _endpointInformation.Name, _endpointInformation.Uri.ToString(), "Unexpected error", ex);
            }

            List<Task> tasks = new List<Task>();
            // Now let's connect the dependencies
            foreach(var dependency in ChainDependencies)
            {
                tasks.Add(dependency.ConnectAsync(token));
            }
            
            await Task.WhenAll(tasks.ToArray());
        }

        private async Task TryToConnectToAnotherEndpointAsync(CancellationToken token)
        {
            await CloseAsync(token);

            // We are unable to reconnect to the current RPC node. Let's try another one
            var nextEndpoint = _substrateconfiguration.GetNextEndpoint(BlockchainName, _endpointInformation.Uri.OriginalString);
            await InstanciateSubstrateServiceAsync();

            await ConnectAsync(token);
        }

        public async Task CloseAsync(CancellationToken token)
        {
            await AjunaClient.CloseAsync(token);

            List<Task> tasks = new List<Task>();
            // Disconnect the dependencies
            foreach (var dependency in ChainDependencies)
            {
                tasks.Add(dependency.CloseAsync(token));
            }

            await Task.WhenAll(tasks.ToArray());
        }

        public RuntimeVersion RuntimeVersion
        {
            get
            {
                return AjunaClient.RuntimeVersion;
            }
        }

        

        /// <summary>
        /// Check every 'millisecondCheck' if we are connected to blockchain and call the callback method with status
        /// If we are not connected, try to reconnect
        /// </summary>
        /// <param name="isConnectedCallback">Callback status method</param>
        /// <param name="cancellationToken">Allow to stop the check</param>
        /// <param name="millisecondCheck">Millisecond frequency to check if we are connected and try to reconnect</param>
        /// <returns></returns>
        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {

                    isConnectedCallback(AjunaClient.IsConnected);
                    if (!AjunaClient.IsConnected)
                    {
                        try
                        {
                            await ConnectAsync(cancellationToken);
                        }
                        catch (Exception ex)
                        {
                            Logger.LogError(ex, "Error while trying to connect to Polkadot");
                        }
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(millisecondCheck), cancellationToken);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                _logger.LogWarning("CheckBlockchainStateAsync has been cancelled");
                throw;
            }
        }

        /// <summary>
        /// Check if account address is valid for current Substrate blockchain
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool IsValidAccountAddress(string address) => AddressExtension.IsValidAccountAddress(address);

        public async Task<(uint majorVersion, MetaData metadata)> GetMetadataWithVersionAsync(CancellationToken cancellationToken)
        {
            var metadataHex = Storage.BlockHash is not null ?
                await Rpc.State.GetMetaDataAsync(new Hash(Storage.BlockHash), cancellationToken) :
                await Rpc.State.GetMetaDataAsync(cancellationToken);

            if (metadataHex is null)
                throw new InvalidOperationException($"Unable to fetch metadata from blockHash = {Storage.BlockHash}");

            var res = MetadataHelper.GetMetadataFromHex(metadataHex);
            CheckRuntimeMetadata checkRuntimeMetadata = new CheckRuntimeMetadata(metadataHex);

            return (checkRuntimeMetadata.MetaDataInfo.Version.Value, res);
        }
        public async Task<MetaData> GetMetadataAsync(CancellationToken cancellationToken)
        {
            var metadataHex = Storage.BlockHash is not null ?
                await Rpc.State.GetMetaDataAsync(new Hash(Storage.BlockHash), cancellationToken) :
                await Rpc.State.GetMetaDataAsync(cancellationToken);

            if (metadataHex is null)
                throw new InvalidOperationException($"Unable to fetch metadata from blockHash = {Storage.BlockHash}");

            return MetadataHelper.GetMetadataFromHex(metadataHex);
        }
    }
}
