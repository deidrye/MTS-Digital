using System;
using System.Collections.Generic;
using System.Linq;

public static class EnumFromTail
{
    public static IEnumerable<(T item, int? tail)> EnumerateFromTail<T>(this IEnumerable<T> enumerable, int? tailLength)
    {
        int seqLength = enumerable.Count(), tail = tailLength.Value, i = 0;     
        if (seqLength < tail) tail = seqLength;                                 // если количество элементов, которые нужно отсчитать с конца,
                                                                                // превышает количество элементов в последовательности,
                                                                                // это равносильно полному подсчёту.
        int j = tail - 1;
        foreach (var item in enumerable)
        {
            if (seqLength > i + tail) yield return (item, null); else yield return (item, j--);
            i++;
        }
    }

    static void Main(string[] args)
    {
        IEnumerable<int> example = new[] { 1, 2, 3, 4, 5 };

        var tailLength = 2;
        foreach (var item in example.EnumerateFromTail(tailLength))
        {
            Console.WriteLine(item);
        }

    }
}
