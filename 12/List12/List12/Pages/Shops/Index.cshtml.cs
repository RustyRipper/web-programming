using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using List10.Data;
using List10.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace List12.Pages.Shops
{
    public class IndexModel : PageModel
    {
        private readonly List10.Data.MyDbContext _context;

        public IndexModel(List10.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; }

        public async Task OnGetAsync() { 

            Category = await _context.Category.ToListAsync();
        }
    }
}
