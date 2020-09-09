using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp4_lab7_2
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string>();
            names.Add("Urvish");
            names.Add("Keyur");
            names.Add("Krishna");
            names.Add("Shrey");
            names.Add("Jay");
            names.Add("Moto");
            names.Add("Ankit");
            names.Add("Dhruv");
            names.Add("Ram");
            names.Add("Lakshman");

            var op1 = names.Where(n => n.StartsWith("K"));
            Console.WriteLine("Names starts with K :");
            foreach (var s1 in op1)
            {
                Console.Write(s1 + " ");
            }

            var op2 = names.Where(n => n.Length < 4);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Names whose length is less than 4:");
            foreach (var s2 in op2)
            {
                Console.Write(s2 + " ");
            }

            var op3 = names.Where(n => n.Length == 3);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Names whose length is 3:");
            foreach (var s3 in op3)
            {
                Console.Write(s3 + " ");
            }

            names.Sort();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Names in ascending order:");
            foreach (var s4 in names)
            {
                Console.Write(s4 + " ");
            }




        }
    }
}
