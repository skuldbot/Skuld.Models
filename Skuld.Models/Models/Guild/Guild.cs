namespace Skuld.Models
{
    public class Guild
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public string Prefix { get; set; }

        //Welcome/Leaving
        public string JoinMessage { get; set; }
        public string LeaveMessage { get; set; }
        public ulong JoinRole { get; set; }
        public ulong JoinChannel { get; set; }
        public ulong LeaveChannel { get; set; }

        //ServerManagement
        public ulong MutedRole { get; set; }

        //Levelling
        public ulong LevelUpChannel { get; set; }
        public string LevelUpMessage { get; set; }
        public LevelNotification LevelNotification { get; set; }

        //Money
        public string MoneyName { get; set; }
        public string MoneyIcon { get; set; }

        //Starboard
        public ulong StarboardChannel { get; set; } = 0;
        public ushort StarReactAmount { get; set; } = 5;
        /// <summary>
        /// Can People Self Star
        /// </summary>
        public bool SelfStarring { get; set; } = false;
        /// <summary>
        /// Delete Starboard Message if Source Message is Deleted
        /// </summary>
        public bool StarDeleteIfSourceDelete { get; set; } = false;
        ///<summary>
        ///Reaction to react with on message
        ///</summary>
        public string StarEmote { get; set; } = "⭐";
        ///<summary>
        ///Star Icon for range between 10-19 Reactions
        ///</summary>
        public string StarRange1 { get; set; } = "🌟";
        /// <summary>
        /// Star Icon for range between 20-29 Reactions
        /// </summary>
        public string StarRange2 { get; set; } = "🌠";
        /// <summary>
        /// Star Icon for 30+ Reactions
        /// </summary>
        public string StarRange3 { get; set; } = "✨";
    }
}