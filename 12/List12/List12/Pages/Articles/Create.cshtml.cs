using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using List10.Data;
using List10.Models;
using System.Globalization;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace List12.Pages.Articles
{
    public class CreateModel : PageModel
    {
        private readonly List10.Data.MyDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public CreateModel(List10.Data.MyDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public IActionResult OnGet()
        {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            ViewData["CategoryId"] = new SelectList(_context.Category, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Article.FormFile != null)
            {
                string uploadFolder = Path.Combine(_hostingEnvironment.WebRootPath, "upload");

                string newFileName = Guid.NewGuid().ToString() + "-" + Article.FormFile.FileName;
                string filePath = Path.Combine(uploadFolder, newFileName);
                FileStream fileStream = new FileStream(filePath, FileMode.Create);

                Article.FormFile.CopyTo(fileStream);
                fileStream.Dispose();
                Article.FilePath = newFileName;
            }

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
