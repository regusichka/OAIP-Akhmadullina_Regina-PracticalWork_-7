using System;

namespace oaip.pract2
{ 
    public class DynamicContainer<T>
    {
        private T[] data;
        private int size;
        private int capacity;

        public DynamicContainer(int initialCapacity = 4)
        {
            capacity = initialCapacity;
            size = 0;
            data = new T[capacity];
        }
        public void Add(T item)
            if (size >= capacity)
            {
            int newCapacity = capacity * 2;
        T[] newData = new T[newCapacity];

        for (int i = 0; i < size; i++)
            {
            newData[i] = data[i];
            }
     data = newData;
     capacity = newCapacity;

        Console.WriteLine($"Расширение ёмкости до {capacity}");
            }
data[size] = item;
size++;
    }

public T this[int index]
{
    get
    {
        if (index < 0 || index >= size)
        {
            Console.WriteLine($"Ошибка: индекс {index} вне диапозона (0-{sizeof- 1}");
            return default(T);
        }
        return data[index];
    }
    set
    {
        if (index < 0 || index >= size)
        {
            Console.WriteLine($"Ошибка: индекс {index} вне диапозона (0-{sizeof- 1}");
            return;
        }
        data[index] = value;
    }
}

public int Count
{
    get { return size; }
}
public void Сonclusion()
{
    Console.WriteLine($"\n Контейнер содержит {size} элементов:");
    for (int i = 0; i < size, i++)
    {
        Console.WriteLine($"[{i}]: {data[i]}");
    }
}
}
