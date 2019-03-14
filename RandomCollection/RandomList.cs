using System;
using System.Collections.Generic;

namespace RandomCollection
{
    class RandomList<T>
    {
        private List<T> elements;
        private Random random = new Random();
        public void Add(T element)
        {
            if (random.NextDouble() > 0.5)
            {
                elements.Add(element);
            }
            else
            {
                elements.Insert(0, element);
            }
        }

        public T Get(int index)
        {
            return elements[random.Next(index)];
        }

        public bool IsEmpty()
        {
            return elements.Count == 0;
        }
    }
}
