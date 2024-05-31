using CodingPatterns;
using CodingPatterns.Models;
using FluentAssertions;

namespace CodingPatternsTests
{
    [TestClass]
    public class BFSTests
    {
        public readonly BFS _sut;
        public BFSTests()
        {
            _sut = new BFS();
        }

        [TestMethod]
        public void Binary_tree_returns_data_in_bfs_order()
        {
            _sut.root = new BinaryTreeNode(1);
            _sut.root.left = new BinaryTreeNode(2);
            _sut.root.right = new BinaryTreeNode(3);
            _sut.root.left.left = new BinaryTreeNode(4);
            _sut.root.left.right = new BinaryTreeNode(5);

            var result = _sut.GetLevelOrder();

           result.Should().BeEquivalentTo(new List<int>() { 1, 2, 3, 4, 5 });
        }
    }
}
