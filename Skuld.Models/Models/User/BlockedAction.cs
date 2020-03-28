namespace Skuld.Models
{
    public class BlockedAction
    {
        public ulong Id { get; set; }

        public ulong Blocker { get; set; }
        public ulong Blockee { get; set; }
    }
}