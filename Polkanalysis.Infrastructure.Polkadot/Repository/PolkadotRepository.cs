using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Types;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Domain.Contracts.Secondary;
using Polkanalysis.Polkadot.NetApiExt.Generated;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Polkanalysis.Infrastructure.Polkadot.Repository;
using Polkanalysis.Configuration.Contracts;
using Polkanalysis.Domain.Contracts.Secondary.Contracts;
using Polkanalysis.Infrastructure.Polkadot.Repository.Storage;
using Polkanalysis.Domain.Contracts.Secondary.Common;
using Polkanalysis.Domain.Contracts.Secondary.Rpc;
using Substrate.NetApi.Model.Types.Primitive;
using Polkanalysis.Infrastructure.Common.Rpc;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Polkanalysis.Infrastructure.Polkadot.Mapper;
using Substrate.NetApi;
using Polkanalysis.Infrastructure.Polkadot.Repository.Events;
using Polkanalysis.Domain.Contracts.Runtime;

namespace Polkanalysis.Infrastructure.DirectAccess.Repository
{
    public class PolkadotRepository : ISubstrateRepository
    {
        private SubstrateClientExt? _polkadotClient;
        private readonly ISubstrateEndpoint _substrateconfiguration;
        private readonly ILogger<PolkadotRepository> _logger;

        public PolkadotRepository(
            ISubstrateEndpoint substrateconfiguration,
            ILogger<PolkadotRepository> logger)
        {
            _substrateconfiguration = substrateconfiguration;
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
                    _polkadotStorage = new PolkadotStorage(PolkadotClient, _logger);

                return _polkadotStorage;
            }
        }

        private IRpc? _rpc = null;
        public IRpc Rpc {
            get {
                if (_rpc == null)
                    _rpc = new Rpc(PolkadotClient);

                return _rpc;
            }
        }

        public IConstants Constants => throw new NotImplementedException();

        public ICalls Calls => throw new NotImplementedException();

        private IEvents? _events = null;
        public IEvents Events {
            get
            {
                if (_events == null)
                    _events = new PolkadotEvents(PolkadotClient, _logger);

                return _events;
            }
}

        public IErrors Errors => throw new NotImplementedException();

        public Hash GenesisHash => PolkadotClient.GenesisHash;

        private IMetadata? _runtimeMetadata = null;
        public IMetadata RuntimeMetadata
        {
            get
            {
                if (_runtimeMetadata == null)
                    _runtimeMetadata = new RuntimeMetadata(PolkadotClient);

                return _runtimeMetadata;
            }
        }

        private IRuntimeVersion? _runtimeVersion = null;
        public IRuntimeVersion RuntimeVersion
        {
            get
            {
                if(_runtimeVersion == null)
                    _runtimeVersion = new RuntimeVersion(PolkadotClient);

                return _runtimeVersion;
            }
        }

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
                        catch (Exception ex)
                        {
                            // TODO
                        }
                    }

                    await Task.Delay(TimeSpan.FromMilliseconds(millisecondCheck), cancellationToken);
                }
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {

            }
        }

        public bool IsValidAccountAddress(string address)
        {
            return true; // TODO
        }

        public ITimeQueryable At(U32 blockNumber)
        {
            throw new NotImplementedException();
        }

        public ITimeQueryable At(BlockNumber blockNumber)
        {
            throw new NotImplementedException();
        }

        public ITimeQueryable At(uint blockNumber)
        {
            throw new NotImplementedException();
        }

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
