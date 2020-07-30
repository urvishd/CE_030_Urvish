using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.WriteLine("Enter the First number:");
            x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Second number:");
            y = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(x+y);
            Console.ReadKey();

        }
    }
}
