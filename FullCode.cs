using System;

namespace oaip.pract2
{
    public class Restaurant
    {
        public int Number;
        public string Name;
        public string Category;
        public decimal Price;
        public string Ingredients;

        public Restaurant(int number, string name, string category, decimal price, string ingredients)
        {
            Number = number;
            Name = name;
            Category = category;
            Price = price;
            Ingredients = ingredients;
        }
        public override string ToString()
        {
            return $"{Number}. {Name} ({Category}) - {Price} руб. [{Ingredients}]";
        }
    }

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
            Console.WriteLine($"Создан контейнер на {capacity} элементa");
        }

        public void Add(T item)
        {
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

        public void Conclusion()
        {
            Console.WriteLine($"\nКонтейнер содержит {size} элементов:");
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine($"[{i}]: {data[i]}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование контейнера\n");
            DynamicContainer<int> numbers = new DynamicContainer<int>();

            Console.WriteLine("\n--- Добавляем 1000 элементов ---");
            for (int i = 0; i < 1000; i++)
            {
                numbers.Add(i * 10);
            }

            Console.WriteLine("\nПроверка элементов");
            Console.WriteLine($"Элемент с индексом 0: {numbers[0]}");
            Console.WriteLine($"Элемент с индексом 500: {numbers[500]}");
            Console.WriteLine($"Элемент с индексом 999: {numbers[999]}");

            Console.WriteLine($"\nВсего элементов в контейнере: {numbers.Count}");

            Console.WriteLine("\nПроверка ошибок\n");

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

            Console.WriteLine("\nУдаляем индекс -1:");
            try
            {
                nums.RemoveAt(-1);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка! " + ex.Message);
            }

            Console.WriteLine("\nТест с блюдами:");
            DynamicContainer<Restaurant> menu = new DynamicContainer<Restaurant>();
            menu.Add(new Restaurant(1, "Борщ", "Суп", 250, "Свёкла, капуста, мясо"));
            menu.Add(new Restaurant(2, "Оливье", "Салат", 200, "Картошка, колбаса, яйца"));
            menu.Add(new Restaurant(3, "Котлета", "Горячее", 300, "Мясо, лук, специи"));
            menu.Conclusion();
        }
    }
}