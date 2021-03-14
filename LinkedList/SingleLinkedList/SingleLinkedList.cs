using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class SingleLinkedList<T> where T : IComparable
    {
        public Node<T> Head { get; private set; }

        public Node<T> Tail
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

        public int Count
        {
            get
            {
                int count = 0;
                var temp = Head;
                while (temp != null)
                {
                    temp = temp.Next;
                    count++;
                }

                return count;
            }
        }


        public void InsertFirst(T data)
        {
            if (Head == null)
            {
                Head = new Node<T>(data);
                return;
            }

            var newNode = new Node<T>(data);
            newNode.Next = Head;
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
            if (Head == null)
            {
                Head = new Node<T>(data);
                return;
            }

            var newNode = new Node<T>(data);
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
            Node<T> prev = null;

            while (temp != null && temp.Data.CompareTo(after) != 0)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                throw new Exception($"There is no such an element: {element}");
            }

            if (temp.Data.CompareTo(after) == 0)
            {
                var tempNext = temp.Next;
                var newNode = new Node<T>(element);
                prev.Next.Next = newNode;
                newNode.Next = tempNext;
            }
        }

        public void DeleteNode(T key)
        {
            Node<T> temp = Head;
            Node<T> prev = null;

            if (temp != null && temp.Data.CompareTo(key) == 0)
            {
                Head = Head.Next;
                return;
            }

            while (temp != null && temp.Data.CompareTo(key) != 0)
            {
                prev = temp;
                temp = temp.Next;
            }

            if (temp == null)
            {
                return;
            }

            prev.Next = temp.Next;
        }

        public void ReverseIterative()
        {
            Node<T> prev = null;
            Node<T> current = Head;
            Node<T> temp = null;

            while (current != null)
            {
                temp = current.Next;
                current.Next = prev;
                prev = current;
                current = temp;
            }

            Head = prev;
        }

        private Node<T> ReverseRecursively(Node<T> node)
        {
            if (node == null || node.Next == null)
            {
                return node;
            }

            Node<T> reversedListHead = ReverseRecursively(node.Next);
            node.Next.Next = node;
            node.Next = null;
            return reversedListHead;
        }

        public Node<T> ReverseRecursively()
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

            return string.Join("->", list);
        }
    }
}
