namespace Skuld.Core.Models
{
    public class LevelRewards
    {
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }
        public ulong RoleId { get; set; }
        public ulong LevelRequired { get; set; }
    }
}