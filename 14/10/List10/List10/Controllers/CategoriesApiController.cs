using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using List10.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace List10.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesApiController : ControllerBase
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoriesApiController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        // GET: api/<CategoriesApiController>
        [HttpGet]
        public async Task<ActionResult> GetCategories()
        {
            return Ok(await categoryRepository.GetCategories());
        }

        // GET api/<CategoriesApiController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            
            return await categoryRepository.GetCategory(id);
        }

        // POST api/<CategoriesApiController>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {
            var category2 = await categoryRepository.AddCategory(category);
            return CreatedAtAction(nameof(GetCategory), new { id = category2.Id }, category2);
        }

        // PUT api/<CategoriesApiController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Category>> PutCategory(int id, [FromBody] Category category)
        {
            var category2 = await categoryRepository.GetCategory(id);
            return await categoryRepository.UpdateCategory(category);
        }

        // DELETE api/<CategoriesApiController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            await categoryRepository.DeleteCategory(id);
            return Ok("" + id);
        }
    }
}
