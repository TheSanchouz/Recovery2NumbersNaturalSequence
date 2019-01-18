using System;
using System.Linq;

namespace Recovery2NumbersNaturalSequence
{
    class Program
    {
        static int Factrorial(int num)
        {
            int fact = 1;
            while (num > 0)
            {
                fact *= num--;
            }
            
            return fact;
        }
        static bool NonRepeating(ref int[] sequence)
        {
            for (int i = 0; i < sequence.Length; i++)
            {
                for (int j = i + 1; j < sequence.Length; j++)
                {
                    if (sequence[i] == sequence[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        static (int, int) Recovery2NumbersNaturalSequence(ref int[] sequence, ref int n)
        {
            int partialSum = 0;
            int partialProduct = 1;
            foreach (int number in sequence)
            {
                partialSum += number;
                partialProduct *= number;
            }

            int totalSum = n * (n + 1) / 2;
            int totalProduct = Factrorial(n);

            int x, y;
            x = ((totalSum - partialSum) - 
                (int)Math.Sqrt((totalSum - partialSum) * (totalSum - partialSum) - 4 * totalProduct / partialProduct)) / 2;
            y = (totalSum - partialSum) - x;

            return (Math.Min(x, y), Math.Max(x, y));
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите натуральное число:");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine($"Введите уникальную последовательность натуральных чисел от 1 до {n} длины {n - 2}:");
            int[] sequence = Console.ReadLine().Split(' ').Select(number => int.Parse(number)).ToArray();

            
            if (sequence.Length != n - 2)
            {
                Console.WriteLine($"Некорректная длина последовательности, должно быть {n - 2}, а у вас {sequence.Length}");
                return;
            }
            if (!NonRepeating(ref sequence))
            {
                Console.WriteLine("Не уникальная последовательность");
                return;
            }

            (int, int) recoveryNumbers = Recovery2NumbersNaturalSequence(ref sequence, ref n);
            
            Console.WriteLine($"Пропущенные числа {recoveryNumbers.Item1} и {recoveryNumbers.Item2}");
        }
    }
}
