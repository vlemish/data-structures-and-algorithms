using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class Node<T> where T:IComparable
    {
        public Node<T> Next { get; set; }

        public T Data { get; }


        public Node(T data)
        {
            this.Data = data;
        }


        public override string ToString()
        {
            return $"{Data}";
        }
    }
}
