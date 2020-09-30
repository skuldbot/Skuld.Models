namespace Skuld.Models
{
	public class GuildTwitterAccounts
	{
		public ulong Id { get; set; }

		public ulong GuildId { get; set; }
		public ulong ChannelId { get; set; }
		public long TwitterAccId { get; set; }
		public string TwitterAccName { get; set; }
	}
}
