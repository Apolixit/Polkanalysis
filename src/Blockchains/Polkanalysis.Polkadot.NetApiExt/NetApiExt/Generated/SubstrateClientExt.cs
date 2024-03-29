//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Substrate.NetApi.Model.Extrinsics;
using Substrate.NetApi.Model.Meta;
using Substrate.NetApi.Model.Types.Base;
using Polkanalysis.Polkadot.NetApiExt.Generated.Storage;
using System.Collections.Generic;


namespace Polkanalysis.Polkadot.NetApiExt.Generated
{
    
    
    public class SubstrateClientExt : Substrate.NetApi.SubstrateClient
    {
        
        /// <summary>
        /// StorageKeyDict for key definition informations.
        /// </summary>
        public System.Collections.Generic.Dictionary<System.Tuple<string, string>, System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>> StorageKeyDict;
        
        /// <summary>
        /// SystemStorage storage calls.
        /// </summary>
        public SystemStorage SystemStorage;
        
        /// <summary>
        /// SchedulerStorage storage calls.
        /// </summary>
        public SchedulerStorage SchedulerStorage;
        
        /// <summary>
        /// PreimageStorage storage calls.
        /// </summary>
        public PreimageStorage PreimageStorage;
        
        /// <summary>
        /// BabeStorage storage calls.
        /// </summary>
        public BabeStorage BabeStorage;
        
        /// <summary>
        /// TimestampStorage storage calls.
        /// </summary>
        public TimestampStorage TimestampStorage;
        
        /// <summary>
        /// IndicesStorage storage calls.
        /// </summary>
        public IndicesStorage IndicesStorage;
        
        /// <summary>
        /// BalancesStorage storage calls.
        /// </summary>
        public BalancesStorage BalancesStorage;
        
        /// <summary>
        /// TransactionPaymentStorage storage calls.
        /// </summary>
        public TransactionPaymentStorage TransactionPaymentStorage;
        
        /// <summary>
        /// AuthorshipStorage storage calls.
        /// </summary>
        public AuthorshipStorage AuthorshipStorage;
        
        /// <summary>
        /// StakingStorage storage calls.
        /// </summary>
        public StakingStorage StakingStorage;
        
        /// <summary>
        /// OffencesStorage storage calls.
        /// </summary>
        public OffencesStorage OffencesStorage;
        
        /// <summary>
        /// HistoricalStorage storage calls.
        /// </summary>
        public HistoricalStorage HistoricalStorage;
        
        /// <summary>
        /// SessionStorage storage calls.
        /// </summary>
        public SessionStorage SessionStorage;
        
        /// <summary>
        /// GrandpaStorage storage calls.
        /// </summary>
        public GrandpaStorage GrandpaStorage;
        
        /// <summary>
        /// ImOnlineStorage storage calls.
        /// </summary>
        public ImOnlineStorage ImOnlineStorage;
        
        /// <summary>
        /// AuthorityDiscoveryStorage storage calls.
        /// </summary>
        public AuthorityDiscoveryStorage AuthorityDiscoveryStorage;
        
        /// <summary>
        /// DemocracyStorage storage calls.
        /// </summary>
        public DemocracyStorage DemocracyStorage;
        
        /// <summary>
        /// CouncilStorage storage calls.
        /// </summary>
        public CouncilStorage CouncilStorage;
        
        /// <summary>
        /// TechnicalCommitteeStorage storage calls.
        /// </summary>
        public TechnicalCommitteeStorage TechnicalCommitteeStorage;
        
        /// <summary>
        /// PhragmenElectionStorage storage calls.
        /// </summary>
        public PhragmenElectionStorage PhragmenElectionStorage;
        
        /// <summary>
        /// TechnicalMembershipStorage storage calls.
        /// </summary>
        public TechnicalMembershipStorage TechnicalMembershipStorage;
        
        /// <summary>
        /// TreasuryStorage storage calls.
        /// </summary>
        public TreasuryStorage TreasuryStorage;
        
        /// <summary>
        /// ClaimsStorage storage calls.
        /// </summary>
        public ClaimsStorage ClaimsStorage;
        
