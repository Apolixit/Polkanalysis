using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Blocks;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Errors;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExtrinsicsInformationModel>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<EraLifetimeModel>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<SubstrateErrorModel>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<BlockInformationModel>()
                .HasKey(c => c.BlockNumber);

            modelBuilder.Entity<EventManagerModel>()
                .HasKey(c => new { c.BlockchainName, c.ModuleName, c.ModuleEvent });

            modelBuilder.Entity<EventsInformationModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId });

            #region Balances

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
            #endregion

            #region Identity
            modelBuilder.Entity<IdentityIdentityClearedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.Amount });

            modelBuilder.Entity<IdentityIdentityKilledModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress, c.Amount });

            modelBuilder.Entity<IdentityIdentitySetModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress });
            #endregion

            #region System
            modelBuilder.Entity<SystemKilledAccountModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress });

            modelBuilder.Entity<SystemNewAccountModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddress });
            #endregion

            #region Crowdloan
            modelBuilder.Entity<CrowdloanContributedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AccountAddess, c.CrowdloanId, c.Amount });
            modelBuilder.Entity<CrowdloanCreatedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.CrowdloanId });
            #endregion

            #region Auctions
            modelBuilder.Entity<AuctionsAuctionStartedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AuctionIndex, c.LeasePeriod, c.Ending });
            modelBuilder.Entity<AuctionsAuctionClosedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AuctionIndex });
            #endregion

            #region Nominations Pool
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
            #endregion

            #region Staking
            modelBuilder.Entity<StakingEraPaidModel>().HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Era_index, c.Validator_payout, c.Remainder });
            #endregion

            modelBuilder.Entity<TokenPriceModel>().HasKey(c => new { c.BlockchainName, c.Date });

            modelBuilder.Entity<EraStakersModel>().HasKey(c => new { c.EraStakersId, c.BlockchainName, c.EraId, c.ValidatorAddress });
            modelBuilder.Entity<EraStakersModel>().Property(c => c.EraStakersId).ValueGeneratedOnAdd();

            modelBuilder.Entity<EraStakersNominatorsModel>(table =>
            {
                table.Property<int>("EraStakersId");

                table
                    .HasOne(c => c.EraStakers)
                    .WithMany(c => c.EraNominatorsVote)
                    .HasForeignKey("EraStakersId")
                    .HasPrincipalKey(c => c.EraStakersId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<EraStakersNominatorsModel>().HasKey("EraStakersId", "NominatorAddress");

            modelBuilder.Entity<SpecVersionModel>().HasKey(c => new { c.BlockchainName, c.SpecVersion });
            modelBuilder.Entity<PalletVersionModel>().HasKey(c => new { c.BlockchainName, c.PalletName, c.PalletVersion });
        }
    }
}
