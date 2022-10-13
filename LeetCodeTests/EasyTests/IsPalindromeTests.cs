using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class IsPalindromeTests : BaseTests
    {
        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void LinkedListPalindrome_ReturnsTrue(ListNode node, bool expected)
        {
            var result = _sut.IsPalindrome(node);
            result.Should().Be(expected);
        }

        [TestMethod]
        [DynamicData(nameof(GetData1), DynamicDataSourceType.Method)]
        public void LinkedListWithoutPalindrome_ReturnsFalse(ListNode node, bool expected)
        {
            var result = _sut.IsPalindrome(node);
            result.Should().Be(expected);
        }

        private static IEnumerable<object[]> GetData()
        {
            var myList = new ListNode(1);
            var list1 = myList;
            list1.next = new ListNode(2);
            list1 = list1.next;
            list1.next = new ListNode(2);
            list1 = list1.next;
            list1.next = new ListNode(1);
            var expected = true;
            yield return new object[] { myList, expected };
        }

        private static IEnumerable<object[]> GetData1()
        {
            var myList = new ListNode(1);
            var list1 = myList;
            list1.next = new ListNode(2);
            var expected = false;
            yield return new object[] { myList, expected };
        }
    }
}
