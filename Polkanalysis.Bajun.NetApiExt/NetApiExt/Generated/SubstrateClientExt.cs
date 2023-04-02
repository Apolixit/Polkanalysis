//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Ajuna.NetApi.Model.Extrinsics;
using Ajuna.NetApi.Model.Meta;
using Ajuna.NetApi.Model.Types.Base;
using Polkanalysis.Bajun.NetApiExt.Generated.Storage;
using System.Collections.Generic;


namespace Polkanalysis.Bajun.NetApiExt.Generated
{
    
    
    public sealed class SubstrateClientExt : Ajuna.NetApi.SubstrateClient
    {
        
        /// <summary>
        /// StorageKeyDict for key definition informations.
        /// </summary>
        public System.Collections.Generic.Dictionary<System.Tuple<string, string>, System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>> StorageKeyDict;
        
        /// <summary>
        /// SystemStorage storage calls.
        /// </summary>
        public SystemStorage SystemStorage;
        
        /// <summary>
        /// ParachainSystemStorage storage calls.
        /// </summary>
        public ParachainSystemStorage ParachainSystemStorage;
        
        /// <summary>
        /// TimestampStorage storage calls.
        /// </summary>
        public TimestampStorage TimestampStorage;
        
        /// <summary>
        /// ParachainInfoStorage storage calls.
        /// </summary>
        public ParachainInfoStorage ParachainInfoStorage;
        
        /// <summary>
        /// MultisigStorage storage calls.
        /// </summary>
        public MultisigStorage MultisigStorage;
        
        /// <summary>
        /// UtilityStorage storage calls.
        /// </summary>
        public UtilityStorage UtilityStorage;
        
        /// <summary>
        /// RandomnessStorage storage calls.
        /// </summary>
        public RandomnessStorage RandomnessStorage;
        
        /// <summary>
        /// IdentityStorage storage calls.
        /// </summary>
        public IdentityStorage IdentityStorage;
        
        /// <summary>
        /// ProxyStorage storage calls.
        /// </summary>
        public ProxyStorage ProxyStorage;
        
        /// <summary>
        /// SchedulerStorage storage calls.
        /// </summary>
        public SchedulerStorage SchedulerStorage;
        
        /// <summary>
        /// PreImageStorage storage calls.
        /// </summary>
        public PreImageStorage PreImageStorage;
        
        /// <summary>
        /// BalancesStorage storage calls.
        /// </summary>
        public BalancesStorage BalancesStorage;
        
        /// <summary>
        /// TransactionPaymentStorage storage calls.
        /// </summary>
        public TransactionPaymentStorage TransactionPaymentStorage;
        
        /// <summary>
        /// VestingStorage storage calls.
        /// </summary>
        public VestingStorage VestingStorage;
        
        /// <summary>
        /// AuthorshipStorage storage calls.
        /// </summary>
        public AuthorshipStorage AuthorshipStorage;
        
        /// <summary>
        /// CollatorSelectionStorage storage calls.
        /// </summary>
        public CollatorSelectionStorage CollatorSelectionStorage;
        
        /// <summary>
        /// SessionStorage storage calls.
        /// </summary>
        public SessionStorage SessionStorage;
        
        /// <summary>
        /// AuraStorage storage calls.
        /// </summary>
        public AuraStorage AuraStorage;
        
        /// <summary>
        /// AuraExtStorage storage calls.
        /// </summary>
        public AuraExtStorage AuraExtStorage;
        
        /// <summary>
        /// XcmpQueueStorage storage calls.
        /// </summary>
        public XcmpQueueStorage XcmpQueueStorage;
        
        /// <summary>
        /// PolkadotXcmStorage storage calls.
        /// </summary>
        public PolkadotXcmStorage PolkadotXcmStorage;
        
        /// <summary>
        /// CumulusXcmStorage storage calls.
        /// </summary>
        public CumulusXcmStorage CumulusXcmStorage;
        
        /// <summary>
        /// DmpQueueStorage storage calls.
        /// </summary>
        public DmpQueueStorage DmpQueueStorage;
        
        /// <summary>
        /// SudoStorage storage calls.
        /// </summary>
        public SudoStorage SudoStorage;
        
        /// <summary>
        /// TreasuryStorage storage calls.
        /// </summary>
        public TreasuryStorage TreasuryStorage;
        
        /// <summary>
        /// CouncilStorage storage calls.
        /// </summary>
        public CouncilStorage CouncilStorage;
        
        /// <summary>
        /// CouncilMembershipStorage storage calls.
        /// </summary>
        public CouncilMembershipStorage CouncilMembershipStorage;
        
        /// <summary>
        /// AwesomeAvatarsStorage storage calls.
        /// </summary>
        public AwesomeAvatarsStorage AwesomeAvatarsStorage;
        
        public SubstrateClientExt(System.Uri uri, Ajuna.NetApi.Model.Extrinsics.ChargeType chargeType) : 
                base(uri, chargeType)
        {
            StorageKeyDict = new System.Collections.Generic.Dictionary<System.Tuple<string, string>, System.Tuple<Ajuna.NetApi.Model.Meta.Storage.Hasher[], System.Type, System.Type>>();
            this.SystemStorage = new SystemStorage(this);
            this.ParachainSystemStorage = new ParachainSystemStorage(this);
            this.TimestampStorage = new TimestampStorage(this);
            this.ParachainInfoStorage = new ParachainInfoStorage(this);
            this.MultisigStorage = new MultisigStorage(this);
            this.UtilityStorage = new UtilityStorage(this);
            this.RandomnessStorage = new RandomnessStorage(this);
            this.IdentityStorage = new IdentityStorage(this);
            this.ProxyStorage = new ProxyStorage(this);
            this.SchedulerStorage = new SchedulerStorage(this);
            this.PreImageStorage = new PreImageStorage(this);
            this.BalancesStorage = new BalancesStorage(this);
            this.TransactionPaymentStorage = new TransactionPaymentStorage(this);
            this.VestingStorage = new VestingStorage(this);
            this.AuthorshipStorage = new AuthorshipStorage(this);
            this.CollatorSelectionStorage = new CollatorSelectionStorage(this);
            this.SessionStorage = new SessionStorage(this);
            this.AuraStorage = new AuraStorage(this);
            this.AuraExtStorage = new AuraExtStorage(this);
            this.XcmpQueueStorage = new XcmpQueueStorage(this);
            this.PolkadotXcmStorage = new PolkadotXcmStorage(this);
            this.CumulusXcmStorage = new CumulusXcmStorage(this);
            this.DmpQueueStorage = new DmpQueueStorage(this);
            this.SudoStorage = new SudoStorage(this);
            this.TreasuryStorage = new TreasuryStorage(this);
            this.CouncilStorage = new CouncilStorage(this);
            this.CouncilMembershipStorage = new CouncilMembershipStorage(this);
            this.AwesomeAvatarsStorage = new AwesomeAvatarsStorage(this);
        }
    }
}