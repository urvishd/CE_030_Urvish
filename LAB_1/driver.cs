using System;
using addition;
namespace Test
{
	public class driver_prog
	{
		public static void Main(string[] args)
		{
			int ans;
			Console.Write("Enter a number: ");
			int n1= Convert.ToInt32(Console.ReadLine());
			Console.Write("Enter another number: ");
			int n2= Convert.ToInt32(Console.ReadLine());
			ans=add1.Sum(n1,n2);
			//Console.WriteLine(30);
			Console.WriteLine(ans);
			Console.ReadLine();
		}
	}
}