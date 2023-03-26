using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Substats.Configuration.Contracts;
using Substats.Domain.Contracts.Secondary;
using Substats.Domain.Contracts.Secondary.Contracts;
using Substats.Domain.Contracts.Secondary.Rpc;
using Substats.Infrastructure.Polkadot.Repository.Storage;
using Substats.Polkadot.NetApiExt.Generated;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository
{
    //public class PolkadotRequestRepository : ISubstrateRequestRepository
    //{
    //    private readonly ISubstrateEndpoint _substrateconfiguration;
    //    private SubstrateClientExt? _polkadotClient;
    //    public PolkadotRequestRepository(ISubstrateEndpoint substrateconfiguration)
    //    {
    //        _substrateconfiguration = substrateconfiguration;
    //    }

    //    private SubstrateClientExt PolkadotClient
    //    {
    //        get
    //        {
    //            if (_polkadotClient == null)
    //            {
    //                _polkadotClient = new SubstrateClientExt(_substrateconfiguration.EndPointUri, ChargeTransactionPayment.Default());
    //            }
    //            return _polkadotClient;
    //        }
    //    }

    //    public SubstrateClient Client => PolkadotClient;

    //    private IStorage? _polkadotStorage = null;
    //    public IStorage Storage
    //    {
    //        get
    //        {
    //            if (_polkadotStorage == null)
    //                _polkadotStorage = new PolkadotStorage(PolkadotClient);
                
    //            return _polkadotStorage;
    //        }
    //    }

    //    public IRpc Rpc => throw new NotImplementedException();

    //    public IConstants Constants => throw new NotImplementedException();

    //    public ICalls Calls => throw new NotImplementedException();

    //    public IEvents Events => throw new NotImplementedException();

    //    public IErrors Errors => throw new NotImplementedException();
    //}
}
