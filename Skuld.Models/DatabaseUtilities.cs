using Discord;
using Skuld.Core.Extensions;
using Skuld.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skuld.Models
{
    public static class DatabaseUtilities
    {
        public static ulong GetXPLevelRequirement(ulong level, double growthmod)
            => (ulong)Math.Round(Math.Pow(level, 2) * 50 * growthmod, MidpointRounding.AwayFromZero);

        public static ulong GetLevelFromTotalXP(ulong totalxp, double growthmod)
            => (ulong)(Math.Sqrt(totalxp / (50 * growthmod)));

        /// <summary>
        /// Gets the experience multiplier from Users Minutes in Voice
        /// </summary>
        /// <param name="expDeterminate">Determinate Value for parabola</param>
        /// <param name="minMinutes">Minimum Minutes In voice</param>
        /// <param name="maxExperience">Maximum XP to grant</param>
        /// <param name="timeInVoice">Users time in voice by minutes</param>
        /// <returns></returns>
        public static int GetExpMultiFromMinutesInVoice(float expDeterminate, ulong minMinutes, ulong maxExperience, ulong timeInVoice)
        {
            if (timeInVoice < minMinutes)
                return 0; //if less than minimum minutes return 0 multiplier

            var result = Math.Pow(expDeterminate * (timeInVoice - minMinutes), 2); //do math

            if (result > maxExperience)
                result = maxExperience; //clamp to maxExperience as limit

            if (result < 0)
                result = 0; //if negative clamp to zero

            return (int)Math.Round(result); //return rounded integral version of result
        }

        public static UserExperience GetJoinedExperience(this IEnumerable<UserExperience> experiences, ulong userId, IGuild guild = null)
        {
            UserExperience textExperience;
            UserExperience voiceExperience;

            if(guild != null)
            {
                textExperience = experiences.FirstOrDefault(x => x.GuildId == guild.Id && x.UserId == userId);
                voiceExperience = experiences.FirstOrDefault(x => x.GuildId == guild.Id && x.IsVoiceExperience == true && x.UserId == userId);
            }
            else
            {
                textExperience = experiences.FirstOrDefault(x => x.UserId == userId);
                voiceExperience = experiences.FirstOrDefault(x => x.IsVoiceExperience == true && x.UserId == userId);
            }

            var lxp = textExperience;

            if(voiceExperience != null)
            {
                lxp.TotalXP = lxp.TotalXP.Add(voiceExperience.TotalXP);
                lxp.XP = lxp.XP.Add(voiceExperience.XP);
                lxp.Level = lxp.Level.Add(voiceExperience.Level);
            }

            bool didLevel = false;

            ulong levelAmount = 0;

            var xptonextlevel = GetXPLevelRequirement(lxp.Level + 1, DiscordUtilities.PHI);

            var currXp = lxp.XP;

            if (lxp.XP >= xptonextlevel)
            {
                while (currXp >= xptonextlevel)
                {
                    levelAmount++;
                    currXp = currXp.Subtract(xptonextlevel);
                    xptonextlevel = GetXPLevelRequirement(lxp.Level + 1 + levelAmount, DiscordUtilities.PHI);

                    didLevel = true;
                }
            }

            if(didLevel)
            {
                lxp.XP = currXp;
                lxp.Level = lxp.Level.Add(levelAmount);
            }

            return lxp;
        }
    }
}