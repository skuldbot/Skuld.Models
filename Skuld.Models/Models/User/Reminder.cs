namespace Skuld.Models
{
	public class ReminderObject
	{
		public ulong Id { get; set; }
		public ushort LocalId { get; set; }
		public ulong UserId { get; set; }
		public ulong Timeout { get; set; }
		public string Content { get; set; }
		public string MessageLink { get; set; }
		public ulong Created { get; set; }
		public bool Repeats { get; set; }
	}
}