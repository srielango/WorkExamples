using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IsValidTests : BaseTests
    {
        [TestMethod]
        [DataRow("()", true)]
        [DataRow("()[]{}", true)]
        public void ValidParantesis_ReturnsTrue(string s, bool expected)
        {
            var result = _sut.IsValid(s);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow("}", false)]
        [DataRow("(]", false)]
        [DataRow("(()[]{}", false)]
        public void InvalidParantesis_ReturnsFalse(string s, bool expected)
        {
            var result = _sut.IsValid(s);
            result.Should().Be(expected);
        }
    }
}
