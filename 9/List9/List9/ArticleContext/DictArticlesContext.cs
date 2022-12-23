using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List9.Models;

namespace List9.ArticleContext
{
    public class DictArticlesContext : IArticlesContext
    {
        Dictionary<int, Article> articleDict = new Dictionary<int, Article>()
        {
            {0, new Article(0, "Kielbasa Slaska", 9.99, new DateTime(2022,12,10), Category.Meat) }
        };

        public void AddArticle(Article article)
        {

            int newId = 0;
            if (articleDict.Count() != 0)
            {
                newId= articleDict.Keys.Max(key => key) + 1;
            }
            article.Id = newId;
            articleDict.Add(newId, article);
        }

        public Article GetArticle(int id)
        {
            return articleDict.GetValueOrDefault(id);
        }

        public List<Article> GetArticles()
        {
            return articleDict.Values.ToList();
        }

        public void RemoveArticle(int id)
        {
            Article articleToRemove = articleDict.GetValueOrDefault(id);
            if (articleToRemove != null)
                articleDict.Remove(articleToRemove.Id);
        }

        public void UpdateArticle(Article article)
        {
            Article articleToUpdate = articleDict.GetValueOrDefault(article.Id);
            articleDict[article.Id] = article;
        }
    }
}
