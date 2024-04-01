using NUnit.Framework;

namespace AdvancedTask.AssertHelpers
{
    public class ProfileAssertHelper
    {
        public static void assertProfileSuccessMessage(String expected, String actual)
        {
            Assert.That(actual, Does.Match(expected), $"Actual message '{actual}' does not match the expected pattern '{expected}'");
        }
    }
}