        /// <summary>
        /// VestingStorage storage calls.
        /// </summary>
        public VestingStorage VestingStorage;
        
        /// <summary>
        /// UtilityStorage storage calls.
        /// </summary>
        public UtilityStorage UtilityStorage;
        
        /// <summary>
        /// IdentityStorage storage calls.
        /// </summary>
        public IdentityStorage IdentityStorage;
        
        /// <summary>
        /// ProxyStorage storage calls.
        /// </summary>
        public ProxyStorage ProxyStorage;
        
        /// <summary>
        /// MultisigStorage storage calls.
        /// </summary>
        public MultisigStorage MultisigStorage;
        
        /// <summary>
        /// BountiesStorage storage calls.
        /// </summary>
        public BountiesStorage BountiesStorage;
        
        /// <summary>
        /// ChildBountiesStorage storage calls.
        /// </summary>
        public ChildBountiesStorage ChildBountiesStorage;
        
        /// <summary>
        /// TipsStorage storage calls.
        /// </summary>
        public TipsStorage TipsStorage;
        
        /// <summary>
        /// ElectionProviderMultiPhaseStorage storage calls.
        /// </summary>
        public ElectionProviderMultiPhaseStorage ElectionProviderMultiPhaseStorage;
        
        /// <summary>
        /// VoterListStorage storage calls.
        /// </summary>
        public VoterListStorage VoterListStorage;
        
        /// <summary>
        /// NominationPoolsStorage storage calls.
        /// </summary>
        public NominationPoolsStorage NominationPoolsStorage;
        
        /// <summary>
        /// FastUnstakeStorage storage calls.
        /// </summary>
        public FastUnstakeStorage FastUnstakeStorage;
        
        /// <summary>
        /// ParachainsOriginStorage storage calls.
        /// </summary>
        public ParachainsOriginStorage ParachainsOriginStorage;
        
        /// <summary>
        /// ConfigurationStorage storage calls.
        /// </summary>
        public ConfigurationStorage ConfigurationStorage;
        
        /// <summary>
        /// ParasSharedStorage storage calls.
        /// </summary>
        public ParasSharedStorage ParasSharedStorage;
        
        /// <summary>
        /// ParaInclusionStorage storage calls.
        /// </summary>
        public ParaInclusionStorage ParaInclusionStorage;
        
        /// <summary>
        /// ParaInherentStorage storage calls.
        /// </summary>
        public ParaInherentStorage ParaInherentStorage;
        
        /// <summary>
        /// ParaSchedulerStorage storage calls.
        /// </summary>
        public ParaSchedulerStorage ParaSchedulerStorage;
        
        /// <summary>
        /// ParasStorage storage calls.
        /// </summary>
        public ParasStorage ParasStorage;
        
        /// <summary>
        /// InitializerStorage storage calls.
        /// </summary>
        public InitializerStorage InitializerStorage;
        
        /// <summary>
        /// DmpStorage storage calls.
        /// </summary>
        public DmpStorage DmpStorage;
        
        /// <summary>
        /// UmpStorage storage calls.
        /// </summary>
        public UmpStorage UmpStorage;
        
        /// <summary>
        /// HrmpStorage storage calls.
        /// </summary>
        public HrmpStorage HrmpStorage;
        
        /// <summary>
        /// ParaSessionInfoStorage storage calls.
        /// </summary>
        public ParaSessionInfoStorage ParaSessionInfoStorage;
        
        /// <summary>
        /// ParasDisputesStorage storage calls.
        /// </summary>
        public ParasDisputesStorage ParasDisputesStorage;
        
        /// <summary>
        /// RegistrarStorage storage calls.
        /// </summary>
        public RegistrarStorage RegistrarStorage;
        
        /// <summary>
        /// SlotsStorage storage calls.
        /// </summary>
        public SlotsStorage SlotsStorage;
        
        /// <summary>
        /// AuctionsStorage storage calls.
        /// </summary>
        public AuctionsStorage AuctionsStorage;
        
