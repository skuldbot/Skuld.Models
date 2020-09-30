using System.ComponentModel.DataAnnotations;

namespace Skuld.Models.ThePlace
{
    public class PixelHistory
    {
        [Key]
        public ulong EntryId { get; set; } = 0;

        public ulong PixelId { get; set; } = 0;

        public ulong ModifierId { get; set; } = 0;

        public ulong CostToChange { get; set; } = 0;

        public ulong ChangedTimestamp { get; set; } = 0;
    }
}
