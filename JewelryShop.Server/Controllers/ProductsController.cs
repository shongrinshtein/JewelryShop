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
using JewelryShop.Server.IServices;

namespace JewelryShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService) => this.productService = productService;

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll() => throw new NotImplementedException();


        //[HttpGet]
        //public async Task<ActionResult<Material>> GetByIndex([FromQuery] int index)
        //{
        //    int manyInPage = 15;
        //    return Ok(await productService.GetByIndex(index, manyInPage));
        //}

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                return await productService.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutProduct(Product product)
        {
            try
            {
                await productService.Update(product);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent(); 
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            try
            {
                return await productService.Insert(product);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteProduct(int id) => await productService.Delete(id);
    }
}
