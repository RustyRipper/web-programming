using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List10.Data;
using Microsoft.EntityFrameworkCore;

namespace List10.Models
{
    public class A { }
    public class B { }
    public interface IA { }
    public interface IB { }
    public class C3 : IA, IB, A { }
    public class ArticleRepository : IArticleRepository
    {
        private readonly MyDbContext _context;

        public ArticleRepository(MyDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _context.Article.ToListAsync();
        }

        public async Task<Article> GetArticle(int id)
        {
            return await _context.Article
                .Include(a => a.Category)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Article> AddArticle(Article article)
        {
            var result = await _context.Article.AddAsync(article);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteArticle(int id)
        {
            var result = await _context.Article
                .FirstOrDefaultAsync(a => a.Id == id);

            if (result != null)
            {
                _context.Article.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Article> UpdateArticle(Article article)
        {
            var result = await _context.Article
                .FirstOrDefaultAsync(a => a.Id == article.Id);

            if (result != null)
            {
                result.Id = article.Id;
                result.Name = article.Name;
                result.Price = article.Price;
                result.CategoryId = article.CategoryId;
                result.FilePath = article.FilePath;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }


        public async Task<IEnumerable<Article>> GetArticlesFromTo(int from, int to)
        {
            return await _context.Article
                .Include(a => a.Category)
                .OrderBy(a => a.Id)
                .Skip(from)
                .Take(to - from)
                .ToListAsync();
        }
    }
}
