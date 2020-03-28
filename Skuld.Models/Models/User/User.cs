using Discord.WebSocket;
using System;

namespace Skuld.Models
{
    public class User
    {
        public ulong Id { get; set; } = 0;

        public string Username { get; set; } = null;
        public string AvatarUrl { get; set; } = null;

        public string Title { get; set; } = null;
        public string Language { get; set; } = "en-GB";
        public string TimeZone { get; set; } = TimeZoneInfo.Utc.Id;

        /// <summary>
        /// Times been Patted
        /// </summary>
        public ulong Patted { get; set; } = 0;

        /// <summary>
        /// Times patted someone else
        /// </summary>
        public ulong Pats { get; set; } = 0;

        public bool UnlockedCustBG { get; set; } = false;
        public string Background { get; set; } = "#3F51B5";

        public ulong Flags { get; set; } = 0;
        public string BanReason { get; set; } = null;

        public ulong Money { get; set; } = 2500;
        public uint Streak { get; set; } = 0;
        public ulong LastDaily { get; set; } = 0;

        public bool RecurringBlock { get; set; } = false;

        public ulong PrestigeLevel { get; set; } = 0;

        public bool IsUpToDate(SocketUser user)
        {
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