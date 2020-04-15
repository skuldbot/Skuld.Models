using Discord;
using Skuld.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skuld.Models
{
    public static class DatabaseUtilities
    {
        public static ulong GetXPLevelRequirement(ulong level, double growthmod)
            => (ulong)Math.Round(Math.Clamp((float)Math.Pow(level, growthmod) * 50, 0, 1500000), MidpointRounding.AwayFromZero);

        public static ulong GetLevelFromTotalXP(ulong totalxp, double growthmod)
        {
            var split = growthmod.ToString().Split(".");

            return (ulong)Math.Round(Math.Pow(totalxp / 50, Convert.ToDouble(split[0])).NthRoot(Convert.ToInt32(split[1])), MidpointRounding.AwayFromZero);
        }

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
    }
}