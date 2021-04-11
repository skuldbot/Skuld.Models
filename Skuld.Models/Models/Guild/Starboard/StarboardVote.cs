namespace Skuld.Models
{
	public class StarboardVote
	{
		public ulong Id { get; set; }
		public ulong MessageId { get; set; }
		public ulong StarboardMessageId { get; set; }
		public ulong VoterId { get; set; }
		public ulong MessageAuthorId { get; set; }
		public ulong GuildId { get; set; }
		public ulong ChannelId { get; set; }
		public bool WasSourceMessageReaction { get; set; }
	}
}
