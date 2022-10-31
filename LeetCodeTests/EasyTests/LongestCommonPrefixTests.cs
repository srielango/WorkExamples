using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class LongestCommonPrefixTests : BaseTests
    {
        [TestMethod]
        [DataRow(new string[] { "flower", "flow", "flight" }, "fl")]
        [DataRow(new string[] { "dog", "racecar", "car" }, "")]
        [DataRow(new string[] { "ab", "a" }, "a")]
        public void StringArray_ReturnsCommonPrefix(string[] str, string expected)
        {
            var result = _sut.LongestCommonPrefix(str);
            result.Should().Be(expected);
        }
    }
}
