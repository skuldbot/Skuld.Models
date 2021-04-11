#pragma warning disable CA1056
using Discord.WebSocket;
using System;

namespace Skuld.Models
{
	public class User
	{
		public ulong Id { get; set; }

		public string Username { get; set; }
		public string AvatarUrl { get; set; }

		public string Title { get; set; }
		public string Language { get; set; } = "en-GB";
		public string TimeZone { get; set; } = TimeZoneInfo.Utc.Id;

		/// <summary>
		/// Times been Patted
		/// </summary>
		public ulong Patted { get; set; }

		/// <summary>
		/// Times patted someone else
		/// </summary>
		public ulong Pats { get; set; }

		public bool UnlockedCustBG { get; set; }
		public string Background { get; set; } = "#3F51B5";

		public ulong Flags { get; set; }
		public string BanReason { get; set; }

		public ulong Money { get; set; }
		public uint Streak { get; set; }
		public uint MaxStreak { get; set; }
		public ulong LastDaily { get; set; }

		public bool RecurringBlock { get; set; }

		public ulong PrestigeLevel { get; set; }

		public bool IsUpToDate(SocketUser user)
		{
			if (user is null) return false;

			string avi = user.GetAvatarUrl() ?? user.GetDefaultAvatarUrl();

			bool username = Username == user.Username;
			bool avatar = AvatarUrl == avi;

			return (username && avatar) == true;
		}

		public bool IsDonator
		{
			get
			{
				return (Flags & 1 << 2) != 0;
			}
		}
	}
}
#pragma warning restore CA1056