using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using List10.Data;
using List10.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace List12.Pages.Articles
{
    public class DeleteModel : PageModel
    {
        private readonly List10.Data.MyDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public DeleteModel(List10.Data.MyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        [BindProperty]
        public Article Article { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Article
                .Include(a => a.Category).FirstOrDefaultAsync(m => m.Id == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Article.FindAsync(id);

            if (Article != null)
            {
                if (Article.FilePath != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
                    string filePath = Path.Combine(uploadFolder, Article.FilePath);


                    if (System.IO.File.Exists(filePath))
                    {
                        try
                        {
                            System.IO.File.Delete(filePath);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Cant delete file");
                        }
                    }
                    Article.FilePath = null;
                    Article.FormFile = null;

                }
                _context.Article.Remove(Article);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
