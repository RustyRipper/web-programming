using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace List8.Controllers
{
    public class ToolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
		public static List<double> GetSolutions(double a, double b, double c)
		{

			List<double> solutions = new List<double>();
			if (a == 0)
			{
				if (b != 0)
					solutions.Add(-c / b);
				else
				{
					if (c == 0)
					{
						solutions.Add(0);
						solutions.Add(0);
						solutions.Add(0);
					}
				}
			}
			else
			{
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

		public IActionResult Solve(double a, double b, double c)
		{

			List<double> solutions = GetSolutions(a, b, c);


			List<double> results = new List<double>();
			foreach (double item in solutions)
			{
				results.Add(RoundToSignificantDigits(item, 5));
			}

			if (results.Count == 2)
			{
				ViewBag.Message = $"x1 = {results[0]} x2 = {results[1]}";
				ViewBag.type = "two";
			}
			else if (results.Count == 1)
			{
				ViewBag.Message = $"x = {results[0]}";
				ViewBag.type = "one";
			}
			else if (results.Count == 3)
			{
				ViewBag.Message = "Nieskoczenie wiele rozw";
				ViewBag.type = "multi";
			}
			else
			{
				ViewBag.Message = "Brak rozw";
				ViewBag.type = "zero";
			}

			return View("Solve");

		}
	}
}
