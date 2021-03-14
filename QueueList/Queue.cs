using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Queue<T> where T : IComparable
    {
        private List<T> queues;


        public Queue()
        {
            queues = new List<T>();
        }


        public T Dequeue()
        {
            try
            {
                T toRemove = queues.First();
                queues.Remove(toRemove);
                return toRemove;
            }
            catch (Exception) { Console.WriteLine("Unable to delete element from Queue! There is no elements in the query!"); }

            return default(T);
        }

        public void Enqueue(T data)
        {
            queues.Add(data);
        }

        public T Peek()
        {
            return queues.Count == 0 ? default(T) : queues.First();
        }
    }
}
