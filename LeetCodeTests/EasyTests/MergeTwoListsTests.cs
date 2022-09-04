using FluentAssertions;
using LeetCode;
using System.Collections.Generic;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class MergeTwoListsTests : BaseTests
    {
        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void TwoSortedLists_ReturnsMergedList(ListNode list1, ListNode list2, ListNode expected)
        {
            AssertionOptions.FormattingOptions.MaxDepth = 100;
            var result = _sut.MergeTwoLists(list1, list2);
            (true).Should().Be(areIdentical(expected, result));
        }

        private static IEnumerable<object[]> GetData()
        {
            //var list1 = new ListNode(1, new ListNode(2, new ListNode(4)));
            //var list2 = new ListNode(1, new ListNode(3, new ListNode(4)));
            //var expected = new ListNode(1, new ListNode(1, new ListNode(2, new ListNode(3, new ListNode(4, new ListNode(4))))));
            //yield return new object[] { list1, list2, expected };

            var list1 = new ListNode();
            var list2 = new ListNode();
            var expected = new ListNode();
            yield return new object[] { list1, list2, expected };
        }

        private bool areIdentical(ListNode a, ListNode b)
        {
            while (a != null && b != null)
            {
                if (a.val != b.val)
                    return false;
                a = a.next;
                b = b.next;
            }
            return (a == null && b == null);
        }
    }
}