        /// <summary>
        /// CrowdloanStorage storage calls.
        /// </summary>
        public CrowdloanStorage CrowdloanStorage;
        
        /// <summary>
        /// XcmPalletStorage storage calls.
        /// </summary>
        public XcmPalletStorage XcmPalletStorage;
        
        public SubstrateClientExt(System.Uri uri, Substrate.NetApi.Model.Extrinsics.ChargeType chargeType) : 
                base(uri, chargeType)
        {
            StorageKeyDict = new System.Collections.Generic.Dictionary<System.Tuple<string, string>, System.Tuple<Substrate.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>>();
            this.SystemStorage = new SystemStorage(this);
            this.SchedulerStorage = new SchedulerStorage(this);
            this.PreimageStorage = new PreimageStorage(this);
            this.BabeStorage = new BabeStorage(this);
            this.TimestampStorage = new TimestampStorage(this);
            this.IndicesStorage = new IndicesStorage(this);
            this.BalancesStorage = new BalancesStorage(this);
            this.TransactionPaymentStorage = new TransactionPaymentStorage(this);
            this.AuthorshipStorage = new AuthorshipStorage(this);
            this.StakingStorage = new StakingStorage(this);
            this.OffencesStorage = new OffencesStorage(this);
            this.HistoricalStorage = new HistoricalStorage(this);
            this.SessionStorage = new SessionStorage(this);
            this.GrandpaStorage = new GrandpaStorage(this);
            this.ImOnlineStorage = new ImOnlineStorage(this);
            this.AuthorityDiscoveryStorage = new AuthorityDiscoveryStorage(this);
            this.DemocracyStorage = new DemocracyStorage(this);
            this.CouncilStorage = new CouncilStorage(this);
            this.TechnicalCommitteeStorage = new TechnicalCommitteeStorage(this);
            this.PhragmenElectionStorage = new PhragmenElectionStorage(this);
            this.TechnicalMembershipStorage = new TechnicalMembershipStorage(this);
            this.TreasuryStorage = new TreasuryStorage(this);
            this.ClaimsStorage = new ClaimsStorage(this);
            this.VestingStorage = new VestingStorage(this);
            this.UtilityStorage = new UtilityStorage(this);
            this.IdentityStorage = new IdentityStorage(this);
            this.ProxyStorage = new ProxyStorage(this);
            this.MultisigStorage = new MultisigStorage(this);
            this.BountiesStorage = new BountiesStorage(this);
            this.ChildBountiesStorage = new ChildBountiesStorage(this);
            this.TipsStorage = new TipsStorage(this);
            this.ElectionProviderMultiPhaseStorage = new ElectionProviderMultiPhaseStorage(this);
            this.VoterListStorage = new VoterListStorage(this);
            this.NominationPoolsStorage = new NominationPoolsStorage(this);
            this.FastUnstakeStorage = new FastUnstakeStorage(this);
            this.ParachainsOriginStorage = new ParachainsOriginStorage(this);
            this.ConfigurationStorage = new ConfigurationStorage(this);
            this.ParasSharedStorage = new ParasSharedStorage(this);
            this.ParaInclusionStorage = new ParaInclusionStorage(this);
            this.ParaInherentStorage = new ParaInherentStorage(this);
            this.ParaSchedulerStorage = new ParaSchedulerStorage(this);
            this.ParasStorage = new ParasStorage(this);
            this.InitializerStorage = new InitializerStorage(this);
            this.DmpStorage = new DmpStorage(this);
            this.UmpStorage = new UmpStorage(this);
            this.HrmpStorage = new HrmpStorage(this);
            this.ParaSessionInfoStorage = new ParaSessionInfoStorage(this);
            this.ParasDisputesStorage = new ParasDisputesStorage(this);
            this.RegistrarStorage = new RegistrarStorage(this);
            this.SlotsStorage = new SlotsStorage(this);
            this.AuctionsStorage = new AuctionsStorage(this);
            this.CrowdloanStorage = new CrowdloanStorage(this);
            this.XcmPalletStorage = new XcmPalletStorage(this);
        }
    }
}
