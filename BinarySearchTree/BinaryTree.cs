using System;
using System.Collections.Generic;
using static System.Console;

namespace BinaryTreeApp
{
    public class BinaryTree<T> where T : IComparable
    {
        public BinaryTreeNode<T> RootNode { get; set; }

        private static readonly int Count = 5;


        #region Add Methods
        private BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
        {
            if (RootNode == null)
            {
                node.ParentNode = null;

                return RootNode = node;
            }

            currentNode = currentNode ?? RootNode;
            node.ParentNode = currentNode;
            int result = node.Data.CompareTo(currentNode.Data);
            if (result == 0)
            {
                return currentNode;
            }

            if (result < 0)
            {
                if (currentNode.LeftNode == null)
                {
                    return currentNode.LeftNode = node;
                }
                else
                {
                    return Add(node, currentNode.LeftNode);
                }
            }

            if (result > 0)
            {
                if (currentNode.RightNode == null)
                {
                    return currentNode.RightNode = node;
                }
                else
                {
                    return Add(node, currentNode.RightNode);
                }
            }
            return null;
        }

        public BinaryTreeNode<T> Add(T data)
        {
            return Add(new BinaryTreeNode<T>(data));
        }
        #endregion

        #region Find Node Methods
        public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
        {
            //if startWithNode is null then add RootNode as startWithNode 
            startWithNode = startWithNode ?? RootNode;
            int result;
            //does the same trick as was used in AddMethod
            return (result = data.CompareTo(startWithNode.Data)) == 0
                //if values are the same then return startWithNode ---->this is the value we were searching for
                //if searched value is lesser than startWithNode.Data then checks, is left node equals null: if yes - return null; if not, recursively looks in right node till the value is a null
                //if searched values is greater than startWitheNode.Data then checks is right node equals null: if yes - return null; if not, recursively looks in left node till the value is a null
                ? startWithNode
                : result < 0
                ? startWithNode.LeftNode == null
                ? null
                : FindNode(data, startWithNode.LeftNode)
                : startWithNode.RightNode == null
                ? null
                : FindNode(data, startWithNode.RightNode);
        }

        #endregion

        #region RemoveMethods
        private void Remove(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            var currentNodeSide = node.NodeSide;
            //if there is no subnode we can delete it
            if (node.LeftNode == null && node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = null;
                }
                else
                {
                    node.ParentNode.RightNode = null;
                }
            }

            //if there is no left node, so we put right node on deleted place
            else if (node.LeftNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.RightNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.RightNode;
                }
                node.RightNode.ParentNode = node.ParentNode;
            }

