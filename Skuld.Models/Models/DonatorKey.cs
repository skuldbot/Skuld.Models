using System;

namespace Skuld.Models
{
	public class DonatorKey
	{
		public ulong Id { get; set; }
		public Guid KeyCode { get; set; }
		public bool Redeemed { get; set; }
		public ulong Redeemer { get; set; }
		public ulong RedeemedWhen { get; set; }
	}
}