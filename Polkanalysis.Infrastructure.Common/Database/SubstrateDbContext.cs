using Microsoft.EntityFrameworkCore;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Balances;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.Identity;
using Polkanalysis.Infrastructure.Contracts.Database.Model.Events.System;

namespace Polkanalysis.Infrastructure.Common.Database
{
    public class SubstrateDbContext : DbContext
    {
        public SubstrateDbContext(DbContextOptions options) : base(options) { }

        #region Balances
        public DbSet<BalancesBalanceSetModel> EventBalancesBalanceSet => Set<BalancesBalanceSetModel>();
        public DbSet<BalancesDustLostModel> EventBalancesDustLost => Set<BalancesDustLostModel>();
        public DbSet<BalancesEndowedModel> EventBalancesEndowed => Set<BalancesEndowedModel>();
        public DbSet<BalancesReservedModel> EventBalancesReserved => Set<BalancesReservedModel>();
        public DbSet<BalancesSlashedModel> EventBalancesSlashed => Set<BalancesSlashedModel>();
        public DbSet<BalancesTransferModel> EventBalancesTransfer => Set<BalancesTransferModel>();
        public DbSet<BalancesUnreservedModel> EventBalancesUnreserved => Set<BalancesUnreservedModel>();
        #endregion

        #region Identity
        public DbSet<IdentityIdentityClearedModel> EventIdentityIdentityCleared => Set<IdentityIdentityClearedModel>();
        public DbSet<IdentityIdentityKilledModel> EventIdentityIdentityKilled => Set<IdentityIdentityKilledModel>();
        public DbSet<IdentityIdentitySetModel> EventIdentityIdentitySet => Set<IdentityIdentitySetModel>();
        #endregion

        #region System
        public DbSet<SystemKilledAccountModel> EventSystemKilledAccount => Set<SystemKilledAccountModel>();
        public DbSet<SystemNewAccountModel> EventSystemNewAccount => Set<SystemNewAccountModel>();
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
        }
    }
}
