using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace List10.Models
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetArticles();
        Task<Article> GetArticle(int id);
        Task<Article> AddArticle(Article article);
        Task<Article> UpdateArticle(Article article);
        Task DeleteArticle(int id);
        Task<IEnumerable<Article>> GetArticlesFromTo(int from, int to);
    }
}
