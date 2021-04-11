using System.ComponentModel.DataAnnotations;

namespace Skuld.Models.ThePlace
{
	public class PixelData
	{
		[Key]
		public ulong Id { get; set; } = 0;
		public uint XPos { get; set; }
		public uint YPos { get; set; }
		public ushort R { get; set; }
		public ushort G { get; set; }
		public ushort B { get; set; }
	}
}
