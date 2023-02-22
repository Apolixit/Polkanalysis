using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Types;
using Ajuna.NetApi.Model.Types.Base;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Substats.Infrastructure.Polkadot.Repository;
using Substats.Configuration.Contracts;
using Substats.Domain.Contracts.Secondary.Contracts;
using Substats.Infrastructure.Polkadot.Repository.Storage;
using Substats.Domain.Contracts.Secondary.Common;
using Substats.Domain.Contracts.Secondary.Rpc;
using Ajuna.NetApi.Model.Types.Primitive;
using Substats.Infrastructure.Common.Rpc;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Substats.Infrastructure.DirectAccess.Repository
{
    public class PolkadotRepository : ISubstrateRepository
    {
        private SubstrateClientExt? _polkadotClient;
        private readonly ISubstrateEndpoint _substrateconfiguration;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public PolkadotRepository(ISubstrateEndpoint substrateconfiguration, IMapper mapper, ILogger logger)
        {
            _substrateconfiguration = substrateconfiguration;
            _mapper = mapper;
            _logger = logger;
        }

        private SubstrateClientExt PolkadotClient
        {
            get
            {
                if (_polkadotClient == null)
                {
                    _polkadotClient = new SubstrateClientExt(_substrateconfiguration.EndPointUri, ChargeTransactionPayment.Default());
                }
                return _polkadotClient;
            }
        }

        public string BlockchainName => "Polkadot";

        private IStorage? _polkadotStorage = null;
        public IStorage Storage
        {
            get
            {
                if (_polkadotStorage == null)
                    _polkadotStorage = new PolkadotStorage(PolkadotClient, _mapper, _logger);

                return _polkadotStorage;
            }
        }

        public IRpc Rpc => throw new NotImplementedException();

        public IConstants Constants => throw new NotImplementedException();

        public ICalls Calls => throw new NotImplementedException();

        public IEvents Events => throw new NotImplementedException();

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
            //try
            //{
            //    while (!cancellationToken.IsCancellationRequested)
            //    {

            //        isConnectedCallback(Client.Core.IsConnected);
            //        if (!Client.Core.IsConnected)
            //        {
            //            try
            //            {
            //                await Client.Core.ConnectAsync(cancellationToken);
            //            }
            //            catch (Exception ex)
            //            {
            //                // TODO
            //                isConnectedCallback(Client.Core.IsConnected);
            //            }
            //        }

            //        await Task.Delay(TimeSpan.FromMilliseconds(millisecondCheck), cancellationToken);
            //    }
            //}
            //catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            //{

            //}
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
            throw new NotImplementedException();
        }

        public ITimeQueryable At(string blockHash)
        {
            throw new NotImplementedException();
        }

        public bool IsConnected() => PolkadotClient.IsConnected;

        public Task ConnectAsync() => PolkadotClient.ConnectAsync();

        public Task CloseAsync() => PolkadotClient.CloseAsync();
    }
}
