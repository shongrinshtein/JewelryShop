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

namespace JewelryShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryProductsController : ControllerBase
    {
        private readonly ICategoryProductRepository productRepos;
        public CategoryProductsController(ICategoryProductRepository productRepos)
        {
            this.productRepos = productRepos;
        }

        // GET: api/CategoryProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetCategoryProducts() => throw new NotImplementedException();
        [HttpGet("/categoryproduct/{index}")]
        public async Task<ActionResult<IEnumerable<CategoryProduct>>> GetCategoryProductByIndex( int index)
        {
            int manyInPage = 15;
            return Ok(await productRepos.GetByIndex(index, manyInPage));
        }
        //GET: api/CategoryProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryProduct>> GetCategoryProduct(int id)
        {
            try
            {
                return await productRepos.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/CategoryProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutCategoryProduct( CategoryProduct categoryProduct)
        {
            try
            {
                await productRepos.Update(categoryProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }


        // POST: api/CategoryProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoryProduct>> PostCategoryProduct(CategoryProduct categoryProduct)
        {
            try
            {
                return await productRepos.Insert(categoryProduct);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/CategoryProducts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCategoryProduct(int id)
        {
            try
            {
                return await productRepos.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
