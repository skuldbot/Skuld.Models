namespace Skuld.Models
{
    public class IAmRole
    {
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }
        public ulong RoleId { get; set; }
        public ulong Price { get; set; }
        public ulong LevelRequired { get; set; }
        public ulong RequiredRoleId { get; set; }
    }
}