using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTSim
{
    public class JQueue<T>
    {
        private int capacity;
        private List<T> items = new List<T>();

        public JQueue(int capacity) 
        {
            this.capacity = capacity;
        }

        public T this[int i]
        {
            get { return items[items.Count - i - 1]; }
            set { items[items.Count - i - 1] = value; }
        }

        public T Push(T item)
        {
            items.Add(item);
            if (items.Count <= capacity)
                return default(T);
            else
            {
                T returnItem = items[0];
                items.RemoveAt(0);
                return returnItem;
            } 
        }

        public void Clear()
        {
            items.Clear();
        }

        public int Count()
        {
            return items.Count;
        }
    }
}
