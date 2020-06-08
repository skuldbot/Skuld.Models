using Skuld.Core.Utilities;
using Xunit;

namespace Skuld.Models.Tests
{
    public class ExperienceTests
    {
        [Fact]
        public void TestGetExperienceFromLevel()
        {
            var res = DatabaseUtilities.GetLevelFromTotalXP(25616, DiscordUtilities.LevelModifier);

            Assert.Equal<ulong>(9, res);
        }
    }
}
