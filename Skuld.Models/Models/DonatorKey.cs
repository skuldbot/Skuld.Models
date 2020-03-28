using System;

namespace Skuld.Models
{
    public class DonatorKey
    {
        public ulong Id { get; set; }
        public Guid KeyCode { get; set; }
        public bool Redeemed { get; set; } = false;
        public ulong Redeemer { get; set; } = 0;
        public ulong RedeemedWhen { get; set; } = 0;
    }
}