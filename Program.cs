using System;
using System.IO;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";
        File.Create(@".\input.txt").Close();
        File.Create(@".\output.txt").Close();

        Random random = new Random();
        using (StreamWriter writer = new StreamWriter(inputFile))
        {
            for (int i = 0; i < 20; i++)
            {
                int randomNumber = random.Next(-100, 101);
                writer.WriteLine(randomNumber);
            }
        }

        int[] numbers = File.ReadAllLines(inputFile).Select(int.Parse).ToArray();

        int minNumber = numbers.Min();
        int minSquare = minNumber * minNumber;

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    writer.WriteLine(minSquare);
                }
                else
                {
                    writer.WriteLine(number);
                }
            }
        }

        Console.WriteLine("Файлы успешно созданы и обработаны.");
        Console.WriteLine($"Входной файл: {inputFile}");
        Console.WriteLine($"Выходной файл: {outputFile}");
    }
}