using Skuld.Core.Extensions;
using System;

namespace Skuld.Models
{
    public static class DatabaseUtilities
    {
        /// <summary>
        /// Gets the XP required for a specific level
        /// </summary>
        /// <param name="level">Level to get the requirement for</param>
        /// <param name="growthmod">Growth modifier to use</param>
        /// <returns>The target levels experience requirement</returns>
        public static ulong GetXPLevelRequirement(ulong level, double growthmod)
            => (ulong)Math.Round(Math.Clamp((float)Math.Pow(level, growthmod) * 50, 0, 1500000), MidpointRounding.AwayFromZero);

        public static ulong GetStackedXPLevelRequirement(ulong level, double growthmod)
        {
            ulong xp = 0;

            for (ulong lvl = 0; lvl < level; lvl++)
            {
                xp = xp.Add(GetXPLevelRequirement(lvl, growthmod));
            }

            return xp;
        }

        /// <summary>
        /// Gets the Users current level from their total experience
        /// </summary>
        /// <param name="totalxp">Users total experience</param>
        /// <param name="growthmod">Growth modifier to use</param>
        /// <returns>Users current level</returns>
        public static ulong GetLevelFromTotalXP(ulong totalxp, double growthmod)
        {
            if (totalxp <= GetXPLevelRequirement(1, growthmod)) return 0;

            ulong level = 0;

            ulong txp = 0;
            
            while(txp < totalxp)
            {
                txp += GetXPLevelRequirement(level, growthmod);
                level++;
            }

            return level-1;
        }

        /// <summary>
        /// Gets the experience multiplier from Users Minutes in Voice
        /// </summary>
        /// <param name="expDeterminate">Determinate Value for parabola</param>
        /// <param name="minMinutes">Minimum Minutes In voice</param>
        /// <param name="maxExperience">Maximum XP to grant</param>
        /// <param name="timeInVoice">Users time in voice by minutes</param>
        /// <returns>The rounded int value of experience to grant</returns>
        public static ulong GetExpMultiFromMinutesInVoice(float expDeterminate, ulong minMinutes, ulong maxExperience, ulong timeInVoice)
        {
            if (timeInVoice < minMinutes)
                return 0; //if less than minimum minutes return 0 multiplier

            var result = Math.Pow(expDeterminate * (timeInVoice - minMinutes), 2); //do math

            result = Math.Clamp(result, 0, maxExperience); //clamp to maxExperience as limit

            return (ulong)Math.Round(result); //return rounded integral version of result
        }
    }
}