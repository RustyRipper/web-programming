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

namespace List12.Pages.Categories
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
        public Category Category { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);

            if (Category == null)
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

            var articleList = _context.Article
                       .Where(a => a.CategoryId == id)
                       .ToList();

            foreach (Article article in articleList)
            {
                if (article.FilePath != null)
                {
                    string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload");
                    string filePath = Path.Combine(uploadFolder, article.FilePath);

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
                        article.FilePath = null;
                        article.FormFile = null;
                        _context.Article.Remove(article);
                    }
                }
                else
                {
                    _context.Article.Remove(article);
                }
            }


            Category = await _context.Category.FindAsync(id);

            if (Category != null)
            {
                _context.Category.Remove(Category);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
