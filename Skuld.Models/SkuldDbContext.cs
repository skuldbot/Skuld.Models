using Discord;
using Microsoft.EntityFrameworkCore;
using Skuld.Models.ThePlace;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skuld.Models
{
	public class SkuldDbContext : DbContext
	{
		public SkuldDbContext(DbContextOptions<SkuldDbContext> options)
			: base(options)
		{
		}

		public DbSet<BlockedAction> BlockedActions { get; set; }
		public DbSet<SkuldConfig> Configurations { get; set; }
		public DbSet<CustomCommand> CustomCommands { get; set; }
		public DbSet<DonatorKey> DonatorKeys { get; set; }
		public DbSet<GuildFeatures> Features { get; set; }
		public DbSet<IAmRole> IAmRoles { get; set; }
		public DbSet<Issue> Issues { get; set; }
		public DbSet<LevelRewards> LevelRewards { get; set; }
		public DbSet<GuildModules> Modules { get; set; }
		public DbSet<Guild> Guilds { get; set; }
		public DbSet<WeeklyPot> GuildWeeklyPots { get; set; }
		public DbSet<ReminderObject> Reminders { get; set; }
		public DbSet<Pasta> Pastas { get; set; }
		public DbSet<PastaVotes> PastaVotes { get; set; }
		public DbSet<PersistentRole> PersistentRoles { get; set; }
		public DbSet<StarboardConfigurable> StarboardBlacklist { get; set; }
		public DbSet<StarboardConfigurable> StarboardWhitelist { get; set; }
		public DbSet<StarboardVote> StarboardVotes { get; set; }
		public DbSet<Reputation> Reputations { get; set; }
		public DbSet<UserCommandUsage> UserCommandUsage { get; set; }
		public DbSet<UserExperience> UserXp { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<PixelHistory> PlacePixelHistory { get; set; }
		public DbSet<PixelData> PlacePixelData { get; set; }
		public DbSet<GuildTwitterAccounts> TwitterFollows { get; set; }
		public DbSet<TwitchFollow> TwitchFollows { get; set; }

		public bool IsConnected
		{
			get
			{
				return Database.CanConnect();
			}
		}

		public async Task DropGuildAsync(ulong guildId)
		{
			Guilds.Remove(await Guilds.AsQueryable()
				.FirstAsync(x => x.Id == guildId).ConfigureAwait(false));

			Modules.Remove(await Modules.AsQueryable()
				.FirstAsync(x => x.Id == guildId).ConfigureAwait(false));

			IAmRoles.RemoveRange(IAmRoles.AsQueryable()
				.Where(x => x.GuildId == guildId));

			Features.Remove(await Features.AsQueryable()
				.FirstAsync(x => x.Id == guildId).ConfigureAwait(false));

			CustomCommands.RemoveRange(
				CustomCommands.AsQueryable().Where(x => x.GuildId == guildId)
			);

			UserXp.RemoveRange(
				UserXp.AsQueryable().Where(x => x.GuildId == guildId)
			);

			TwitterFollows.RemoveRange(
				TwitterFollows.AsQueryable().Where(x => x.GuildId == guildId)
			);

			TwitchFollows.RemoveRange(
				TwitchFollows.AsQueryable().Where(x => x.GuildId == guildId)
			);

			StarboardBlacklist.RemoveRange(
				StarboardBlacklist.AsQueryable().Where(x => x.GuildId == guildId)
			);

			StarboardWhitelist.RemoveRange(
				StarboardWhitelist.AsQueryable().Where(x => x.GuildId == guildId)
			);

			StarboardVotes.RemoveRange(
				StarboardVotes.AsQueryable().Where(x => x.GuildId == guildId)
			);

			GuildWeeklyPots.RemoveRange(
				GuildWeeklyPots.AsQueryable().Where(x => x.GuildId == guildId)
			);
		}

		public async Task DropUserAsync(ulong userId)
		{
			Users.Remove(await Users.AsQueryable()
				.FirstAsync(x => x.Id == userId).ConfigureAwait(false));

			Pastas.RemoveRange(Pastas.AsQueryable()
				.Where(x => x.OwnerId == userId));

			UserCommandUsage.RemoveRange(UserCommandUsage.AsQueryable()
				.Where(x => x.UserId == userId));

			Reputations.RemoveRange(Reputations.AsQueryable()
				.Where(x => x.Repee == userId || x.Reper == userId));

			UserXp.RemoveRange(UserXp.AsQueryable()
				.Where(x => x.UserId == userId));

			StarboardVotes.RemoveRange(
				StarboardVotes.AsQueryable().Where(x => x.VoterId == userId)
			);

			GuildWeeklyPots.RemoveRange(
				GuildWeeklyPots.AsQueryable().Where(x => x.UserId == userId)
			);

			PlacePixelHistory.RemoveRange(
				PlacePixelHistory.AsQueryable().Where(x => x.ModifierId == userId)
			);
		}

		/// <summary>
		/// Insert and returns user, else null if already exists
		/// </summary>
		/// <param name="user">Discord User to insert</param>
		/// <returns>User object or null if unsupported user</returns>
		public async Task<User> InsertOrGetUserAsync(IUser user)
		{
			if (user.IsBot ||
				user.IsWebhook ||
				user.Discriminator == null || user.Discriminator == "0000") return null;

			User usr = Users.Find(user.Id);

			if (usr == null)
			{
				return await InsertOrGetUserAsync(new User
				{
					AvatarUrl =
						user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl(),
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

				return Users.Find(user.Id);
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

		public async Task<Guild> InsertOrGetGuildAsync(IGuild guild,
			string Prefix = "sk!",
			string MoneyName = "Woolong",
			string MoneyIcon = "₩")
		{
			var gld = Guilds.Find(guild.Id);

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

				Features.Add(new GuildFeatures
				{
					Id = guild.Id
				});

				Modules.Add(new GuildModules
				{
					Id = guild.Id
				});

				await SaveChangesAsync().ConfigureAwait(false);
			}

			return gld;
		}

		public async Task<SkuldConfig> InsertOrGetConfigAsync(
			string configId = null
		)
		{
			if (configId == null)
				return await Configurations.AsQueryable().FirstOrDefaultAsync().ConfigureAwait(false);
			else
				return await Configurations.AsQueryable().FirstOrDefaultAsync(x => x.Id == configId).ConfigureAwait(false);
		}

		public IReadOnlyList<UserExperience>
			GetOrderedGlobalExperienceLeaderboard()
		{
			if (UserXp.AsNoTracking().Any())
			{
				var experiences = UserXp.AsNoTracking().Where(x => x.GuildId == 0);

				return experiences.OrderByDescending(x => x.TotalXP)
					.ToList().AsReadOnly();
			}
			else
			{
				return null;
			}
		}

		public IReadOnlyList<User> GetOrderedGlobalMoneyLeaderboard()
		{
			if (Users.AsNoTracking().Any())
			{
				List<User> entries = new();

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

		public async Task<IReadOnlyList<UserExperience>>
			GetOrderedGuildExperienceLeaderboardAsync(IGuild guild)
			=> await GetOrderedGuildExperienceLeaderboardAsync(guild.Id);

		public async Task<IReadOnlyList<UserExperience>>
			GetOrderedGuildExperienceLeaderboardAsync(ulong guildId)
		{
			if (UserXp.AsNoTracking().Any())
			{
				List<UserExperience> experiences = UserXp.AsNoTracking().Where(entry => entry.GuildId == guildId).ToList();

				return experiences.OrderByDescending(x => x.TotalXP)
					.ToList().AsReadOnly();
			}
			else
			{
				return null;
			}
		}

		public async Task<IReadOnlyList<User>> GetOrderedGuildMoneyLeaderboardAsync(IGuild guild)
		{
			if (Users.AsNoTracking().Any())
			{
				List<User> entries = new();

				foreach (var user in Users.AsNoTracking())
				{
					var gldUsr = await guild.GetUserAsync(user.Id)
						.ConfigureAwait(false);
					if (gldUsr != null)
					{
						if (!entries.Any(x => x.Id == user.Id))
						{
							entries.Add(user);
						}
					}
				}

				return entries.OrderByDescending(x => x.Money)
					.ToList().AsReadOnly();
			}
			else
			{
				return null;
			}
		}

		public PixelData GetPixel(uint x, uint y)
		{
			PixelData pixel = PlacePixelData.AsNoTracking().FirstOrDefault(p => p.XPos == x && p.YPos == y);

			if (pixel == null)
			{
				pixel = new PixelData
				{
					XPos = x,
					YPos = y,
					B = 0,
					G = 0,
					R = 0
				};

				PlacePixelData.Add(pixel);
			}

			return pixel;
		}
	}
}