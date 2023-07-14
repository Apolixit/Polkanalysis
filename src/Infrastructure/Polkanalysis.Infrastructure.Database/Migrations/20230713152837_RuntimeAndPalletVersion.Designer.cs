﻿// <auto-generated />
using System;
using System.Numerics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Polkanalysis.Infrastructure.Database;

#nullable disable

namespace Polkanalysis.Infrastructure.Common.Migrations
{
    [DbContext(typeof(SubstrateDbContext))]
    [Migration("20230713152837_RuntimeAndPalletVersion")]
    partial class RuntimeAndPalletVersion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesBalanceSetModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("RootAccount")
                        .HasColumnType("text");

                    b.Property<double>("Amount1")
                        .HasColumnType("double precision");

                    b.Property<double>("Amount2")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "RootAccount", "Amount1", "Amount2");

                    b.ToTable("EventBalancesBalanceSet");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesDustLostModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "Amount");

                    b.ToTable("EventBalancesDustLost");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesEndowedModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "Amount");

                    b.ToTable("EventBalancesEndowed");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesReservedModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("ReservedAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "ReservedAmount");

                    b.ToTable("EventBalancesReserved");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesSlashedModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "Amount");

                    b.ToTable("EventBalancesSlashed");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesTransferModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("From")
                        .HasColumnType("text");

                    b.Property<string>("To")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "From", "To", "Amount");

                    b.ToTable("EventBalancesTransfer");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Balances.BalancesUnreservedModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("UnreservedAmount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "UnreservedAmount");

                    b.ToTable("EventBalancesUnreserved");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity.IdentityIdentityClearedModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "Amount");

                    b.ToTable("EventIdentityIdentityCleared");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity.IdentityIdentityKilledModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account", "Amount");

                    b.ToTable("EventIdentityIdentityKilled");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.Identity.IdentityIdentitySetModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account");

                    b.ToTable("EventIdentityIdentitySet");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System.SystemKilledAccountModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account");

                    b.ToTable("EventSystemKilledAccount");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Events.System.SystemNewAccountModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("BlockId")
                        .HasColumnType("integer");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<string>("ModuleName")
                        .HasColumnType("text");

                    b.Property<string>("ModuleEvent")
                        .HasColumnType("text");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<DateTime>("BlockDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("BlockchainName", "BlockId", "EventId", "ModuleName", "ModuleEvent", "Account");

                    b.ToTable("EventSystemNewAccount");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Price.TokenPriceModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("BlockchainName", "Date");

                    b.ToTable("TokenPrices");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Staking.EraStakersModel", b =>
                {
                    b.Property<int>("EraStakersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EraStakersId"));

                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<int>("EraId")
                        .HasColumnType("integer");

                    b.Property<string>("ValidatorAddress")
                        .HasColumnType("text");

                    b.Property<BigInteger>("OwnStake")
                        .HasColumnType("numeric");

                    b.Property<BigInteger>("TotalStake")
                        .HasColumnType("numeric");

                    b.HasKey("EraStakersId", "BlockchainName", "EraId", "ValidatorAddress");

                    b.ToTable("EraStakersModels");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Staking.EraStakersNominatorsModel", b =>
                {
                    b.Property<int>("EraStakersId")
                        .HasColumnType("integer");

                    b.Property<string>("NominatorAddress")
                        .HasColumnType("text");

                    b.Property<BigInteger>("ValueStake")
                        .HasColumnType("numeric");

                    b.HasKey("EraStakersId", "NominatorAddress");

                    b.ToTable("EraStakersNominatorsModel");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Version.PalletVersionModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<string>("PalletName")
                        .HasColumnType("text");

                    b.Property<int>("PalletVersion")
                        .HasColumnType("integer");

                    b.Property<long?>("BlockEnd")
                        .HasColumnType("bigint");

                    b.Property<long>("BlockStart")
                        .HasColumnType("bigint");

                    b.Property<int>("PalletId")
                        .HasColumnType("integer");

                    b.HasKey("BlockchainName", "PalletName", "PalletVersion");

                    b.ToTable("PalletVersionModels");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Version.SpecVersionModel", b =>
                {
                    b.Property<string>("BlockchainName")
                        .HasColumnType("text");

                    b.Property<long>("SpecVersion")
                        .HasColumnType("bigint");

                    b.Property<long?>("BlockEnd")
                        .HasColumnType("bigint");

                    b.Property<long>("BlockStart")
                        .HasColumnType("bigint");

                    b.Property<string>("Metadata")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("BlockchainName", "SpecVersion");

                    b.ToTable("SpecVersionModels");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Staking.EraStakersNominatorsModel", b =>
                {
                    b.HasOne("Polkanalysis.Infrastructure.Database.Contracts.Model.Staking.EraStakersModel", "EraStakers")
                        .WithMany("EraNominatorsVote")
                        .HasForeignKey("EraStakersId")
                        .HasPrincipalKey("EraStakersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EraStakers");
                });

            modelBuilder.Entity("Polkanalysis.Infrastructure.Database.Contracts.Model.Staking.EraStakersModel", b =>
                {
                    b.Navigation("EraNominatorsVote");
                });
#pragma warning restore 612, 618
        }
    }
}
