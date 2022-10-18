using System;
using System.Collections.Generic;



class Program
{
    static void Main(string[] args)
    {
        List<int> example1 = new List<int> { 2, 8, 7, 5, 14, 11, 10, 5, 4, 3, 2, 1, 2 };
        List<int> example2 = new List<int> { 25, 1, 22, 14, 14, 15, 8, 61, 3, 11, 9, 7, 1, 28 };
        List<int> example3 = new List<int> { 2, 8, 7, 5, 14, 11, 10, 5, 4, 3, 2, 1, 2 };

        int maxValue = 15;                           // значения выше указанного не попадут в результат сортировки


        int sortFactor = maxValue;                   // для полной сортировки массива устанавливаем максимальное значение

        var sorted1 = Sort(example1, sortFactor, maxValue);
        var sorted2 = Sort(example2, sortFactor, maxValue);

        sortFactor = 0;                              // для минимальной - минимальное

        var sorted3 = Sort(example3, sortFactor, maxValue);

        if (sortFactor < 0 || maxValue > 2000 || maxValue < 0)
        {

            if (sortFactor < 0) Console.WriteLine("===| Значение sortFactor меньше 0 |===");
            if (maxValue > 2000) Console.WriteLine("===| Значение maxValue больше 2000 |===");
            if (maxValue < 0) Console.WriteLine("===| Значение maxValue меньше 0 |===");

            Environment.Exit(-1);
        }

        Console.WriteLine("Example 1 original: ");
        foreach (var item in example1) Console.Write(item + " ");
        Console.WriteLine("\nsorted: ");
        foreach (var item in sorted1) Console.Write(item + " ");

        Console.WriteLine("\nExample 2 original:");
        foreach (var item in example2) Console.Write(item + " ");
        Console.WriteLine("\nsorted: ");
        foreach (var item in sorted2) Console.Write(item + " ");

        Console.WriteLine("\nExample 3 original:");
        foreach (var item in example3) Console.Write(item + " ");
        Console.WriteLine("\nsorted: ");
        foreach (var item in sorted3) Console.Write(item + " ");



    }

    static IEnumerable<int> Sort(IEnumerable<int> inputStream, int sortFactor, int maxValue)
    {
        var acc = new int[maxValue + 1];            // создаем буферизацию значений
        
        int min = 0;

        foreach (int item in inputStream)
        {

            if (item > maxValue) continue;          // если хотим получать отсортированный поток со всеми значениями,
                                                    // не превышающими maxValue.
                                                    //
                                                    // если должно выдавать ошибку, используем "yield break"

            else
            {
                acc[item]++;
                int max = item - sortFactor;       // учитываем фактор упорядоченности потока

                while (min < max)
                {

                    while (acc[min]-- > 0)         // если в потоке встретилось число max, то в нём больше не встретятся числа меньше, чем (max - sortFactor)
                        yield return min;
                    min++;
                }
               
            }
        }
        
        while (min < acc.Length)
        {
            while (acc[min]-- > 0)
                yield return min;
            min++;
        }
        
    }

}