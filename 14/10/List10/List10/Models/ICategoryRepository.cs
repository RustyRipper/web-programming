using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List10.Models
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetCategory(int id);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task DeleteCategory(int id);
    }
}
