namespace Skuld.Models
{
    public class Guild
    {
        public ulong Id { get; set; }
        public string Name { get; set; }
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
    }
}