﻿// <auto-generated />
using System;
using Grasshoppers.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Grasshoppers.Migrations
{
    [DbContext(typeof(GrasshoppersContext))]
    partial class GrasshoppersContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Grasshoppers.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<DateTime>("LastTimeOnline");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("Grasshoppers.Models.CharacterResultEntry", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameSessionId");

                    b.Property<int?>("CapturedFlags");

                    b.Property<int?>("StunnedPlayers");

                    b.Property<int?>("Team");

                    b.HasKey("PlayerId", "GameSessionId");

                    b.HasIndex("GameSessionId");

                    b.ToTable("CharactersResults");
                });

            modelBuilder.Entity("Grasshoppers.Models.GameSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDateTime");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<int>("MissionId");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("Grasshoppers.Models.InventoryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemId");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("Grasshoppers.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Rarity")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Grasshoppers.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RequiredPlayersNumber");

                    b.Property<int?>("TargetCapturedFlags");

                    b.Property<int?>("TargetScore");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("Grasshoppers.Models.CharacterResultEntry", b =>
                {
                    b.HasOne("Grasshoppers.Models.GameSession", "GameSession")
                        .WithMany("ParticipatorsResults")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Grasshoppers.Models.Character", "Character")
                        .WithMany("Results")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grasshoppers.Models.GameSession", b =>
                {
                    b.HasOne("Grasshoppers.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grasshoppers.Models.InventoryEntry", b =>
                {
                    b.HasOne("Grasshoppers.Models.Item", "Item")
                        .WithMany("InventoryEntries")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Grasshoppers.Models.Character", "Owner")
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
