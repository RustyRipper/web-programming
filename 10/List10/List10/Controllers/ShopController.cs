using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List10.Data;
using List10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace List10.Controllers
{
    public class ShopController : Controller
    {
        private readonly MyDbContext _context;
        public ShopController(MyDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult List([Bind("Id")] Category category)
        {
            var myDbContext = _context.Article.Include(a => a.Category).Where(a => a.CategoryId == category.Id);
            ViewData["Category"] = category.Id;
            return View(myDbContext);
        }
    }
}
