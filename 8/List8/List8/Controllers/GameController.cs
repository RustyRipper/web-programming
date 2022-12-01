using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace List8.Controllers
{
    public class GameController : Controller
    {
  
        private static readonly Random random = new Random();
        public static int min { get; set; } = 0;
        public static int max { get; set; } = 10;
        public static int counter { get; set; } = 0;
        public static int randValue { get; set; } = random.Next(min, max);

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Set(int n)
        {
            max = n;
            ViewBag.Min = ""+min;
            ViewBag.Max = "" + max;
            return View("Set");
        }
        public IActionResult Guess(int x)
        {
            counter++;
            ViewBag.Counter = counter;
            ViewBag.X = x;
            ViewBag.Min = "" + min;
            ViewBag.Max = "" + max;
            if (x < min)
            {
                ViewBag.Message = "Ponizej minimum";
                ViewBag.type = "zero";
            }
            else if (x > max)
            {
                ViewBag.Message = "Powyzej maximum";
                ViewBag.type = "zero";
            }
            else if (x > randValue)
            {
                ViewBag.Message = "Powyzej szukanej";
                ViewBag.type = "multi";
            }
            else if (x < randValue)
            {
                ViewBag.Message = "Ponizej szukanej";
                ViewBag.type = "two";
            }
            else if (x == randValue)
            {
                ViewBag.Message = "Zgadles";
                ViewBag.type = "one";
                counter = 0;
            }
            
            return View("Guess");
        }
        public IActionResult Draw()
        {
            randValue = random.Next(min, max);
            ViewBag.Min = "" + min;
            ViewBag.Max = "" + max;
            return View("Draw");
        }
    }
}
