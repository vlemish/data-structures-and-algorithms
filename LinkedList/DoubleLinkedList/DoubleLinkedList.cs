using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class DoubleLinkedList<T> where T : IComparable
    {
        public DNode<T> Head { get; private set; }

        public DNode<T> Tail
        {
            get
            {
                var temp = Head;

                while (temp.Next != null)
                {
                    temp = temp.Next;
                }

                return temp;
            }
        }


        public void InsertFirst(T data)
        {
            var newNode = new DNode<T>(data);

            if (Head == null)
            {
                Head = newNode;
                Head.Next = null;
                Head.Previous = null;
                return;
            }

            newNode.Next = Head;
            Head.Previous = newNode;
            Head = newNode;
        }

        public void InsertFirst(T[] data)
        {
            foreach (var node in data)
            {
                this.InsertFirst(node);
            }
        }

        public void InsertLast(T data)
        {
            var newNode = new DNode<T>(data);

            if (Head == null)
            {
                Head = newNode;
                return;
            }

            newNode.Previous = Last;
            Last.Next = newNode;
        }

        public void InsertLast(T[] data)
        {
            foreach (var node in data)
            {
                this.InsertLast(node);
            }
        }

        public void InsertAfter(T after, T element)
        {
            var temp = Head;

            while (temp != null && temp.Data.CompareTo(after) != 0)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                throw new Exception($"There is no such an element: {element}");
            }

            if (temp.Data.CompareTo(after) == 0)
            {
                var newNode = new DNode<T>(element);
                var tempNext = temp.Next;
                newNode.Previous = temp;
                newNode.Next = tempNext;
                temp.Next = newNode;
                tempNext.Previous = newNode;


            }
        }

        public void DeleteNode(T key)
        {
            DNode<T> temp = Head;

            if (temp != null && temp.Data.CompareTo(key) == 0)
            {
                Head = temp.Next;
                Head.Previous = null;
                return;
            }

            while (temp != null && temp.Data.CompareTo(key) != 0)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                return;
            }

            if (temp.Next != null)
            {
                temp.Next.Previous = temp.Previous;
            }

            if (temp.Previous != null)
            {
                temp.Previous.Next = temp.Next;
            }
        }

        public void ReverseIterative()
        {
            DNode<T> prev = null;
            DNode<T> current = Head;
            DNode<T> temp = null;

            while (current != null)
            {
                temp = current.Next;
                current.Next = prev;
                prev = current;
                current = temp;
            }

            Head = prev;
        }

        private DNode<T> ReverseRecursively(DNode<T> node)
        {
            if (node == null || node.Next == null)
            {
                return node;
            }

            DNode<T> reversedListHead = ReverseRecursively(node.Next);
            node.Next.Next = node;
            node.Next = null;
            return reversedListHead;
        }

        public DNode<T> ReverseRecursively()
        {
            return Head = ReverseRecursively(Head);
        }

        public override string ToString()
        {
            List<string> list = new List<string>();

            var temp = Head;

            while (temp != null)
            {
                list.Add(temp.Data.ToString());
                temp = temp.Next;
            }

            return string.Join(@" <--> ", list);
        }
    }
}