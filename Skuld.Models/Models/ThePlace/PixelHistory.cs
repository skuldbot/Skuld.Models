using System.ComponentModel.DataAnnotations;

namespace Skuld.Models.ThePlace
{
	public class PixelHistory
	{
		[Key]
		public ulong EntryId { get; set; } = 0;

		public ulong PixelId { get; set; }

		public ulong ModifierId { get; set; }

		public ulong CostToChange { get; set; }

		public ulong ChangedTimestamp { get; set; }
	}
}
