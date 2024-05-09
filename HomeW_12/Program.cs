using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Завдання 1: Генерацiя та збереження простих чисел та чисел Фiбоначчі");
        GenerateAndSaveNumbers();

        Console.WriteLine("\nЗавдання 2: Пошук та замiна слова у файлi");
        SearchAndReplaceWord();
    }

    static void GenerateAndSaveNumbers()
    {
        List<int> primeNumbers = new List<int>();
        List<int> fibonacciNumbers = new List<int>();

        for (int i = 2; i <= 100; i++)
        {
            if (IsPrime(i))
                primeNumbers.Add(i);

            if (IsFibonacci(i))
                fibonacciNumbers.Add(i);
        }

        string primeFilePath = "prime_numbers.txt";
        SaveNumbersToFile(primeNumbers, primeFilePath, "Простi числа");

        string fibonacciFilePath = "fibonacci_numbers.txt";
        SaveNumbersToFile(fibonacciNumbers, fibonacciFilePath, "Числа Фiбоначчi");

        Console.WriteLine($"Простi числа збережено у файл {primeFilePath}.");
        Console.WriteLine($"Числа Фiбоначчi збережено у файл {fibonacciFilePath}.");
    }

    static void SaveNumbersToFile(List<int> numbers, string filePath, string description)
    {
        StreamWriter writer = new StreamWriter(filePath);
        foreach (int number in numbers)
        {
            writer.WriteLine(number);
        }
        writer.Close();
        Console.WriteLine($"{description} збережено у файл {filePath}.");
    }

    static bool IsPrime(int number)
    {
        if (number <= 1)
            return false;
        if (number <= 3)
            return true;
        if (number % 2 == 0 || number % 3 == 0)
            return false;

        for (int i = 5; i * i <= number; i += 6)
        {
            if (number % i == 0 || number % (i + 2) == 0)
                return false;
        }
        return true;
    }

    static bool IsFibonacci(int number)
    {
        double sqrt5 = Math.Sqrt(5);
        double phi = (1 + sqrt5) / 2;

        int fibIndex = (int)Math.Round(Math.Log(number * sqrt5) / Math.Log(phi));
        int fibNumber = (int)(Math.Pow(phi, fibIndex) / sqrt5 + 0.5);

        return fibNumber == number;
    }

    static void SearchAndReplaceWord()
    {
        Console.WriteLine("Введiть слово для пошуку у файлi:");
        string searchWord = Console.ReadLine();

        Console.WriteLine("Введiть слово для замiни:");
        string replaceWord = Console.ReadLine();

        Console.WriteLine("Введiть шлях до файлу:");
        string filePath = Console.ReadLine();

        if (File.Exists(filePath))
        {
            string content = File.ReadAllText(filePath);
            content = content.Replace(searchWord, replaceWord);
            File.WriteAllText(filePath, content);

            Console.WriteLine($"Усi входження слова '{searchWord}' було замінено на '{replaceWord}'.");
        }
        else
        {
            Console.WriteLine("Файл не iснує.");
        }
    }
}
