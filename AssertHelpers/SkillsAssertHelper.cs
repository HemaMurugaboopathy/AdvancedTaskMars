using NUnit.Framework;

namespace AdvancedTask.AssertHelpers
{
    public class SkillsAssertHelper
    {
        public static void assertAddSkillsSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
        public static void assertAddEmptySkillsSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Is.EqualTo(expected), $"Actual message '{actual}' does not match expected message '{expected}'");
        }
        public static void assertEditSkillsSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
        public static void assertDeleteSkillsSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
    }
}
