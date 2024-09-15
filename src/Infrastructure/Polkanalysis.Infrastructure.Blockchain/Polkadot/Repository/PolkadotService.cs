using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Polkanalysis.Configuration.Contracts;
using Substrate.NetApi.Model.Types.Primitive;
using Microsoft.Extensions.Logging;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Storage;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository.Events;
using Substrate.NetApi.Model.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Common;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Substrate.NET.Utils.Address;
using Substrate.NET.Metadata.Base;
using Substrate.NET.Metadata.V14;
using Substrate.NetApi.Model.Meta;
using System.Threading;
using Substrate.NET.Metadata.Service;

namespace Polkanalysis.Infrastructure.Blockchain.Polkadot.Repository
{
    public class PolkadotService : ISubstrateService
    {
        private SubstrateClientExt? _polkadotClient;
        private readonly ISubstrateEndpoint _substrateconfiguration;
        private readonly IBlockchainMapping _blockchainMapping;
        private readonly ILogger<PolkadotService> _logger;

        public PolkadotService(
            ISubstrateEndpoint substrateconfiguration,
            IBlockchainMapping blockchainMapping,
            ILogger<PolkadotService> logger)
        {
            _substrateconfiguration = substrateconfiguration;
            _blockchainMapping = blockchainMapping;
            _logger = logger;
        }

        public virtual SubstrateClient AjunaClient => PolkadotClient;

        public SubstrateClientExt PolkadotClient
        {
            get
            {
                if (_polkadotClient == null)
                {
                    _polkadotClient = new SubstrateClientExt(_substrateconfiguration.WsEndpointUri, ChargeTransactionPayment.Default());
                }
                return _polkadotClient;
            }

            set
            {
                _polkadotClient = value;
            }
        }

        public string BlockchainName => "Polkadot";

        private IStorage? _polkadotStorage = null;
        public IStorage Storage
        {
            get
            {
                if (_polkadotStorage == null)
                    _polkadotStorage = new PolkadotStorage(PolkadotClient, _blockchainMapping, _logger);

                return _polkadotStorage;
            }
        }

        private IRpc? _rpc = null;
        public IRpc Rpc
        {
            get
            {
                if (_rpc == null)
                    _rpc = new Rpc(PolkadotClient);

                return _rpc;
            }
        }

        public IConstants Constants => throw new NotImplementedException();

        public ICalls Calls => throw new NotImplementedException();

        private IEvents? _events = null;
        public IEvents Events
        {
            get
            {
                if (_events == null)
                    _events = new PolkadotEvents(PolkadotClient, _blockchainMapping, _logger);

                return _events;
            }
        }

        public IErrors Errors => throw new NotImplementedException();

        public Hash GenesisHash => PolkadotClient.GenesisHash;

        public async Task<MetaData> GetMetadataAsync(CancellationToken cancellationToken)
        {
            var metadataHex = await Rpc.State.GetMetaDataAsync(new Hash(Storage.BlockHash), cancellationToken);

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

            MetaData metadata = v14.ToNetApiMetadata();

            return metadata;
        }

        public RuntimeVersion RuntimeVersion
        {
            get
            {
                return AjunaClient.RuntimeVersion;
            }
        }

        //IMetadata ISubstrateService.RuntimeMetadata => throw new NotImplementedException();

        //IRpc ISubstrateService.Rpc => throw new NotImplementedException();

        //IConstants ISubstrateService.Constants => throw new NotImplementedException();

        //ICalls ISubstrateService.Calls => throw new NotImplementedException();

        //IEvents ISubstrateService.Events => throw new NotImplementedException();

        //IErrors ISubstrateService.Errors => throw new NotImplementedException();

        //IStorage ITimeQueryable.Storage => throw new NotImplementedException();

        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {

                    isConnectedCallback(PolkadotClient.IsConnected);
                    if (!PolkadotClient.IsConnected)
                    {
                        try
                        {
                            await PolkadotClient.ConnectAsync(cancellationToken);
                        }
                        catch (System.Exception ex)
                        {
                            _logger.LogError(ex, "Error while trying to connect to Polkadot");
                        }
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(millisecondCheck), cancellationToken);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {

            }
        }

        public bool IsValidAccountAddress(string address) => AddressExtension.IsValidAccountAddress(address);

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

        public bool IsConnected() => PolkadotClient.IsConnected;

        public Task ConnectAsync() => PolkadotClient.ConnectAsync();

        public Task CloseAsync() => PolkadotClient.CloseAsync();
    }
}
