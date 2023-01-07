using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using List10.Data;
using List10.Models;

namespace List12.Pages.Shops
{
    public class ListModel : PageModel
    {
        private readonly List10.Data.MyDbContext _context;

        public ListModel(List10.Data.MyDbContext context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }
        public IList<Article> Article { get;set; }
        public Category Category { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            if(Id == null)
            {
                return NotFound();
            }
            Category = await _context.Category.FirstOrDefaultAsync(m => m.Id == Id);
            Article = await _context.Article
                .Include(a => a.Category).Where(a => a.CategoryId == Category.Id).ToListAsync();
            
            ViewData["Category"] = Category.Name;
            return Page();
        }
    }
}
