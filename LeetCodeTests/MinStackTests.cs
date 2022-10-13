using FluentAssertions;
using LeetCode;

namespace LeetCodeTests
{
    [TestClass]
    public class MinStackTests
    {
        [TestMethod]
        public void MinStackPop_ReturnsLastValue()
        {
            MinStack minStack = new MinStack();
            minStack.Push(-2);
            minStack.Push(0);
            minStack.Push(-3);
            var min = minStack.GetMin(); // return -3
            min.Should().Be(-3);
            minStack.Pop();
            var top = minStack.Top();    // return 0
            top.Should().Be(0);
            min = minStack.GetMin(); // return -2
            min.Should().Be(-2);
        }
    }
}
