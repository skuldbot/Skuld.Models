namespace Skuld.Models
{
	public class TwitchFollow
	{
		public ulong Id { get; set; }
		public ulong ChannelId { get; set; }
		public ulong GuildId { get; set; }
		public string Streamer { get; set; }
		public bool IsLive { get; set; }
	}
}
