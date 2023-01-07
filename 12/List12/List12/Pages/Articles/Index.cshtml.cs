using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using List10.Data;
using List10.Models;
using System.Globalization;

namespace List12.Pages.Articles
{
    public class IndexModel : PageModel
    {
        private readonly List10.Data.MyDbContext _context;

        public IndexModel(List10.Data.MyDbContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            Article = await _context.Article
                .Include(a => a.Category).ToListAsync();
        }
    }
}
