using BinaryTreeApp;
using System;

namespace binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[]
            {
                9,5,4,1,8,7,6
            };

            var tree = new BinaryTree<int>();

            foreach (var i in array)
            {
                tree.Add(i);
            }

            tree.Print();

            var sortedArray = tree.Sort();
            var reversedArray = tree.Reverse();
            var maxValue = tree.GetMaxValue();
            var minValue = tree.GetMinValue();

            Console.WriteLine("Sorted array: " + string.Join(" ", sortedArray));
            Console.WriteLine("Reversesd array: " + string.Join(" ", reversedArray));
            Console.WriteLine("Max value: " + maxValue);
            Console.WriteLine("Min value: " + minValue);

            Console.ReadLine();
        }
    }
}
