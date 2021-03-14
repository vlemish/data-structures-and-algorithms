using System;
using System.Collections.Generic;
namespace BinaryTreeApp
{
    public enum Side
    {
        Left,
        Right,
    }

    public class BinaryTreeNode<T> where T : IComparable
    {
        public T Data { get; set; }

        public BinaryTreeNode<T> LeftNode { get; set; }

        public BinaryTreeNode<T> RightNode { get; set; }

        public BinaryTreeNode<T> ParentNode { get; set; }


        public BinaryTreeNode(T data)
        {
            Data = data;
        }


        public Side? NodeSide =>
            ParentNode == null ?
            (Side?)null
            : ParentNode.LeftNode == this
            ? Side.Left
            : Side.Right;


        //transformation the tree to sorted array
        public T[] Transform(List<T> elements = null)
        {
            if (elements == null)
            {
                elements = new List<T>();
            }

            if (LeftNode != null)
            {
                LeftNode.Transform(elements);
            }

            elements.Add(Data);

            if (RightNode != null)
            {
                RightNode.Transform(elements);
            }

            return elements.ToArray();
        }

        public T[] ReverseTransform(List<T> elements = null)
        {
            if (elements == null)
            {
                elements = new List<T>();
            }

            if (RightNode != null)
            {
                RightNode.ReverseTransform(elements);
            }

            elements.Add(Data);

            if (LeftNode != null)
            {
                LeftNode.ReverseTransform(elements);
            }

            return elements.ToArray();
        }

        public override string ToString()
        {
            return Data.ToString();
        }

    }
}
