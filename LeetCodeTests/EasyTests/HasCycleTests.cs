using FluentAssertions;
using LeetCode;

namespace LeetCodeTests.EasyTests
{
    [TestClass]
    public class HasCycleTests : BaseTests
    {
        [TestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void LinkedListHavingCycle_ReturnsTrue(ListNode node, bool expected)
        {
            var result = _sut.HasCycle(node);
            result.Should().Be(expected);
        }

        private static IEnumerable<object[]> GetData()
        {
            var myList = new ListNode();
            var list1 = myList;
            list1.val = 3;
            var cycle = new ListNode(2);
            list1.next = cycle;
            list1 = list1.next;
            list1.next = new ListNode(0);
            list1 = list1.next;
            list1.next = new ListNode(4);
            list1 = list1.next;
            list1.next = cycle;
            var expected = true;
            yield return new object[] { myList, expected };

            myList = new ListNode();
            list1 = myList;
            list1.val = 1;
            list1.next = new ListNode(2);
            list1 = list1.next;
            list1.next = myList;
            expected = true;
            yield return new object[] { myList, expected };

            myList = new ListNode();
            myList.val = -1;
            expected = false;
            yield return new object[] { myList, expected };
        }
    }
}
