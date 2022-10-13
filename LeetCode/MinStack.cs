namespace LeetCode
{
    public class MinStack
    {
        List<int> myList = new List<int>();
        Stack<int> stack = new Stack<int>();
        public MinStack()
        {

        }

        public void Push(int val)
        {
            myList.Add(val);
            stack.Push(val);
        }

        public void Pop()
        {
            var x = stack.Pop();
            myList.Remove(x);
        }

        public int Top()
        {
            var x = stack.Pop();
            stack.Push(x);
            return x;
        }

        public int GetMin()
        {
            return myList.Min();
        }
    }
}
