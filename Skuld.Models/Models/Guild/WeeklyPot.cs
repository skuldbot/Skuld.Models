namespace Skuld.Models
{
    public class WeeklyPot
    {
        public ulong Id { get; set; }
        public ulong GuildId { get; set; }
        public ulong UserId { get; set; }
        public ulong Amount { get; set; }
        public ulong LastGranted { get; set; }
    }
}
