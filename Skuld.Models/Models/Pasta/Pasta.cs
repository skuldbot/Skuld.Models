using Skuld.Core.Extensions.Verification;
using Skuld.Core.Utilities;

namespace Skuld.Models
{
    public class Pasta
    {
        public ulong Id { get; set; }
        public ulong OwnerId { get; set; }
        public string Name { get; set; }
        public ulong Created { get; set; }
        public string Content { get; set; }

        public bool IsOwner(User user)
        {
            return OwnerId == user.Id ||
                user.Flags.IsBitSet(DiscordUtilities.BotCreator) ||
                user.Flags.IsBitSet(DiscordUtilities.BotAdmin);
        }
    }
}