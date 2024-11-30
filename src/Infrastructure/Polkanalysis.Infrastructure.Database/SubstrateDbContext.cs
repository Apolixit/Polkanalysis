using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Common.Migrations;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Blocks;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Errors;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Nfts;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.NominationPools;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Staking;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Extrinsics;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Price;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;
using System.Collections.Generic;

namespace Polkanalysis.Infrastructure.Database
{
    public class SubstrateDbContext : DbContext
    {
        public SubstrateDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ExtrinsicsInformationModel> ExtrinsicsInformation { get; set; }
        public DbSet<EraLifetimeModel> EraLifetime { get; set; }
        public DbSet<SubstrateErrorModel> SubstrateErrors { get; set; }

        #region Blocks
        public DbSet<BlockInformationModel> BlockInformation { get; set; }
        #endregion

        #region Historical data price
        public DbSet<TokenPriceModel> TokenPrices { get; set; }
        #endregion

        #region Events
        public DbSet<EventManagerModel> EventManager { get; set; }

        /// <summary>
        /// All events of each blocks
        /// </summary>
        public DbSet<EventsInformationModel> EventsInformation { get; set; }

        #region Nfts
        public DbSet<NftsCreatedModel> EventNftsCreated { get; set; }
        public DbSet<NftsTeamChangedModel> EventNftsTeamChanged { get; set; }
        public DbSet<NftsAllApprovalsCancelledModel> EventNftsAllApprovalsCancelled { get; set; }
        public DbSet<NftsApprovalCancelledModel> EventNftsApprovalCancelled { get; set; }
        public DbSet<NftsBurnedModel> EventNftsBurned { get; set; }
        public DbSet<NftsCollectionConfigChangedModel> EventNftsCollectionConfigChanged { get; set; }
        public DbSet<NftsCollectionLockedModel> EventNftsCollectionLocked { get; set; }
        public DbSet<NftsCollectionMaxSupplySetModel> EventNftsCollectionMaxSupplySet { get; set; }
        public DbSet<NftsCollectionMetadataClearedModel> EventNftsCollectionMetadataCleared { get; set; }
        public DbSet<NftsCollectionMetadataSetModel> EventNftsCollectionMetadataSet { get; set; }
        public DbSet<NftsCollectionMintSettingsUpdatedModel> EventNftsCollectionMintSettingsUpdated { get; set; }
        public DbSet<NftsDestroyedModel> EventNftsDestroyed { get; set; }
        public DbSet<NftsForceCreatedModel> EventNftsForceCreated { get; set; }
        public DbSet<NftsIssuedModel> EventNftsIssued { get; set; }
        public DbSet<NftsItemAttributesApprovalAddedModel> EventNftsItemAttributesApprovalAdded { get; set; }
        public DbSet<NftsItemAttributesApprovalRemovedModel> EventNftsItemAttributesApprovalRemoved { get; set; }
        public DbSet<NftsItemBoughtModel> EventNftsItemBought { get; set; }
        public DbSet<NftsItemMetadataClearedModel> EventNftsItemMetadataCleared { get; set; }
        public DbSet<NftsItemMetadataSetModel> EventNftsItemMetadataSet { get; set; }
        public DbSet<NftsItemPriceRemovedModel> EventNftsItemPriceRemoved { get; set; }
        public DbSet<NftsItemTransferLockedModel> EventNftsItemTransferLocked { get; set; }
        public DbSet<NftsItemPriceSetModel> EventNftsItemPriceSet { get; set; }
        public DbSet<NftsItemPropertiesLockedModel> EventNftsItemPropertiesLocked { get; set; }
        public DbSet<NftsItemTransferUnlockedModel> EventNftsItemTransferUnlocked { get; set; }
        public DbSet<NftsNextCollectionIdIncrementedModel> EventNftsNextCollectionIdIncremented { get; set; }
        public DbSet<NftsOwnerChangedModel> EventNftsOwnerChanged { get; set; }
        //public DbSet<NftsOwnershipAcceptanceChangedModel> EventNftsOwnershipAcceptanceChanged { get; set; }
        public DbSet<NftsTipSentModel> EventNftsTipSent { get; set; }
        public DbSet<NftsTransferApprovedModel> EventNftsTransferApproved { get; set; }
        public DbSet<NftsTransferredModel> EventNftsTransferred { get; set; }

