using Ajuna.NetApi;
using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Microsoft.Extensions.Configuration;
using Substats.Configuration.Contracts;
using Substats.Domain.Contracts.Secondary;
using Substats.Polkadot.NetApiExt.Generated;
using Substats.Polkadot.NetApiExt.Generated.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Substats.Infrastructure.Polkadot.Repository
{
    //public class PolkadotSubstrateClientRepository : ISubstrateClientRepository
    //{
    //    private readonly ISubstrateEndpoint _substrateconfiguration;
    //    private SubstrateClientExt? _client;
    //    public PolkadotSubstrateClientRepository(ISubstrateEndpoint substrateconfiguration)
    //    {
    //        _substrateconfiguration = substrateconfiguration;
    //    }

    //    private SubstrateClientExt Client
    //    {
    //        get
    //        {
    //            if (_client == null)
    //            {
    //                _client = new SubstrateClientExt(_substrateconfiguration.EndPointUri, ChargeTransactionPayment.Default());
    //            }
    //            return _client;
    //        }
    //    }

    //    public SubstrateClient Core => Client;
    //    public MetaData MetaData => Client.MetaData;
    //    public BalancesStorage BalancesStorage => Client.BalancesStorage;
    //    public IdentityStorage IdentityStorage => Client.IdentityStorage;
    //    public NominationPoolsStorage NominationPoolsStorage => Client.NominationPoolsStorage;
    //    public SystemStorage SystemStorage => Client.SystemStorage;
    //    public StakingStorage StakingStorage => Client.StakingStorage;
    //    public AuthorshipStorage AuthorshipStorage => Client.AuthorshipStorage;
    //    public AuctionsStorage AuctionsStorage => Client.AuctionsStorage;
    //    public CrowdloanStorage CrowdloanStorage => Client.CrowdloanStorage;

    //    public ParasStorage ParasStorage => Client.ParasStorage;

    //    public SessionStorage SessionStorage => Client.SessionStorage;

    //    public ParaSessionInfoStorage ParaSessionInfoStorage => Client.ParaSessionInfoStorage;

    //    public RegistrarStorage RegistrarStorage => Client.RegistrarStorage;

    //    public BabeStorage BabeStorage => Client.BabeStorage;

    //    //public AwesomeAvatarsStorage? AwesomeAvatarsStorage => null;
    //}
}