            //if there is no right node, so we put left node on deleted place
            else if (node.RightNode == null)
            {
                if (currentNodeSide == Side.Left)
                {
                    node.ParentNode.LeftNode = node.LeftNode;
                }
                else
                {
                    node.ParentNode.RightNode = node.LeftNode;
                }
                node.LeftNode.ParentNode = node.ParentNode;
            }
            //if there is both sub nodes the right node is put on deleted place and put the left on the place of right node
            else
            {
                switch (currentNodeSide)
                {
                    case Side.Left:
                        {
                            node.ParentNode.LeftNode = node.RightNode;
                            node.RightNode.ParentNode = node.ParentNode;
                            Add(node.LeftNode, node.RightNode);
                            break;
                        }
                    case Side.Right:
                        {
                            node.ParentNode.RightNode = node.RightNode;
                            node.RightNode.ParentNode = node.ParentNode;
                            Add(node.LeftNode, node.RightNode);
                            break;
                        }
                    default:
                        {
                            var bufLeft = node.LeftNode;
                            var bufRightLeft = node.RightNode.LeftNode;
                            var bufRightRight = node.RightNode.RightNode;
                            node.Data = node.RightNode.Data;
                            node.RightNode = bufRightRight;
                            node.LeftNode = bufRightLeft;
                            Add(bufLeft, node);
                            break;
                        }
                }
            }
        }

        //overloads the Remove to encapsulate the method
        public void Remove(T data)
        {
            var foundData = FindNode(data);
            Remove(foundData);
        }

        #endregion

        #region Max Methods
        private T GetMaxValue(BinaryTreeNode<T> startNode)
        {
            //goes to the rightNode till we have null, if there is null then we got our max value
            if (startNode.RightNode != null)
            {
                return GetMaxValue(startNode.RightNode);
            }
            else
            {
                return startNode.Data;
            }
        }

        public T GetMaxValue()
        {
            return GetMaxValue(RootNode);
        }
        #endregion

        #region Min Methods
        private T GetMinValue(BinaryTreeNode<T> startNode)
        {
            //goes to the LeftNode until the node isn't a null, if the node is a null then we got our max value
            if (startNode.LeftNode != null)
            {
                return GetMinValue(startNode.LeftNode);
            }
            else
            {
                return startNode.Data;
            }
        }

        public T GetMinValue()
        {
            return GetMinValue(RootNode);
        }

        #endregion

        #region Sort Method
        public T[] Sort()
        {
            return RootNode.Transform();
        }
        #endregion

        #region Reverse Method
        public T[] Reverse()
        {
            return RootNode.ReverseTransform();
        }
        #endregion

        #region Max Level Methods
        private int GetMaxLevel(BinaryTreeNode<T> node)
        {
            if (node == null)
            {
                return 0;
            }
            //defines which node is larger and returns the max level
            return Math.Max(GetMaxLevel(node.LeftNode), GetMaxLevel(node.RightNode)) + 1;
        }

        public int GetMaxLevel()
        {
            return GetMaxLevel(RootNode);
        }

        #endregion

        #region Print Node Vertical

        //the method makes primary initialization for further tree print
        private void PrintNode(BinaryTreeNode<T> root)
        {
            int maxLevel = GetMaxLevel(root);

            SingletonList<BinaryTreeNode<T>> singletonList = new SingletonList<BinaryTreeNode<T>>(root);

            PrintNodeInternal(singletonList, 1, maxLevel);
        }

        private void PrintNode()
        {
            PrintNode(RootNode);
        }


        private void PrintNodeInternal(IList<BinaryTreeNode<T>> nodes, int level, int maxLevel)
        {
            //the breakpoint, we'll do it till it doesn't true
            if (nodes == null || IsAllElementsNull(nodes))
            {
                return;
            }

            int floor = maxLevel - level;
            int edgeLines = (int)Math.Pow(2, (Math.Max(floor - 1, 0)));
            int firstSpaces = (int)Math.Pow(2, (floor)) - 1;
            int betweenSpaces = (int)Math.Pow(2, (floor + 1)) - 1;

            PrintWhiteSpaces(firstSpaces);

            //adds new list of nodes to hold left and right nodes
            //if there is no null in node then print node.Data and add left and right nodes
            //if there is null then add null to instead of left and right and print empty space
            List<BinaryTreeNode<T>> newNodes = new List<BinaryTreeNode<T>>();
            foreach (var node in nodes)
            {
                if (node != null)
                {
                    Write(node.Data);
                    newNodes.Add(node.LeftNode);
                    newNodes.Add(node.RightNode);
                }
                else
                {
                    newNodes.Add(null);
                    newNodes.Add(null);
                    Write(" ");
                }

                PrintWhiteSpaces(betweenSpaces);
            }

            WriteLine();

            //prints branches
            for (int i = 1; i <= edgeLines; i++)
            {
                for (int j = 0; j < nodes.Count; j++)
                {
                    PrintWhiteSpaces(firstSpaces - i);
                    if (nodes[j] == null)
                    {
                        PrintWhiteSpaces(edgeLines + edgeLines + i + 1);
                        continue;
                    }

                    if (nodes[j].LeftNode != null)
                        Write("/");

                    else
                        PrintWhiteSpaces(1);

                    PrintWhiteSpaces(i + i - 1);


                    if (nodes[j].RightNode != null)
                        Write("\\");

                    else
                        PrintWhiteSpaces(1);

                    PrintWhiteSpaces(edgeLines + edgeLines - i);

                }

                WriteLine();
            }

            //recursively goes to previously added left and right nodes
            PrintNodeInternal(newNodes, level + 1, maxLevel);

        }

        //prints a given amount of white spaces
        private void PrintWhiteSpaces(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Write(" ");
            }
        }

        //checks is there any nodes 
        private bool IsAllElementsNull(IList<BinaryTreeNode<T>> list)
        {
            foreach (var obj in list)
            {
                if (obj != null)
                    return false;
            }

            return true;
        }

        #endregion

        #region Print Methods

        private void Print(BinaryTreeNode<T> node, int space)
        {
            if (node == null)
            {
                return;
            }

            space += Count;

            //prints right branch of a tree
            Print(node.RightNode, space);

            //goes to the next line and prints white spaces then prints node.Data
            for (int i = Count; i < space; i++)
            {
                Write(" ");

            }
            Write(node.Data + "\n");

            //prints left branch of a tree
            Print(node.LeftNode, space);
        }

        public void Print()
        {
            WriteLine(new string('-', Count * GetMaxLevel()));
            PrintNode();
            WriteLine(new string('-', Count * GetMaxLevel()));
        }
        #endregion
    }

}
