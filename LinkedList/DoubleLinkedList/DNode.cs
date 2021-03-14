using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList
{
    class DNode<T> where T : IComparable
    {
        public DNode<T> Next { get; set; }

        public DNode<T> Previous { get; set; }

        public T Data { get; set; }


        public DNode(T data)
        {
            this.Data = data;
        }


        public override string ToString()
        {
            return $"{Data}";
        }
    }
}
