using System;

namespace Skuld.Core.Models
{
    public class ReminderObject
    {
        public ushort Id { get; set; }
        public ulong UserId { get; set; }
        public ulong ChannelId { get; set; }
        public ulong Timeout { get; set; }
        public string Content { get; set; }
        public string MessageLink { get; set; }
        public DateTime Created { get; set; }
    }
}