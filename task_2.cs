using System;

namespace oaip.pract2
{ 
    public class DynamicContainer<T>
    {
        private T[] data;
        private int quantity;
        private int capacity;

        public DynamicContainer(int initialCapacity = 4)
        {
            capacity = initialCapacity;
            quantity = 0;
            data = new T[capacity];

            Console.WriteLine($"Создан контейнер на {capacity} элементов1");

        }
    }
}
