using NUnit.Framework;

namespace AdvancedTask.AssertHelpers
{
    public class LanguageAssertHelper
    {
        public static void assertAddLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
        public static void assertAddEmptyLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Is.EqualTo(expected), $"Actual message '{actual}' does not match expected message '{expected}'");
        }
        public static void assertEditLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
        public static void assertDeleteLanguageSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
    }
}
