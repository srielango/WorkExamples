using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class SingleNumberTests : BaseTests
    {

        [TestMethod]
        [DataRow(new int[] { 1, 2, 1, 2, 3, 4, 5, 4, 5 }, 3)]
        [DataRow(new int[] { 1, 1, 2, 2, 3 }, 3)]
        public void IntegerArrayWithExactlyOneSingleNumber_ReturnsSingleNumber(int[] nums, int expected)
        {
            var result = _sut.SingleNumber(nums);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1, 2, 3, 1, 2 })]
        public void SameNumberAppearingMoreThanTwice_ThrowsError(int[] nums)
        {
            var result = () => _sut.SingleNumber(nums);
            result.Should().Throw<ArgumentException>()
                .WithMessage("Numbers appear more than 2 times");
        }

        [TestMethod]
        [DataRow(new int[] { 1, 1, 2, 3, 2, 3 })]
        public void NoSingleNumber_ThrowsError(int[] nums)
        {
            var result = () => _sut.SingleNumber(nums);
            result.Should().Throw<ArgumentException>()
                .WithMessage("No single number");
        }
    }
}
