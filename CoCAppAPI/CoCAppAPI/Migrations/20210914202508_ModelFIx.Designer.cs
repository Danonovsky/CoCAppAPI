﻿// <auto-generated />
using System;
using DbLibrary.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CoCAppAPI.Migrations
{
    [DbContext(typeof(CoCDbContext))]
    [Migration("20210914202508_ModelFIx")]
    partial class ModelFIx
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DbLibrary.Models.Character.Character", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("DbLibrary.Models.Characteristic.Characteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Advancement")
                        .HasColumnType("int");

                    b.Property<Guid>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DefaultCharacteristicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("DefaultCharacteristicId");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("DbLibrary.Models.Characteristic.DefaultCharacteristic", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DefaultCharacteristics");
                });

            modelBuilder.Entity("DbLibrary.Models.Game.Game", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("DbLibrary.Models.Game.GamePlayer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GameId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("GameId");

                    b.HasIndex("UserId");

                    b.ToTable("GamePlayers");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemAttributeValue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemTypeAttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("ItemTypeAttributeId");

                    b.ToTable("ItemAttributeValues");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ItemTypes");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemTypeAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ItemTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ItemTypeId");

                    b.ToTable("ItemTypeAttributes");
                });

            modelBuilder.Entity("DbLibrary.Models.Skill.DefaultSkill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("DefaultSkills");
                });

            modelBuilder.Entity("DbLibrary.Models.Skill.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Advancement")
                        .HasColumnType("int");

                    b.Property<Guid?>("CharacterId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DefaultSkillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("DefaultSkillId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("DbLibrary.Models.User.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DbLibrary.Models.Characteristic.Characteristic", b =>
                {
                    b.HasOne("DbLibrary.Models.Character.Character", "Character")
                        .WithMany("Characteristics")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DbLibrary.Models.Characteristic.DefaultCharacteristic", "DefaultCharacteristic")
                        .WithMany("Characteristics")
                        .HasForeignKey("DefaultCharacteristicId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("DefaultCharacteristic");
                });

            modelBuilder.Entity("DbLibrary.Models.Game.Game", b =>
                {
                    b.HasOne("DbLibrary.Models.User.User", "User")
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbLibrary.Models.Game.GamePlayer", b =>
                {
                    b.HasOne("DbLibrary.Models.Character.Character", "Character")
                        .WithMany("GamePlayers")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DbLibrary.Models.Game.Game", "Game")
                        .WithMany("GamePlayers")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DbLibrary.Models.User.User", "User")
                        .WithMany("GamePlayers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Character");

                    b.Navigation("Game");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.Item", b =>
                {
                    b.HasOne("DbLibrary.Models.Item.ItemType", "ItemType")
                        .WithMany("Items")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemAttributeValue", b =>
                {
                    b.HasOne("DbLibrary.Models.Item.Item", "Item")
                        .WithMany("ItemAttributeValues")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("DbLibrary.Models.Item.ItemTypeAttribute", "ItemTypeAttribute")
                        .WithMany("ItemAttributeValues")
                        .HasForeignKey("ItemTypeAttributeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("ItemTypeAttribute");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemTypeAttribute", b =>
                {
                    b.HasOne("DbLibrary.Models.Item.ItemType", "ItemType")
                        .WithMany("ItemTypeAttributes")
                        .HasForeignKey("ItemTypeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ItemType");
                });

            modelBuilder.Entity("DbLibrary.Models.Skill.Skill", b =>
                {
                    b.HasOne("DbLibrary.Models.Character.Character", "Character")
                        .WithMany("Skills")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("DbLibrary.Models.Skill.DefaultSkill", "DefaultSkill")
                        .WithMany("Skills")
                        .HasForeignKey("DefaultSkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Character");

                    b.Navigation("DefaultSkill");
                });

            modelBuilder.Entity("DbLibrary.Models.Character.Character", b =>
                {
                    b.Navigation("Characteristics");

                    b.Navigation("GamePlayers");

                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DbLibrary.Models.Characteristic.DefaultCharacteristic", b =>
                {
                    b.Navigation("Characteristics");
                });

            modelBuilder.Entity("DbLibrary.Models.Game.Game", b =>
                {
                    b.Navigation("GamePlayers");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.Item", b =>
                {
                    b.Navigation("ItemAttributeValues");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemType", b =>
                {
                    b.Navigation("Items");

                    b.Navigation("ItemTypeAttributes");
                });

            modelBuilder.Entity("DbLibrary.Models.Item.ItemTypeAttribute", b =>
                {
                    b.Navigation("ItemAttributeValues");
                });

            modelBuilder.Entity("DbLibrary.Models.Skill.DefaultSkill", b =>
                {
                    b.Navigation("Skills");
                });

            modelBuilder.Entity("DbLibrary.Models.User.User", b =>
                {
                    b.Navigation("GamePlayers");

                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
