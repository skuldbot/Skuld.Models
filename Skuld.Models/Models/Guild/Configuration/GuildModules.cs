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
			if (command is null) return false;

			PropertyInfo propertyInfo = null;
			ModuleInfo module = command.Module;
			Type guildModType = typeof(GuildModules);

			while (propertyInfo is null)
			{
				var prop = guildModType.GetProperty(module.Name);

				if (prop is null)
				{
					if (!module.IsSubmodule)
					{
						throw new ArgumentException($"Cannot find property for value: {command.Module.Name}");
					}

					module = module.Parent;
					continue;
				}

				propertyInfo = prop;
			}

			return !(bool)propertyInfo.GetValue(this);
		}
	}
}