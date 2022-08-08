using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpString
{
    internal class AlgorithmsAndDS
    {
        public static void SinglyLinkedListTraversal()
        {
            SingleLinkedlist node1 = new SingleLinkedlist(100);
            SingleLinkedlist node2 = node1.InsertNext(200);
            SingleLinkedlist node3 = node2.InsertNext(300);
            SingleLinkedlist node4 = node3.InsertNext(400);
            SingleLinkedlist node5 = node4.InsertNext(500);
            node1.Traverse(null);
            //Console.WriteLine("Deleting from Linked List...");
            //node3.DeleteNext();
            //node1.Traverse(null);
            var reverse = node1.ReverseList(node1);
            reverse.Traverse(null);
            System.Console.ReadLine();
        }

        public static void CircularSinglyLinkedListTraversal()
        {
            Circularlist node1 = new Circularlist(100);
            node1.Deldata();
            Circularlist node2 = node1.Insdata(200);
            node1.Deldata();
            node2 = node1.Insdata(200);
            Circularlist node3 = node2.Insdata(300);
            Circularlist node4 = node3.Insdata(400);
            Circularlist node5 = node4.Insdata(500);
            node1.Gnodes();
            node3.Gnodes();
            node5.Gnodes();
            node1.Traverse();
            node5.Deldata();
            node2.Traverse();
            node1.Gnodes();
            node2.Gnodes();
            node5.Gnodes();
            Console.ReadLine();
        }
        public static void BST()
        {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(50);
            nums.Insert(17);
            nums.Insert(23);
            nums.Insert(12);
            nums.Insert(19);
            nums.Insert(54);
            nums.Insert(9);
            nums.Insert(14);
            nums.Insert(67);
            nums.Insert(76);
            nums.Insert(72);

            Console.WriteLine("Inorder Traversal : ");
            nums.Inorder(nums.root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Preorder Traversal : ");
            nums.Preorder(nums.root);
            Console.WriteLine(" ");
            Console.WriteLine();
            Console.WriteLine("Postorder Traversal : ");
            nums.Postorder(nums.root);
            Console.WriteLine(" ");
        }

        public static void BSTHeight()
        {
            BinarySearchTree nums = new BinarySearchTree();
            nums.Insert(50);
            nums.Insert(17);
            nums.Insert(23);
            nums.Insert(12);
            nums.Insert(19);
            nums.Insert(54);
            nums.Insert(9);
            nums.Insert(14);
            nums.Insert(67);
            nums.Insert(76);
            nums.Insert(72);
            nums.Insert(74);

            Console.WriteLine($"Height: {nums.Height(nums.root)}");
        }

        #region using C# LinkedList
        public static void ReverseList()
        {
            string[] words = { "the", "fox", "jumps", "over", "the", "dog" };
            LinkedList<string> sentence = new LinkedList<string>(words);
            ReverseLinkedList(sentence);

            void ReverseLinkedList(LinkedList<string> linkedList)
            {
                DisplayList(linkedList);
                LinkedList<string> copyList = new LinkedList<string>();
                LinkedListNode<string> start = linkedList.Last;
                while (start != null)
                {
                    copyList.AddLast(start.Value);
                    start = start.Previous;
                }
                linkedList = copyList;
                DisplayList(linkedList);
            }

        }
        public static void FindNode()
        {
            LinkedList<string> linked = new LinkedList<string>();
            linked.AddLast("A");
            linked.AddLast("B");
            linked.AddLast("C");
            LinkedListNode<string> node = linked.Find("A");
            linked.AddAfter(node, "inserted");

            DisplayList(linked);
        }
        private static void DisplayList(LinkedList<string> linkedList)
        {
            foreach (var word in linkedList)
            {
                Console.Write($"{word} ");
            }
            Console.WriteLine();
        }

        #endregion
    }


}
