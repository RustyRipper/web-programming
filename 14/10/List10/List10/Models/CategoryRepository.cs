using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List10.Data;
using Microsoft.EntityFrameworkCore;

namespace List10.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _context.Category.ToListAsync();
        }

        public async Task<Category> GetCategory(int id)
        {
            var result = await _context.Category
                .FirstOrDefaultAsync(c => c.Id == id);
            return result;
        }

        public async Task<Category> AddCategory(Category category)
        {
            var result = await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            var result = await _context.Category
                .FirstOrDefaultAsync(c => c.Id == category.Id);

            if (result != null)
            {
                result.Id = category.Id;
                result.Name = category.Name;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task DeleteCategory(int id)
        {
            var result = await _context.Category
                .FirstOrDefaultAsync(c => c.Id == id);

            if (result != null)
            {
                _context.Category.Remove(result);
                await _context.SaveChangesAsync();
            }
        }
    }
}

