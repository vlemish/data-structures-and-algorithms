using System;
using System.Collections.Generic;

namespace BinaryTreeApp
{
    interface IBinaryTreePrint<T> where T : IComparable
    {
        void PrintNode(BinaryTreeNode<T> root);

        void PrintNodeInternal(SingletonList<BinaryTreeNode<T>> nodes, int level, int maxLevel);

        void PrintWhiteSpaces(int count);

        bool IsAllElementsNull(List<T> list);

    }
}
