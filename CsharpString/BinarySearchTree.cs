using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpString
{
    public class Node
    {
        public int Data;
        public Node Left;
        public Node Right;

        public Node(int item)
        {
            Data = item;
            Left = Right = null;
        }
        public void DisplayNode()
        {
            Console.Write(Data + " ");
        }
    }
    internal class BinarySearchTree
    {


        public Node root;
        public BinarySearchTree()
        {
            root = null;
        }

        public void Insert(int key) { root = InsertRec(root, key); }
        Node InsertRec(Node root, int data)
        {

            // If the tree is empty,
            // return a new node
            if (root == null)
            {
                root = new Node(data);
                return root;
            }

            // Otherwise, recur down the tree
            if (data < root.Data)
                root.Left = InsertRec(root.Left, data);
            else if (data > root.Data)
                root.Right = InsertRec(root.Right, data);

            // Return the (unchanged) node pointer
            return root;
        }
        public void Preorder(Node Root)
        {
            if (Root != null)
            {
                Console.Write(Root.Data + " ");
                Preorder(Root.Left);
                Preorder(Root.Right);
            }
        }
        public void Inorder(Node Root)
        {
            if (Root != null)
            {
                Inorder(Root.Left);
                Console.Write(Root.Data + " ");
                Inorder(Root.Right);
            }
        }
        public void Postorder(Node Root)
        {
            if (Root != null)
            {
                Postorder(Root.Left);
                Postorder(Root.Right);
                Console.Write(Root.Data + " ");
            }
        }

        public int Height(Node root)
        {
            if (root == null) return 0;
            var leftHeight = Height(root.Left);
            var rightHeight = Height(root.Right);
            if(leftHeight > rightHeight)
            {
                return leftHeight + 1;
            }
            else
            {
                return rightHeight + 1;
            }
        }

        public Node Search(Node root, int data)
        {
            if(root == null || root.Data == data) return root;

            if (data < root.Data) return Search(root.Left, data);
            
            return Search(root.Right, data);
        }
    }
}
