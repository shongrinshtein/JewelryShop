using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Data.Models;
using JewelryShop.Data.Repository.Interfaces;
using JewelryShop.Data.Repository;

namespace JewelryShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryItemsController : ControllerBase
    {
        private readonly ICategoryItemRepository itemRepos;

        public CategoryItemsController(ICategoryItemRepository itemRepos)
        {
            this.itemRepos = itemRepos;
        }

        // GET: api/CategoryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetCategoryItems() => Ok(await itemRepos.GetAll());

        // GET: api/CategoryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryItem>> GetCategoryItem(int id)
        {
            try
            {
                return await itemRepos.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/CategoryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoryItem(int id, CategoryItem categoryItem)
        {
            if (id != categoryItem.Id)
            {
                return BadRequest();
            }

            try
            {
                 await itemRepos.Update(categoryItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/CategoryItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> PostCategoryItem(CategoryItem categoryItem)
        {
            try
            {
                return await itemRepos.Insert(categoryItem);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/CategoryItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryItem(int id)
        {
            try
            {
                await itemRepos.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
