using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IsHappyTests : BaseTests
    {
        [TestMethod]
        [DataRow(19, true)]
        public void HappyNumbers_ReturnsTrue(int num, bool expected)
        {
            var result = _sut.IsHappy(num);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(2, false)]
        public void UnHappyNumbers_ReturnsFalse(int num, bool expected)
        {
            var result = _sut.IsHappy(num);
            result.Should().Be(expected);
        }
    }
}
