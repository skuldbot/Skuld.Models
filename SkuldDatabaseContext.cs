using Discord;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skuld.Core.Models
{
    public class SkuldDatabaseContext : DbContext
    {
        public SkuldDatabaseContext(DbContextOptions<SkuldDatabaseContext> options) : base(options)
        {
        }

        public DbSet<BlockedAction> BlockedActions { get; set; }
        public DbSet<SkuldConfig> Configurations { get; set; }
        public DbSet<CustomCommand> CustomCommands { get; set; }
        public DbSet<GuildFeatures> Features { get; set; }
        public DbSet<IAmRole> IAmRoles { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<LevelRewards> LevelRewards { get; set; }
        public DbSet<GuildModules> Modules { get; set; }
        public DbSet<Guild> Guilds { get; set; }
        public DbSet<Pasta> Pastas { get; set; }
        public DbSet<PastaVotes> PastaVotes { get; set; }
        public DbSet<PersistentRole> PersistentRoles { get; set; }
        public DbSet<Reputation> Reputations { get; set; }
        public DbSet<UserCommandUsage> UserCommandUsage { get; set; }
        public DbSet<UserExperience> UserXp { get; set; }
        public DbSet<User> Users { get; set; }

        public bool IsConnected
        {
            get
            {
                return Database.CanConnect();
            }
        }

        public async Task DropGuildAsync(ulong guildId)
        {
            Guilds.Remove(await Guilds.AsQueryable().FirstAsync(x => x.Id == guildId).ConfigureAwait(false));

            Modules.Remove(await Modules.AsQueryable().FirstAsync(x => x.Id == guildId).ConfigureAwait(false));
            IAmRoles.RemoveRange(IAmRoles.AsQueryable().Where(x => x.GuildId == guildId));
            Features.Remove(await Features.AsQueryable().FirstAsync(x => x.Id == guildId).ConfigureAwait(false));
            CustomCommands.RemoveRange(CustomCommands.AsQueryable().Where(x => x.GuildId == guildId));
            UserXp.RemoveRange(UserXp.AsQueryable().Where(x => x.GuildId == guildId));

            await SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task DropUserAsync(ulong userId)
        {
            Users.Remove(await Users.AsQueryable().FirstAsync(x => x.Id == userId).ConfigureAwait(false));
            Pastas.RemoveRange(Pastas.AsQueryable().Where(x => x.OwnerId == userId));
            UserCommandUsage.RemoveRange(UserCommandUsage.AsQueryable().Where(x => x.UserId == userId));
            Reputations.RemoveRange(Reputations.AsQueryable().Where(x => x.Repee == userId || x.Reper == userId));
            UserXp.RemoveRange(UserXp.AsQueryable().Where(x => x.UserId == userId));

            await SaveChangesAsync().ConfigureAwait(false);
        }

        /// <summary>
        /// Insert and returns user, else null if already exists
        /// </summary>
        /// <param name="user">Discord User to insert</param>
        /// <returns>User object or null if exists</returns>
        public async Task<User> InsertOrGetUserAsync(IUser user)
        {
            User usr = Users.FirstOrDefault(x => x.Id == user.Id);

            if(usr == null)
            {
                return await InsertOrGetUserAsync(new User
                {
                    AvatarUrl = new Uri(user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl()),
                    Id = user.Id,
                    Username = user.Username
                }).ConfigureAwait(false);
            }

            return usr;
        }

        /// <summary>
        /// Insert and returns user, else null if already exists
        /// </summary>
        /// <param name="user">User Class to insert</param>
        /// <returns>User object or null if exists</returns>
        public async Task<User> InsertOrGetUserAsync(User user)
        {
            if (!Users.Any(x => x.Id == user.Id))
            {
                Users.Add(user);

                await SaveChangesAsync().ConfigureAwait(false);

                return Users.FirstOrDefault(x => x == user);
            }

            return null;
        }

        public async Task<Guild> InsertGuildAsync(Guild guild)
        {
            Guilds.Add(guild);
            Features.Add(new GuildFeatures
            {
                Id = guild.Id
            });
            Modules.Add(new GuildModules
            {
                Id = guild.Id
            });

            await SaveChangesAsync().ConfigureAwait(false);

            return Guilds.FirstOrDefault(x => x == guild);
        }

        public long GetPastaKarma(ulong UserId)
        {
            long returnkarma = 0;

            if (Pastas != null && Pastas.Any())
            {
                var ownedpastas = Pastas.AsQueryable().Where(x => x.OwnerId == UserId);
                var pastaVotes = new List<PastaVotes>();

                foreach (var pasta in ownedpastas)
                {
                    var p = PastaVotes.FirstOrDefault(x => x.PastaId == pasta.Id);

                    if (p != null)
                        pastaVotes.Add(p);
                }

                if (pastaVotes != null)
                {
                    long upkarma = 0;
                    long downkarma = 0;
                    foreach (var pasta in pastaVotes)
                    {
                        if (pasta.Upvote)
                            upkarma += 1;
                        else
                            downkarma += 1;
                    }
                    returnkarma = upkarma - (downkarma / 5);
                }
            }

            return returnkarma;
        }

        public IReadOnlyList<UserExperience> GetOrderedGlobalExperienceLeaderboard()
        {
            if (UserXp.Any())
            {
                List<UserExperience> experiences = new List<UserExperience>();
                List<UserExperience> entries = new List<UserExperience>();

                foreach (var xp in UserXp)
                {
                    experiences.Add(xp);
                }

                foreach (var xp in experiences)
                {
                    if (!entries.Any(x => x.UserId == xp.UserId))
                    {
                        var uxp = new UserExperience
                        {
                            UserId = xp.UserId,
                            XP = (ulong)experiences.Where(x => x.UserId == xp.UserId).Sum(x => (float)x.XP),
                            TotalXP = (ulong)experiences.Where(x => x.UserId == xp.UserId).Sum(x => (float)x.TotalXP)
                        };
                        uxp.Level = DatabaseUtilities.GetLevelFromTotalXP(uxp.TotalXP, 1.618);

                        entries.Add(uxp);
                    }
                }

                return entries.OrderByDescending(x => x.TotalXP).ToList().AsReadOnly();
            }
            else
            {
                return null;
            }
        }

        public IReadOnlyList<User> GetOrderedGlobalMoneyLeaderboard()
        {
            if (Users.Any())
            {
                List<User> entries = new List<User>();

                foreach (var user in Users)
                {
                    if (!entries.Any(x => x.Id == user.Id))
                    {
                        entries.Add(user);
                    }
                }

                return entries.OrderByDescending(x => x.Money).ToList().AsReadOnly();
            }
            else
            {
                return null;
            }
        }

        public async Task<IReadOnlyList<UserExperience>> GetOrderedGuildExperienceLeaderboardAsync(IGuild guild)
        {
            if (UserXp.Any())
            {
                List<UserExperience> experiences = new List<UserExperience>();
                List<UserExperience> entries = new List<UserExperience>();

                foreach (var xp in UserXp)
                {
                    if (await guild.GetUserAsync(xp.UserId).ConfigureAwait(false) != null)
                    {
                        experiences.Add(xp);
                    }
                }

                foreach (var xp in experiences)
                {
                    if (!entries.Any(x => x.UserId == xp.UserId))
                    {
                        var uxp = new UserExperience
                        {
                            UserId = xp.UserId,
                            XP = (ulong)experiences.Where(x => x.UserId == xp.UserId).Sum(x => (float)x.XP),
                            TotalXP = (ulong)experiences.Where(x => x.UserId == xp.UserId).Sum(x => (float)x.TotalXP),
                            Level = xp.Level
                        };

                        entries.Add(uxp);
                    }
                }

                return entries.OrderByDescending(x => x.TotalXP).ToList().AsReadOnly();
            }
            else
            {
                return null;
            }
        }

        public async Task<IReadOnlyList<User>> GetOrderedGuildMoneyLeaderboardAsync(IGuild guild)
        {
            if (Users.Any())
            {
                List<User> entries = new List<User>();

                foreach (var user in Users)
                {
                    if (await guild.GetUserAsync(user.Id).ConfigureAwait(false) != null)
                    {
                        if (!entries.Any(x => x.Id == user.Id))
                        {
                            entries.Add(user);
                        }
                    }
                }

                return entries.OrderByDescending(x => x.Money).ToList().AsReadOnly();
            }
            else
            {
                return null;
            }
        }

        public async Task<Guild> GetOrInsertGuildAsync(IGuild guild, string Prefix = "sk!", string MoneyName = "Diamonds", string MoneyIcon = "💠")
        {
            var gld = Guilds.FirstOrDefault(x => x.Id == guild.Id);

            if (gld == null)
            {
                gld = new Guild
                {
                    Id = guild.Id,
                    Name = guild.Name,
                    MoneyName = MoneyName,
                    MoneyIcon = MoneyIcon,
                    Prefix = Prefix,
                };

                Guilds.Add(gld);

                await SaveChangesAsync().ConfigureAwait(false);
            }

            return gld;
        }

        public async Task<User> GetOrInsertUserAsync(IUser user)
        {
            var usr = Users.FirstOrDefault(x => x.Id == user.Id);

            if (usr == null)
                return await InsertOrGetUserAsync(user).ConfigureAwait(false);

            return usr;
        }

        public async Task<SkuldConfig> GetOrInsertConfigAsync(string configId = null)
        {
            if (configId == null)
                return await Configurations.AsQueryable().FirstOrDefaultAsync().ConfigureAwait(false);
            else
                return await Configurations.AsQueryable().FirstOrDefaultAsync(x => x.Id == configId).ConfigureAwait(false);
        }
    }
}