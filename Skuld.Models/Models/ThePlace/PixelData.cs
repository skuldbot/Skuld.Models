using Discord;
using System.ComponentModel.DataAnnotations;

namespace Skuld.Models.ThePlace
{
    public class PixelData
    {
        [Key]
        public ulong Id { get; set; } = 0;
        public uint XPos { get; set; } = 0;
        public uint YPos  { get; set; } = 0;
        public ushort R  { get; set; } = 0;
        public ushort G  { get; set; } = 0;
        public ushort B  { get; set; } = 0;
    }
}
