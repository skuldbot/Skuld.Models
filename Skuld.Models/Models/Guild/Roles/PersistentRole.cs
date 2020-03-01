namespace Skuld.Core.Models
{
    public class PersistentRole
    {
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }
        public ulong RoleId { get; set; }
        public ulong UserId { get; set; }
    }
}