using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using List10.Data;
using List10.Models;
using Microsoft.AspNetCore.Cors;

namespace List10.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesApiController : ControllerBase
    {
        private readonly IArticleRepository articleRepository;

        public ArticlesApiController(IArticleRepository articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        // GET: api/ArticlesApi
        [HttpGet]
        public async Task<ActionResult> GetArticle()
        {
            return Ok(await articleRepository.GetArticles());
        }

        // GET: api/ArticlesApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await articleRepository.GetArticle(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }

        // PUT: api/ArticlesApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> PutArticle(int id, [FromBody] Article article)
        {
            if (id != article.Id)
            {
                return BadRequest();
            }

            return await articleRepository.UpdateArticle(article);

        }

        // POST: api/ArticlesApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle([FromBody] Article article)
        {
            var article2 = await articleRepository.AddArticle(article);

            return CreatedAtAction("GetArticle", new { id = article.Id }, article2);
        }

        // DELETE: api/ArticlesApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var article = await articleRepository.GetArticle(id);
            if (article == null)
            {
                return NotFound();
            }

            await articleRepository.DeleteArticle(id);

            return Ok(""+id);
        }
        [HttpGet("get/{from}/{to}")]
        public async Task<ActionResult> GetArticlePart(int from, int to)
        {

            return Ok(await articleRepository.GetArticlesFromTo(from, to));
        }

    }

}
