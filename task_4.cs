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

        Console.WriteLine("\n Проверка элементов");
        Console.WriteLine($"Элемент с индексом 0: {numbers[0]}");
        Console.WriteLine($"Элемент с индексом 500: {numbers[500]}");
        Console.WriteLine($"Элемент с индексом 999: {numbers[999]}");

        Console.WriteLine($"\nВсего элементов в контейнере: {numbers.Count}");
    }
}
