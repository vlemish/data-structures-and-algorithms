using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Diagnostics;
using System.Windows.Media.TextFormatting;

namespace StackDataStructure
{
    class StackArray<T> where T:IComparable
    {
        private T[] elements;

        private int maxSize=100;

        private int currentSize=0;

        public int Count { get { return currentSize; } }

        public StackArray()
        {
            elements = new T[maxSize];
        }

        public void Push(T element)
        {
            if (currentSize == 0)
            {
                elements[currentSize] = element;
                currentSize++;
            }

            if (currentSize == maxSize)
            {
                RebuildData();
            }

            currentSize++;
            elements[currentSize-1] = element;
        }

        public T Pop()
        {
            T toPop = Peek();
            currentSize--;
            return toPop;
        }
        
        public T Peek()
        {
            if (currentSize == 0)
            {
                throw new Exception("Stack is empty!");
            }
            return elements[currentSize-1];
        }

        public void Clear()
        {
            for (int i = 0; i < currentSize; i++)
            {
                elements[i] = default;
            }
            currentSize = 0;
        }

        private void RebuildData()
        {
            var newData = new T[maxSize];
            for (var i = 1; i < elements.Length; i++)
            {
                newData[i - 1] = elements[i];
            }

            elements = newData;
            currentSize = maxSize - 1;
        }

        public void Print()
        {
            if (elements is int[])
            {
                Console.WriteLine(new string('-', currentSize));

                for (int i = currentSize - 1; i >= 0; i--)
                {
                    int size = currentSize - elements[i].ToString().Length;

                    Console.WriteLine($"{elements[i]} {new string(' ', size)}|");
                }

                Console.WriteLine(new string('-', currentSize));
            }

            else
            {
                for (int i = currentSize - 1; i > 0; i--)
                {
                    Console.WriteLine(elements[i]);
                }

            }
        }

    }
}
