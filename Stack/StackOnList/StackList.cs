using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackDataStructure
{
    public class StackList<T> where T:IComparable
    {
        List<T> elements;

        public delegate void ShowHandler(T element);

        public event ShowHandler Show;
        
        public int Count { get { return elements.Count; } }

        public StackList()
        {
            elements = new List<T>(); 
        }

        public void Push(T element)=> elements.Insert(0, element);

        public T Pop()
        {
            if (elements.Count > 0)
            {
                T toReturn = elements.FirstOrDefault();
                int toDelete = elements.IndexOf(toReturn);
                elements.RemoveAt(toDelete);
                return toReturn;
            }

            throw new Exception("There are no elements in the Stack");
        }

        public T Peek()
        {
            
            return elements.Count>0 ? elements.First() : throw new Exception("There are no elements in the Stack");
        }

        public void Print()
        {
            foreach(var i in elements)
            {
                Show(i);
            }
        }

        public void Clear()
        {
            elements.Clear();
            Console.Beep();
            Console.WriteLine("The Stack Is Empty!");
        }
    }
}
