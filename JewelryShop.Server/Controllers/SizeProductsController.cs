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
    public class SizeProductsController : ControllerBase
    {
        private readonly ISizeProductRepository sizeProductRepository;

        public SizeProductsController(ISizeProductRepository sizeProductRepository) => this.sizeProductRepository = sizeProductRepository;

        // GET: api/SizeProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeProduct>>> GetSizeProducts() => Ok(await sizeProductRepository.GetAll());

        // GET: api/SizeProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeProduct>> GetSizeProduct(int id)
        {
            try
            {
                return await sizeProductRepository.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/SizeProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeProduct(int id, SizeProduct sizeProduct)
        {
            if (id != sizeProduct.Id)
            {
                return BadRequest();
            }

            try
            {
                await sizeProductRepository.Update(sizeProduct);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/SizeProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeProduct>> PostSizeProduct(SizeProduct sizeProduct)
        {
            try
            {
                return await sizeProductRepository.Insert(sizeProduct);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/SizeProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeProduct(int id)
        {
            try
            {
                await sizeProductRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
