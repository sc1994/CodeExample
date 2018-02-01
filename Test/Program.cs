using System;
using System.Reflection;
using Business;

namespace Test
{
	class Program
	{
		static void Main(string[] args)
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();
			foreach (var ass in assemblies)
			{
				Console.WriteLine(ass.FullName);
			}
			Console.ReadLine();
		}
	}
}
