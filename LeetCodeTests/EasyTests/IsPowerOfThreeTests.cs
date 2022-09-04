using FluentAssertions;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IsPowerOfThreeTests : BaseTests
    {
        [TestMethod]
        [DataRow(1, true)]
        [DataRow(3, true)]
        [DataRow(9, true)]
        [DataRow(27, true)]
        [DataRow(81, true)]
        [DataRow(243, true)]
        public void PowersOfThree_ReturnsTrue(int n, bool expected)
        {
            var result = _sut.IsPowerOfThree(n);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(0, false)]
        public void Zero_ReturnsFalse(int n, bool expected)
        {
            var result = _sut.IsPowerOfThree(n);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(2, false)]
        [DataRow(20, false)]
        [DataRow(41, false)]
        [DataRow(82, false)]
        [DataRow(1162261468, false)]
        public void NonPowersOfThree_ReturnsFalse(int n, bool expected)
        {
            var result = _sut.IsPowerOfThree(n);
            result.Should().Be(expected);
        }

    }
}
