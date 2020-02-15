using Discord.Commands;

namespace Skuld.Core.Models
{
    public class GuildModules
    {
        public ulong Id { get; set; }
        public bool Accounts { get; set; } = true;
        public bool Actions { get; set; } = true;
        public bool Admin { get; set; } = true;
        public bool Custom { get; set; } = true;
        public bool Fun { get; set; } = true;
        public bool Gambling { get; set; } = true;
        public bool Information { get; set; } = true;
        public bool Lewd { get; set; } = true;
        public bool Search { get; set; } = true;
        public bool Space { get; set; } = true;
        public bool Stats { get; set; } = true;
        public bool Weeb { get; set; } = true;

        public bool ModuleDisabled(CommandInfo command)
        {
            return (command.Module.Name.ToLowerInvariant()) switch
            {
                "accounts" => !Accounts,
                "actions" => !Actions,
                "admin" => !Admin,
                "fun" => !Fun,
                "gambling" => !Gambling,
                "information" => !Information,
                "lewd" => !Lewd,
                "search" => !Search,
                "space" => !Space,
                "stats" => !Stats,
                "weeb" => !Weeb,
                _ => false,
            };
        }
    }
}