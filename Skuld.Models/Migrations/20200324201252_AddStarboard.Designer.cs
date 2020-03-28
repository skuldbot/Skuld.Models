﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Skuld.Models;

namespace Skuld.Models.Migrations
{
    [DbContext(typeof(SkuldDbContext))]
    [Migration("20200324201252_AddStarboard")]
    partial class AddStarboard
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Skuld.Models.BlockedAction", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Blockee")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Blocker")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("BlockedActions");
                });

            modelBuilder.Entity("Skuld.Models.CustomCommand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("CustomCommands");
                });

            modelBuilder.Entity("Skuld.Models.DonatorKey", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<Guid>("KeyCode")
                        .HasColumnType("char(36)");

                    b.Property<bool>("Redeemed")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("RedeemedWhen")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Redeemer")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("DonatorKeys");
                });

            modelBuilder.Entity("Skuld.Models.Guild", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("JoinChannel")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("JoinMessage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("JoinRole")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LeaveChannel")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("LeaveMessage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("LevelNotification")
                        .HasColumnType("int");

                    b.Property<ulong>("LevelUpChannel")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("LevelUpMessage")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MoneyIcon")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("MoneyName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("MutedRole")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Prefix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("SelfStarring")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("StarDeleteIfSourceDelete")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("StarEmote")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StarRange1")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StarRange2")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("StarRange3")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ushort>("StarReactAmount")
                        .HasColumnType("smallint unsigned");

                    b.Property<ulong>("StarboardChannel")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Guilds");
                });

            modelBuilder.Entity("Skuld.Models.GuildFeatures", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Experience")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Pinning")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("StackingRoles")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Starboard")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Features");
                });

            modelBuilder.Entity("Skuld.Models.GuildModules", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Accounts")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Actions")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Admin")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Custom")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Fun")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Gambling")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Information")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Lewd")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Search")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Space")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Stats")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Weeb")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Skuld.Models.IAmRole", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LevelRequired")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Price")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("RequiredRoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("IAmRoles");
                });

            modelBuilder.Entity("Skuld.Models.Issue", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Body")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("HasSent")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("IssueChannelMessageId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("SubmitterId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Issues");
                });

            modelBuilder.Entity("Skuld.Models.LevelRewards", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Automatic")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LevelRequired")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("LevelRewards");
                });

            modelBuilder.Entity("Skuld.Models.Pasta", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("Created")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("OwnerId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Pastas");
                });

            modelBuilder.Entity("Skuld.Models.PastaVotes", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("PastaId")
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("Upvote")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("VoterId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("PastaVotes");
                });

            modelBuilder.Entity("Skuld.Models.PersistentRole", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("RoleId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("PersistentRoles");
                });

            modelBuilder.Entity("Skuld.Models.ReminderObject", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("Created")
                        .HasColumnType("bigint unsigned");

                    b.Property<ushort>("LocalId")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("MessageLink")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("Repeats")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("Timeout")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Reminders");
                });

            modelBuilder.Entity("Skuld.Models.Reputation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<ulong>("Repee")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Reper")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Timestamp")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("Reputations");
                });

            modelBuilder.Entity("Skuld.Models.SkuldConfig", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("AltPrefix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("B4DToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DBotsOrgKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("DailyAmount")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("DataDogHost")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ushort?>("DataDogPort")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("DiscordGGKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DiscordToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GithubClientPassword")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GithubClientUsername")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<long>("GithubRepository")
                        .HasColumnType("bigint");

                    b.Property<string>("GoogleAPI")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("GoogleCx")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImgurClientID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("ImgurClientSecret")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("IsDevelopmentBuild")
                        .HasColumnType("tinyint(1)");

                    b.Property<ulong>("IssueChannel")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("MaxStreak")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("NASAApiKey")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("PinboardDateLimit")
                        .HasColumnType("int");

                    b.Property<int>("PinboardThreshold")
                        .HasColumnType("int");

                    b.Property<string>("Prefix")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("STANDSToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("STANDSUid")
                        .HasColumnType("int");

                    b.Property<ushort>("Shards")
                        .HasColumnType("smallint unsigned");

                    b.Property<ulong>("StreakLimitDays")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("TwitchClientID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("TwitchToken")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<float>("VoiceExpDeterminate")
                        .HasColumnType("float");

                    b.Property<ulong>("VoiceExpMaxGrant")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("VoiceExpMinMinutes")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("WebsocketHost")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ushort>("WebsocketPort")
                        .HasColumnType("smallint unsigned");

                    b.Property<bool>("WebsocketSecure")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Configurations");
                });

            modelBuilder.Entity("Skuld.Models.StarboardVote", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("ChannelId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("MessageAuthorId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("MessageId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("StarboardMessageId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("VoterId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("StarboardVotes");
                });

            modelBuilder.Entity("Skuld.Models.User", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("AvatarUrl")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Background")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("BanReason")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("Flags")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Language")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("LastDaily")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Money")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Pats")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Patted")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("PrestigeLevel")
                        .HasColumnType("bigint unsigned");

                    b.Property<bool>("RecurringBlock")
                        .HasColumnType("tinyint(1)");

                    b.Property<uint>("Streak")
                        .HasColumnType("int unsigned");

                    b.Property<string>("TimeZone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("UnlockedCustBG")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Skuld.Models.UserCommandUsage", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Command")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<ulong>("Usage")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("UserCommandUsage");
                });

            modelBuilder.Entity("Skuld.Models.UserExperience", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LastGranted")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Level")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("TotalXP")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("XP")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("UserXp");
                });

            modelBuilder.Entity("Skuld.Models.WeeklyPot", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("Amount")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("GuildId")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("LastGranted")
                        .HasColumnType("bigint unsigned");

                    b.Property<ulong>("UserId")
                        .HasColumnType("bigint unsigned");

                    b.HasKey("Id");

                    b.ToTable("GuildWeeklyPots");
                });
#pragma warning restore 612, 618
        }
    }
}
