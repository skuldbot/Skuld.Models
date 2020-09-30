using Discord.Commands;
using System;
using System.Reflection;

namespace Skuld.Models
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
        public bool ThePlace { get; set; } = true;
        public bool Weeb { get; set; } = true;

        public bool ModuleDisabled(CommandInfo command)
        {
            PropertyInfo propertyInfo = null;

            ModuleInfo module = command.Module;
            while(propertyInfo == null)
            {
                var prop = typeof(GuildModules).GetProperty(module.Name);

                if(prop == null)
                {
                    if(module.IsSubmodule)
                    {
                        module = module.Parent;
                    }
                    else
                    {
                        throw new ArgumentException($"Cannot find property for value: {command.Module.Name}");
                    }
                }
                else
                {
                    propertyInfo = prop;
                }
            }

            return !(bool)propertyInfo.GetValue(this);
        }
    }
}