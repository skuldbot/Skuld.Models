using Skuld.Core.Utilities;
using Xunit;

namespace Skuld.Models.Tests
{
    public class ExperienceTests
    {
        [Fact]
        public void TestGetExperienceFromLevel()
        {
            var experience = new UserExperience
            {
                Level = 16,
                TotalXP = 229558
            };

            var res = DatabaseUtilities
                .GetLevelFromTotalXP(
                    experience.TotalXP,
                    DiscordUtilities.LevelModifier
                );

            Assert.Equal(experience.Level, res);
        }
    }
}
