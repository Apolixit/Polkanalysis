using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Auctions;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Crowdloan;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Price;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Staking;
using Polkanalysis.Infrastructure.Database.Contracts.Model.Version;

namespace Polkanalysis.Infrastructure.Database
{
    public class SubstrateDbContext : DbContext
    {
        public SubstrateDbContext(DbContextOptions options) : base(options) { }

        #region Balances
        public DbSet<BalancesBalanceSetModel> EventBalancesBalanceSet { get; set; }
        public DbSet<BalancesDustLostModel> EventBalancesDustLost  { get; set; }
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

        #region Historical data price
        public DbSet<TokenPriceModel> TokenPrices { get; set; }
        #endregion

        #region Staking
        public DbSet<EraStakersModel> EraStakersModels { get; set; }
        #endregion

        #region Crowdloan
        public DbSet<CrowloanContributedModel> EventCrowdloanContributed { get; set; }
        public DbSet<CrowloanCreatedModel> EventCrowdloanCreated { get; set; }
        #endregion

        #region Auctions
        public DbSet<AuctionStartedModel> EventAuctionStarted { get; set; }
        public DbSet<AuctionClosedModel> EventAuctionClosed { get; set; }
        #endregion

        #region
        public DbSet<SpecVersionModel> SpecVersionModels { get; set; }
        public DbSet<PalletVersionModel> PalletVersionModels { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BalancesBalanceSetModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.RootAccount, c.Amount1, c.Amount2 });

            modelBuilder.Entity<BalancesDustLostModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.Amount });

            modelBuilder.Entity<BalancesEndowedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.Amount });

            modelBuilder.Entity<BalancesReservedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.ReservedAmount });

            modelBuilder.Entity<BalancesSlashedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.Amount });

            modelBuilder.Entity<BalancesTransferModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.From, c.To, c.Amount });

            modelBuilder.Entity<BalancesUnreservedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.UnreservedAmount });


            modelBuilder.Entity<IdentityIdentityClearedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.Amount });

            modelBuilder.Entity<IdentityIdentityKilledModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.Amount });

            modelBuilder.Entity<IdentityIdentitySetModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account });


            modelBuilder.Entity<SystemKilledAccountModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account });

            modelBuilder.Entity<SystemNewAccountModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account });

            modelBuilder.Entity<CrowloanContributedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.Account, c.CrowdloanId, c.Amount });
            modelBuilder.Entity<CrowloanCreatedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.CrowdloanId });

            modelBuilder.Entity<AuctionStartedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AuctionIndex, c.LeasePeriod, c.Ending });
            modelBuilder.Entity<AuctionClosedModel>()
                .HasKey(c => new { c.BlockchainName, c.BlockId, c.EventId, c.ModuleName, c.ModuleEvent, c.AuctionIndex });

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

            modelBuilder.Entity<SpecVersionModel>().HasKey(c => new { c.BlockchainName, c.SpecVersion});
            modelBuilder.Entity<PalletVersionModel>().HasKey(c => new { c.BlockchainName, c.PalletName, c.PalletVersion});
        }
    }
}
