using Microsoft.AspNetCore.Http;
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

        //public static int randValue { get; set; } = 0;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Set(int n)
        {
            //max = n;
            HttpContext.Session.SetInt32("max", n);
            ViewBag.Min = ""+min;
            ViewBag.Max = "" + n;
            return View("Set");
        }
        public IActionResult Guess(int x)
        {
            int counter = (int)HttpContext.Session.GetInt32("counter");
            counter++;
            int randValue = (int)HttpContext.Session.GetInt32("randValue");
            HttpContext.Session.SetInt32("counter", counter);
            ViewBag.Counter = counter;
            ViewBag.X = x;
            ViewBag.Min = "" + min;
            int max = (int)HttpContext.Session.GetInt32("max");
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
            }
            
            return View("Guess");
        }
        public IActionResult Draw()
        {
            int randValue = random.Next(min, (int)HttpContext.Session.GetInt32("max"));
            HttpContext.Session.SetInt32("randValue", randValue);
            HttpContext.Session.SetInt32("counter", 0);
            ViewBag.Min = "" + min;
            ViewBag.Max = "" + (int)HttpContext.Session.GetInt32("max");
            return View("Draw");
        }
    }
}
