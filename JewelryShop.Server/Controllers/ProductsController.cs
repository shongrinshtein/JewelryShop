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
        private readonly ISupplierService supplierService;

        public ProductsController(ISupplierService supplierService) => this.supplierService = supplierService;

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts() => Ok(await supplierService.GetSuppliers());

        [HttpGet]
        public async Task<ActionResult<Material>> GetProductsByIndex([FromQuery] int index)
        {
            int manyInPage = 15;
            return Ok(await ProductRepository.GetByIndex(index, manyInPage));
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                return await ProductRepository.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(Product product)
        {
            try
            {
                await ProductRepository.Update(product);
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
                return await ProductRepository.Insert(product);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await ProductRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }
    }
}
