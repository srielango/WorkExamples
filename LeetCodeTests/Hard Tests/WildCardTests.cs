using FluentAssertions;
using LeetCodeTests.HardTests;

namespace LeetCodeTests.Hard_Tests
{
    [TestClass]
    public class WildCardTests : BaseHardTests
    {
        [TestMethod]
        [DataRow("", "")]
        [DataRow("", "*")]
        public void WildCard_EmptyString_ReturnsTrue(string s, string p)
        {
            // Act
            bool result = _sut.WildCardMatch(s, p);
            // Assert
            result.Should().BeTrue();
        }

        [TestMethod]
        [DataRow("", "?")]
        public void WildCard_EmptyStringWithQuestion_ReturnsFalse(string s, string p)
        {
            // Act
            bool result = _sut.WildCardMatch(s, p);
            // Assert
            result.Should().BeFalse();
        }

        [TestMethod]
        [DataRow("aa", "a", false)]
        [DataRow("aa", "*", true)]
        [DataRow("cb", "?a", false)]
        [DataRow("acdcb", "a*c?b", false)]
        [DataRow("", "******", true)]
        [DataRow("adceb", "*a*b", true)]
        public void WildCard_Pattern_Tests(string s, string p, bool expected)
        {
            // Act
            bool result = _sut.WildCardMatch(s, p);
            // Assert
            result.Should().Be(expected);
        }
    }
}
