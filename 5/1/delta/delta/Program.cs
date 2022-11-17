using System;
using System.Collections.Generic;

namespace delta
{
	class Program
	{
		public static double a, b, c;
		
		public int numbers = 5;

		public void GetParams()
		{
			Console.WriteLine("Podaj współczynniki równania kwadratowego \n");
			Console.WriteLine("a: \n");
			a = System.Double.Parse(Console.ReadLine());
			Console.WriteLine("b: \n");
			b = System.Double.Parse(Console.ReadLine());
			Console.WriteLine("c: \n");
			c = System.Double.Parse(Console.ReadLine());
		}
		public List<double> GetSolutions(double a, double b, double c)
		{

			List<double> solutions = new List<double>();
			if (a == 0)
			{
				if (b != 0) 
					solutions.Add(-c / b);
                else
                {
					if (c == 0) {
						solutions.Add(0);
						solutions.Add(0);
						solutions.Add(0);
					}
                }
			}
			else {
				
				double delta = (b * b) - 4 * a * c;

				if (delta == 0)
				{
					solutions.Add(-b / (2 * a));
				}
				else if (delta > 0)
				{
					solutions.Add((-b - Math.Sqrt(delta)) / (2 * a));
					solutions.Add((-b + Math.Sqrt(delta)) / (2 * a));
				}
			}
			return solutions;
		}

		public static double RoundToSignificantDigits(double d, int digits)
		{
			if (d == 0)
				return 0;

			double scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(d))) + 1);
			return scale * Math.Round(d / scale, digits);
		}

		static void Main(string[] args)
		{
			Program p = new Program();
			p.GetParams();
			Console.WriteLine(a + " " + b + " " + c);

			List<double> solutions = p.GetSolutions(a, b, c);


			List<double> results = new List<double>();
			foreach (double item in solutions) {
				results.Add(RoundToSignificantDigits(item, p.numbers));
			}

			if (results.Count == 2)
			{
				Console.WriteLine($"x1 = {results[0]} \nx2 = {results[1]}");
			}
			else if (results.Count == 1) {
				Console.WriteLine("x = {0}", results[0]);
			}
			else if (results.Count == 3)
			{
				Console.WriteLine("Nieskoczenie wiele rozw");
			}
			else  
			{
				Console.WriteLine("Brak rozw");
			}
			
		}
	}
}