        #endregion
        #region Balances
        public DbSet<BalancesBalanceSetModel> EventBalancesBalanceSet { get; set; }
        public DbSet<BalancesDustLostModel> EventBalancesDustLost { get; set; }
        public DbSet<BalancesEndowedModel> EventBalancesEndowed { get; set; }
        public DbSet<BalancesReservedModel> EventBalancesReserved { get; set; }
        public DbSet<BalancesSlashedModel> EventBalancesSlashed { get; set; }
        public DbSet<BalancesTransferModel> EventBalancesTransfer { get; set; }
        public DbSet<BalancesUnreservedModel> EventBalancesUnreserved { get; set; }
        #endregion

        #region Identity
        public DbSet<IdentityIdentityClearedModel> EventIdentityIdentityCleared { get; set; }
        public DbSet<IdentityIdentityKilledModel> EventIdentityIdentityKilled { get; set; }
        public DbSet<IdentityIdentitySetModel> EventIdentityIdentitySet { get; set; }
        #endregion

        #region System
        public DbSet<SystemKilledAccountModel> EventSystemKilledAccount { get; set; }
        public DbSet<SystemNewAccountModel> EventSystemNewAccount { get; set; }
        #endregion

        #region Staking
        public DbSet<EraStakersModel> EraStakersModels { get; set; }
        #endregion

        #region Crowdloan
        public DbSet<CrowdloanContributedModel> EventCrowdloanContributed { get; set; }
        public DbSet<CrowdloanCreatedModel> EventCrowdloanCreated { get; set; }
        #endregion

        #region Auctions
        public DbSet<AuctionsAuctionStartedModel> EventAuctionsAuctionStarted { get; set; }
        public DbSet<AuctionsAuctionClosedModel> EventAuctionsAuctionClosed { get; set; }
        #endregion

        #region Nominations Pool
        public DbSet<NominationPoolsCreatedModel> EventNominationPoolsCreated { get; set; }
        public DbSet<NominationPoolsBondedModel> EventNominationPoolsBonded { get; set; }
        public DbSet<NominationPoolsPaidOutModel> EventNominationPoolsPaidOut { get; set; }
        public DbSet<NominationPoolsUnbondedModel> EventNominationPoolsUnbonded { get; set; }
        public DbSet<NominationPoolsWithdrawnModel> EventNominationPoolsWithdrawn { get; set; }
        public DbSet<NominationPoolsDestroyedModel> EventNominationPoolsDestroyed { get; set; }
        public DbSet<NominationPoolsMemberRemovedModel> EventNominationPoolsMemberRemoved { get; set; }
        public DbSet<NominationPoolsPoolCommissionClaimedModel> EventNominationPoolsPoolCommissionClaimed { get; set; }
        public DbSet<NominationPoolsMinBalanceDeficitAdjustedModel> EventNominationPoolsMinBalanceDeficitAdjusted { get; set; }
        public DbSet<NominationPoolsMinBalanceExcessAdjustedModel> EventNominationPoolsMinBalanceExcessAdjusted { get; set; }
        #endregion

        #region Staking
        public DbSet<StakingEraPaidModel> EventStakingEraPaid { get; set; }
        #endregion
        #endregion

        #region Version
        public DbSet<SpecVersionModel> SpecVersionModels { get; set; }
        public DbSet<PalletVersionModel> PalletVersionModels { get; set; }
        #endregion

