using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List9.Models;

namespace List9.ArticleContext
{
    public interface IArticlesContext
    {
        List<Article> GetArticles();
        Article GetArticle(int id);
        void AddArticle(Article article);
        void RemoveArticle(int id);
        void UpdateArticle(Article article);
    }
}
