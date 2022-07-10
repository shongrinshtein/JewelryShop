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
    public class SizeItemsController : ControllerBase
    {
        private readonly ISizeItemRepository sizeItemRepository;

        public SizeItemsController(ISizeItemRepository sizeItemRepository)
        {
            this.sizeItemRepository = sizeItemRepository;
        }

        // GET: api/SizeItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SizeItem>>> GetSizeItems() => Ok(await sizeItemRepository.GetAll());

        // GET: api/SizeItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SizeItem>> GetSizeItem(int id)
        {
            try
            {
                return await sizeItemRepository.Get(id);
            }
            catch
            {
                return NotFound();
            }

        }

        // PUT: api/SizeItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSizeItem(int id, SizeItem sizeItem)
        {
            if (id != sizeItem.Id)
            {
                return BadRequest();
            }

            try
            {
                await sizeItemRepository.Update(sizeItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/SizeItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SizeItem>> PostSizeItem(SizeItem sizeItem)
        {
            try
            {
                return await sizeItemRepository.Insert(sizeItem);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/SizeItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSizeItem(int id)
        {
            try
            {
                await sizeItemRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