        #region OnModelCreating by events auto generated
        protected void OnModelCreatingNfts(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NftsCreatedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Creator, c.Owner });
            modelBuilder.Entity<NftsTeamChangedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Issuer, c.Admin, c.Freezer });
            modelBuilder.Entity<NftsAllApprovalsCancelledModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Owner });
            modelBuilder.Entity<NftsApprovalCancelledModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Owner, c.Delegate });
            modelBuilder.Entity<NftsBurnedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Owner });
            modelBuilder.Entity<NftsCollectionConfigChangedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection });
            modelBuilder.Entity<NftsCollectionLockedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection });
            modelBuilder.Entity<NftsCollectionMaxSupplySetModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Max_supply });
            modelBuilder.Entity<NftsCollectionMetadataClearedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection });
            modelBuilder.Entity<NftsCollectionMetadataSetModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Data });
            modelBuilder.Entity<NftsCollectionMintSettingsUpdatedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection });
            modelBuilder.Entity<NftsDestroyedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection });
            modelBuilder.Entity<NftsForceCreatedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Owner });
            modelBuilder.Entity<NftsIssuedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Owner });
            modelBuilder.Entity<NftsItemAttributesApprovalAddedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Delegate });
            modelBuilder.Entity<NftsItemBoughtModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Price, c.Seller, c.Buyer });
            modelBuilder.Entity<NftsItemMetadataClearedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item });
            modelBuilder.Entity<NftsItemMetadataSetModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Data });
            modelBuilder.Entity<NftsItemPriceRemovedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item });
            modelBuilder.Entity<NftsItemTransferLockedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item });
            modelBuilder.Entity<NftsItemPriceSetModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Price });
            modelBuilder.Entity<NftsItemPropertiesLockedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Lock_metadata, c.Lock_attributes });
            modelBuilder.Entity<NftsItemTransferUnlockedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item });
            modelBuilder.Entity<NftsNextCollectionIdIncrementedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Next_id });
            modelBuilder.Entity<NftsOwnerChangedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.New_owner });
            //modelBuilder.Entity<NftsOwnershipAcceptanceChangedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Who});
            modelBuilder.Entity<NftsTipSentModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Sender, c.Receiver, c.Amount});
            modelBuilder.Entity<NftsTransferApprovedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.Owner, c.Delegate, c.Deadline});
            modelBuilder.Entity<NftsTransferredModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Collection, c.Item, c.From, c.To });
        }

        protected void OnModelCreatingBalances(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BalancesBalanceSetModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.RootAccount, c.Amount1, c.Amount2 });

            modelBuilder.Entity<BalancesDustLostModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.Amount });

            modelBuilder.Entity<BalancesEndowedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.Amount });

            modelBuilder.Entity<BalancesReservedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.ReservedAmount });

            modelBuilder.Entity<BalancesSlashedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddess, c.Amount });

            modelBuilder.Entity<BalancesTransferModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.From, c.To, c.Amount });

            modelBuilder.Entity<BalancesUnreservedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddess, c.UnreservedAmount });
        }

        protected void OnModelCreatingIdentity(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityIdentityClearedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.Amount });

            modelBuilder.Entity<IdentityIdentityKilledModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.Amount });

            modelBuilder.Entity<IdentityIdentitySetModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress });
        }

        protected void OnModelCreatingSystem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemKilledAccountModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress });

            modelBuilder.Entity<SystemNewAccountModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress });
        }

        protected void OnModelCreatingCrowdloan(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CrowdloanContributedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddess, c.CrowdloanId, c.Amount });
            modelBuilder.Entity<CrowdloanCreatedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.CrowdloanId });
        }

        protected void OnModelCreatingAuctions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuctionsAuctionStartedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AuctionIndex, c.LeasePeriod, c.Ending });
            modelBuilder.Entity<AuctionsAuctionClosedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AuctionIndex });
        }

        protected void OnModelCreatingNominationPools(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NominationPoolsCreatedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Depositor, c.Pool_id });
            modelBuilder.Entity<NominationPoolsBondedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Member, c.Pool_id, c.Bonded, c.Joined });
            modelBuilder.Entity<NominationPoolsPaidOutModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Member, c.Pool_id, c.Payout });
            modelBuilder.Entity<NominationPoolsUnbondedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Member, c.Pool_id, c.Balance, c.Points, c.Era });
            modelBuilder.Entity<NominationPoolsWithdrawnModel>().HasKey(c => new
            {
                c.BlockchainName,
                c.BlockId,
                c.EventId,
                c.ModuleName,
                c.ModuleEvent,
                c.Member,
                c.Pool_id,
                c.Balance,
                c.Points
            });
            modelBuilder.Entity<NominationPoolsDestroyedModel>().HasKey(c => new
            {
                c.BlockchainName,
                c.BlockId,
                c.EventId,
                c.ModuleName,
                c.ModuleEvent,
                c.Pool_id
            });
            modelBuilder.Entity<NominationPoolsMemberRemovedModel>().HasKey(c => new
            {
                c.BlockchainName,
                c.BlockId,
                c.EventId,
                c.ModuleName,
                c.ModuleEvent,
                c.Pool_id,
                c.Member
            });
            modelBuilder.Entity<NominationPoolsPoolCommissionClaimedModel>().HasKey(c => new
            {
                c.BlockchainName,
                c.BlockId,
                c.EventId,
                c.ModuleName,
                c.ModuleEvent,
                c.Pool_id,
                c.Commission
            });
            modelBuilder.Entity<NominationPoolsMinBalanceDeficitAdjustedModel>().HasKey(c => new
            {
                c.BlockchainName,
                c.BlockId,
                c.EventId,
                c.ModuleName,
                c.ModuleEvent,
                c.Pool_id,
                c.Amount
            });
            modelBuilder.Entity<NominationPoolsMinBalanceExcessAdjustedModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Pool_id, c.Amount });
        }

        protected void OnModelCreatingStaking(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StakingEraPaidModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Era_index, c.Validator_payout, c.Remainder });
        }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingNfts(modelBuilder);
            OnModelCreatingBalances(modelBuilder);
            OnModelCreatingIdentity(modelBuilder);
            OnModelCreatingSystem(modelBuilder);
            OnModelCreatingCrowdloan(modelBuilder);
            OnModelCreatingAuctions(modelBuilder);
            OnModelCreatingNominationPools(modelBuilder);
            OnModelCreatingStaking(modelBuilder);

            modelBuilder.Entity<ExtrinsicsInformationModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockNumber, c.ExtrinsicIndex });
            modelBuilder.Entity<EraLifetimeModel>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<SubstrateErrorModel>()
                .HasKey(c => c.Id);
            modelBuilder.Entity<BlockInformationModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockNumber });
            modelBuilder.Entity<EventManagerModel>()
                .HasKey(c => new { c.BlockchainName, c.ModuleName, c.ModuleEvent });
            modelBuilder.Entity<EventsInformationModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId });

            modelBuilder.Entity<TokenPriceModel>().HasKey(c => new { c.BlockchainName, c.Date });

            modelBuilder.Entity<EraStakersModel>().HasKey(c => new { c.BlockchainName, c.EraId, c.ValidatorAddress });

            modelBuilder.Entity<EraStakersNominatorsModel>(table =>
            {
                table.Property<int>("EraStakersId");

                table
                    .HasOne(c => c.EraStakers)
                    .WithMany(c => c.EraNominatorsVote)
                    .HasForeignKey("EraStakersId")
                    .HasPrincipalKey(c => c.Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<EraStakersNominatorsModel>().HasKey("EraStakersId", "NominatorAddress");

            modelBuilder.Entity<SpecVersionModel>().HasKey(c => new { c.BlockchainName, c.SpecVersion });
            modelBuilder.Entity<PalletVersionModel>().HasKey(c => new { c.BlockchainName, c.PalletName, c.PalletVersion });
        }
    }
}
