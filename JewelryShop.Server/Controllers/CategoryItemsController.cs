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
        private readonly ICategoryItemRepository categoryItemsRepos;

        public CategoryItemsController(ICategoryItemRepository itemRepos) => this.categoryItemsRepos = itemRepos;

        // GET: api/CategoryItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetCategoryItems() => throw new NotImplementedException();
        [HttpGet]

        public async Task<ActionResult<IEnumerable<CategoryItem>>> GetCategoryItemByIndex([FromQuery] int index)
        {
            int manyInPage = 15;
            return Ok(await categoryItemsRepos.GetByIndex(index, manyInPage));
        }
        // GET: api/CategoryItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryItem>> GetCategoryItem(int id)
        {
            try
            {
                return await categoryItemsRepos.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/CategoryItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutCategoryItem( CategoryItem categoryItem)
        {
            try
            {
                 await categoryItemsRepos.Update(categoryItem);
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
        public async Task<ActionResult<CategoryItem>> PostCategoryItem(CategoryItem categoryItem)
        {
            try
            {
                return await categoryItemsRepos.Insert(categoryItem);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/CategoryItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategoryItem(int id)
        {
            try
            {
                await categoryItemsRepos.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
