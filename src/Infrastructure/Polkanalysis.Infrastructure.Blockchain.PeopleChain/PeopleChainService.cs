using Microsoft.Extensions.Logging;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Contracts;
using Polkanalysis.Infrastructure.Blockchain.Contracts.Rpc;
using Polkanalysis.PeopleChain.NetApiExt.Generated;
using Substrate.NetApi;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Rpc;
using Substrate.NetApi.Model.Types.Base;
using Substrate.NetApi.Model.Types.Primitive;
using Substrate.NetApi.Model.Extrinsics;
using Polkanalysis.Infrastructure.Blockchain.Common.Rpc;
using Substrate.NET.Metadata.Service;
using Substrate.NET.Metadata.V14;
using Substrate.NET.Utils.Address;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Storage;
using Polkanalysis.Infrastructure.Blockchain.PeopleChain.Events;

namespace Polkanalysis.Infrastructure.Blockchain.PeopleChain
{
    public class PeopleChainService : ISubstrateService
    {
        private SubstrateClientExt? _peopleChainClient;
        private readonly ISubstrateEndpoint _substrateconfiguration;
        private readonly IBlockchainMapping _blockchainMapping;
        private readonly ILogger<PeopleChainService> _logger;

        public PeopleChainService(
            ISubstrateEndpoint substrateconfiguration,
            IBlockchainMapping blockchainMapping,
            ILogger<PeopleChainService> logger)
        {
            _substrateconfiguration = substrateconfiguration;
            _blockchainMapping = blockchainMapping;
            _logger = logger;
        }

        public SubstrateClientExt PeopleChainClient
        {
            get
            {
                if (_peopleChainClient == null)
                {
                    _peopleChainClient = new SubstrateClientExt(_substrateconfiguration.WsEndpointUri, ChargeTransactionPayment.Default());
                }
                return _peopleChainClient;
            }

            set
            {
                _peopleChainClient = value;
            }
        }

        public SubstrateClient AjunaClient => PeopleChainClient;

        public string BlockchainName => "PeopleChain";

        private IStorage? _polkadotStorage = null;
        public IStorage Storage
        {
            get
            {
                if (_polkadotStorage == null)
                    _polkadotStorage = new PeopleChainStorage(PeopleChainClient, _blockchainMapping, _logger);

                return _polkadotStorage;
            }
        }

        private IRpc? _rpc = null;
        public IRpc Rpc
        {
            get
            {
                if (_rpc == null)
                    _rpc = new Rpc(PeopleChainClient);

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
                    _events = new PeopleChainEvents(PeopleChainClient, _blockchainMapping, _logger);

                return _events;
            }
        }

        public IErrors Errors => throw new NotImplementedException();

        public Hash GenesisHash => PeopleChainClient.GenesisHash;

        public async Task<MetaData> GetMetadataAsync(CancellationToken cancellationToken)
        {
            var metadataHex = Storage.BlockHash is not null ?
                await Rpc.State.GetMetaDataAsync(new Hash(Storage.BlockHash), cancellationToken) :
                await Rpc.State.GetMetaDataAsync(cancellationToken);

            if (metadataHex is null)
                throw new InvalidOperationException($"Unable to fetch metadata from blockHash = {Storage.BlockHash}");

            var version = MetadataUtils.GetMetadataVersion(metadataHex);

            MetadataV14 v14 = new MetadataV14(metadataHex); ;

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

        public async Task CheckBlockchainStateAsync(Action<bool> isConnectedCallback, CancellationToken cancellationToken, int millisecondCheck = 500)
        {
            try
            {
                while (!cancellationToken.IsCancellationRequested)
                {

                    isConnectedCallback(PeopleChainClient.IsConnected);
                    if (!PeopleChainClient.IsConnected)
                    {
                        try
                        {
                            await PeopleChainClient.ConnectAsync(cancellationToken);
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

        public bool IsConnected() => PeopleChainClient.IsConnected;

        public Task ConnectAsync() => PeopleChainClient.ConnectAsync();

        public Task CloseAsync() => PeopleChainClient.CloseAsync();
    }
}
