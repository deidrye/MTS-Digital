using System;
using System.IO;


class Program
{
    static void Main(string[] args)
    {
        TransformToElephant();
        Console.Out.WriteLine("Муха");

        //... custom application code
        int i = -7 + 8;
        Console.Write(i + "-ая ");
        Console.Out.WriteLine("Муха");
    }

    static void TransformToElephant()
    {
        Console.WriteLine("Слон");
        Console.SetOut(new AbstractOut());          // следующая консольная запись будет перенаправлена в абстрактный поток
    }

    class AbstractOut : StringWriter
    {
        TextWriter AConsole;

        public AbstractOut()
        {
            AConsole = Console.Out;
        }

        public override void WriteLine(string value)        // отменяем вывод в консоль
        {
            Console.SetOut(AConsole);
        }
    }

}

