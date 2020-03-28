namespace Skuld.Models
{
    public class StarboardVote
    {
        public ulong Id { get; set; }
        public ulong MessageId { get; set; } = 0;
        public ulong StarboardMessageId { get; set; } = 0;
        public ulong VoterId { get; set; } = 0;
        public ulong MessageAuthorId { get; set; } = 0;
        public ulong GuildId { get; set; } = 0;
        public ulong ChannelId { get; set; } = 0;
        public bool WasSourceMessageReaction { get; set; } = false;
    }
}
