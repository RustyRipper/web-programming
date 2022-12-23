using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List9.Models;

namespace List9.ArticleContext
{
    public class ListArticlesContext : IArticlesContext
    {

        List<Article> articleList = new List<Article>() {
            new Article(0, "Kielbasa Slaska", 9.99, new DateTime(2022,12,10), Category.Meat)
        };


        public void AddArticle(Article article)
        {
            int newId = 0;
            if(articleList.Count() != 0)
            {
                newId = articleList.Max(e => e.Id) + 1;
            }

            article.Id = newId;
            articleList.Add(article);
        }

        public Article GetArticle(int id)
        {
            return articleList.FirstOrDefault(e => e.Id == id);
        }

        public List<Article> GetArticles()
        {
            return articleList;
        }

        public void RemoveArticle(int id)
        {
            Article articleToRemove = articleList.FirstOrDefault(e => e.Id == id);
            if (articleToRemove != null)
                articleList.Remove(articleToRemove);
        }

        public void UpdateArticle(Article article)
        {
            Article articleToUpdate = articleList.FirstOrDefault(e => e.Id == article.Id);
            articleList = articleList.Select(e => (e.Id == article.Id) ? article : e).ToList();
        }
    }
}
