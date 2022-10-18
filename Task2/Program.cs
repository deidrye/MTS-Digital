using System;
using System.Globalization;

class Program
{
    static readonly IFormatProvider _ifp = CultureInfo.InvariantCulture;

    class Number
    {
        readonly int _number;

        public Number(int number)
        {
            _number = number;
        }

        //
        // задаём определение оператору +
        public static string operator +(Number x, string y)   
        {

            var yInt = Int32.Parse(y);                      // строковое описание значения someValue2 переводим в Int
            return (x._number + yInt).ToString(_ifp);       // возвращаем в String сумму чисел
        }

        public override string ToString()
        {
            return _number.ToString(_ifp);
        }
    }

    static void Main(string[] args)
    {
        int someValue1 = 10;
        int someValue2 = 5;

        string result = new Number(someValue1) + someValue2.ToString(_ifp);
        Console.WriteLine(result);
        Console.ReadKey();
    }
}
