using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4_Lab7_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            for(int i=0;i<100;i++)
            {
                numbers.Add(i + 1);
            }

            var op1 = numbers.Where(n => n % 2 == 0);
            Console.WriteLine("Even numbers:");
            foreach (var s1 in op1)
            {
                Console.Write(s1 + " ");
            }

            var op2= numbers.Where(n => n % 2 != 0);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Odd numbers:");
            foreach (var s2 in op2)
            {
                Console.Write(s2 + " ");
            }

            int sum = 0;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("All numbers:");
            foreach (var s3 in numbers)
            {
                sum += s3;
                Console.Write(s3 + " ");
            }

            double avg = sum / 100;
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Average: "+avg);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Minimum number is: " + numbers.Min());

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Maximum number is: " + numbers.Max());
        }
    }
}
