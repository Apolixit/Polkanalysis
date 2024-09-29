using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Utils.Address;
using Substrate.NetApi;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;

namespace Polkanalysis.Infrastructure.Blockchain
{
    public abstract class BlockchainAbstractService : ISubstrateService
    {
        public abstract ILogger Logger { get; }
        public abstract IEnumerable<string> Dependencies { get; }
        public abstract SubstrateClient AjunaClient { get; }
        public abstract string BlockchainName { get; }
        public abstract IStorage Storage { get; }
        public abstract IRpc Rpc { get; }
        public abstract IConstants Constants { get; }
        public abstract ICalls Calls { get; }
        public abstract IEvents Events { get; }
        public abstract IErrors Errors { get; }

        public ITimeQueryable At(BlockNumber blockNumber)
        {
            Storage.BlockHash = Rpc.Chain.GetBlockHashAsync(blockNumber, CancellationToken.None).GetAwaiter().GetResult().Value;
            return this;
        }

        public ITimeQueryable At(U32 blockNumber) => At(blockNumber.Value);

        public ITimeQueryable At(uint blockNumber) => At(new BlockNumber(blockNumber));

        public ITimeQueryable At(int blockNumber) => At((uint)blockNumber);

        public ITimeQueryable At(Hash blockHash)
        {
            Storage.BlockHash = blockHash.Value;
            return this;
        }

        public ITimeQueryable At(string blockHash)
        {
            Storage.BlockHash = blockHash;
            return this;
        }

        public Hash GenesisHash => AjunaClient.GenesisHash;
        public bool IsConnected() => AjunaClient.IsConnected;

        public Task ConnectAsync() => AjunaClient.ConnectAsync();

        public Task CloseAsync() => AjunaClient.CloseAsync();

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
                            await AjunaClient.ConnectAsync(cancellationToken);
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

            }
        }

        /// <summary>
        /// Check if account address is valid for current Substrate blockchain
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public bool IsValidAccountAddress(string address) => AddressExtension.IsValidAccountAddress(address);

        public async Task<Substrate.NetApi.Model.Meta.MetaData> GetMetadataAsync(CancellationToken cancellationToken)
        {
            var metadataHex = Storage.BlockHash is not null ?
                await Rpc.State.GetMetaDataAsync(new Hash(Storage.BlockHash), cancellationToken) :
                await Rpc.State.GetMetaDataAsync(cancellationToken);

            if (metadataHex is null)
                throw new InvalidOperationException($"Unable to fetch metadata from blockHash = {Storage.BlockHash}");

            var version = MetadataUtils.GetMetadataVersion(metadataHex);

            MetadataV14? v14 = null;
            switch (version)
            {
                case MetadataVersion.V9:
                    var v9 = new Substrate.NET.Metadata.V9.MetadataV9(metadataHex);
                    v14 = v9.ToMetadataV14();
                    break;
                case MetadataVersion.V10:
                    var v10 = new Substrate.NET.Metadata.V10.MetadataV10(metadataHex);
                    v14 = v10.ToMetadataV14();
                    break;
                case MetadataVersion.V11:
                    var v11 = new Substrate.NET.Metadata.V11.MetadataV11(metadataHex);

                    v14 = v11.ToMetadataV14();
                    break;
                case MetadataVersion.V12:
                    var v12 = new Substrate.NET.Metadata.V12.MetadataV12(metadataHex);
                    v14 = v12.ToMetadataV14();
                    break;
                case MetadataVersion.V13:
                    var v13 = new Substrate.NET.Metadata.V13.MetadataV13(metadataHex);
                    v14 = v13.ToMetadataV14();
                    break;
                case MetadataVersion.V14:
                    v14 = new MetadataV14(metadataHex);
                    break;
                default:
                    throw new InvalidOperationException($"Metadata version {version} is not supported!");
            }

            Substrate.NetApi.Model.Meta.MetaData metadata = v14.ToNetApiMetadata();

            return metadata;
        }
    }
}
