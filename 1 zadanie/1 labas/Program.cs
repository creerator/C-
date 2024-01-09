using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите количество элементов массива N:");

        int n;

        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Ошибка! Введите корректное положительное число.");
        }

        Console.WriteLine("Введите нижнюю границу диапазона A:");
        double a;
        while (!double.TryParse(Console.ReadLine(), out a))
        {
            Console.WriteLine("Ошибка! Введите корректное число.");
        }

        Console.WriteLine("Введите верхнюю границу диапазона B:");
        double b;
        while (!double.TryParse(Console.ReadLine(), out b))
        {
            Console.WriteLine("Ошибка! Введите корректное число.");
        }

        double[] array = new double[n];
        Random random = new Random();

        int lim = 1000;
        for (int i = 0; i < n; i++)
        {
            array[i] = random.NextDouble() * 2 * lim - lim; // -lim < x < lim
        }

        int countInRange = CountElementsInRange(array, a, b);
        Console.WriteLine($"Количество элементов в диапазоне от {a} до {b}: {countInRange}");

        double sumAfterMax = SumAfterMaxElement(array);
        Console.WriteLine($"Сумма элементов массива после максимального: {sumAfterMax}");

        Console.WriteLine("Массив с элементами, упорядоченными по убыванию модулей:");
        OrderByDescendingAbs(ref array);
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }

    static int CountElementsInRange(double[] array, double a, double b)
    {
        int count = 0;
        foreach (double element in array)
        {
            if (element >= a && element <= b)
            {
                count++;
            }
        }
        return count;
    }

    static double SumAfterMaxElement(double[] array)
    {
        double maxElement = double.MinValue;
        int maxIndex = -1;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxElement)
            {
                maxElement = array[i];
                maxIndex = i;
            }
        }

        double sum = 0;
        for (int i = maxIndex + 1; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }

    static void OrderByDescendingAbs(ref double[] array)
    {
        Array.Sort(array, (x, y) => y.CompareTo(x));
        Array.Sort(array, (x, y) => Math.Abs(y).CompareTo(Math.Abs(x)));
    }
}