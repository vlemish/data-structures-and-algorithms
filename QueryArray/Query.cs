using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    class Query<T> where T : IComparable
    {
        private T[] queries;

        private int index;


        public Query()
        {
            queries = new T[100];
            index = 0;
        }


        public T Dequeue()
        {
            T toRemove = default(T);
            try
            {
                toRemove = queries[0];
            }
            catch (Exception) { Console.WriteLine("Unable to delete element from Queue! There is no elements in the query!"); }
            Rebuild();
            return toRemove;
        }

        public void Enqueue(T data)
        {
            if (queries.Length - 1 == index)
            {
                queries = ChangeSize(queries);
            }

            queries[index] = data;
            index++;
        }

        public T Peek()
        {
            return queries[0];
        }

        private T[] ChangeSize(T[] array)
        {
            T[] newArray = new T[array.Length * 2];

            for (int i = 0; i < array.Length; i++)
            {
                newArray[i] = array[i];
            }

            return newArray;
        }

        private void Rebuild()
        {
            for (int i = 1; i < index; i++)
            {
                queries[i - 1] = queries[i];
            }
        }

        public int QuerySize { get { return queries.Length; } }
    }
}
