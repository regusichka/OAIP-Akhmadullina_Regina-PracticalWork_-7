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
    {
        if (size >= capacity)
        {
            int newCapacity = capacity * 2;
            T[] newData = new T[newCapacity];

            for (int i = 0; i < size; i++)
                newData[i] = data[i];

            data = newData;
            capacity = newCapacity;
        }

        data[size] = item;
        size++;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= size)
        {
            throw new ArgumentOutOfRangeException("index", $"Индекс {index} вне диапазона (0-{size - 1})");
        }

        for (int i = index; i < size - 1; i++)
        {
            data[i] = data[i + 1];
        }

        size--;

        data[size] = default(T);

        Console.WriteLine($"Удалён элемент с индексом {index}");
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > size)
        {
            throw new ArgumentOutOfRangeException("index", $"Индекс {index} вне диапазона (0-{size})");
        }

        if (size >= capacity)
        {
            int newCapacity = capacity * 2;
            T[] newData = new T[newCapacity];

            for (int i = 0; i < size; i++)
                newData[i] = data[i];

            data = newData;
            capacity = newCapacity;
        }

        for (int i = size; i > index; i--)
        {
            data[i] = data[i - 1];
        }

        data[index] = item;
        size++;

        Console.WriteLine($"Вставлен элемент на позицию {index}");
    }

    public T this[int index]
    {
        get
        {
            
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("index", $"Индекс {index} вне диапазона (0-{size - 1})");
            }
            return data[index];
        }
        set
        {
            if (index < 0 || index >= size)
            {
                throw new ArgumentOutOfRangeException("index", $"Индекс {index} вне диапазона (0-{size - 1})");
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
        Console.WriteLine($"\nКонтейнер содержит {size} элементов:");
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"[{i}]: {data[i]}");
        }
    }
}
static void Main(string[] args)
{
    Console.WriteLine("Проверка\n");

    DynamicContainer<int> nums = new DynamicContainer<int>();
    nums.Add(10);
    nums.Add(20);
    nums.Add(30);

    Console.WriteLine("Обращаемся к индексу 10:");
    try
    {
        Console.WriteLine(nums[10]);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка! " + ex.Message);
    }

    Console.WriteLine("\n Удаляем индекс -1:");
    try
    {
        nums.RemoveAt(-1);
    }
    catch (Exception ex)
    {
        Console.WriteLine("Ошибка! " + ex.Message);
    }
}    }
}