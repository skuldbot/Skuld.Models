namespace Skuld.Models
{
	public class GuildFeatures
	{
		public ulong Id { get; set; }
		public bool Pinning { get; set; }
		public bool Starboard { get; set; }
		public bool Experience { get; set; }
		public bool StackingRoles { get; set; }
	}
}