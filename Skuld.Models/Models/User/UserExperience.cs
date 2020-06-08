namespace Skuld.Models
{
    public class UserExperience
    {
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public ulong GuildId { get; set; }
        public ulong TotalXP { get; set; }
        public ulong Level { get; set; }
        public ulong LastGranted { get; set; }
        public ulong MessagesSent { get; set; }
        public ulong TimeInVoiceM { get; set; }
    }
}