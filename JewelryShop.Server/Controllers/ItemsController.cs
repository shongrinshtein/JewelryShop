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
    public class ItemsController : ControllerBase
    {
        private readonly IItemRepository itemRepos;

        public ItemsController(IItemRepository itemRepos) => this.itemRepos = itemRepos;

        // GET: api/Items
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems() => throw new NotImplementedException();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Item>>> GetItemsByIndex([FromQuery]int index)
        {
            int manyInPage = 15;
            return Ok(await itemRepos.GetByIndex(index, manyInPage));
        }
        // GET: api/Items/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItem(int id)
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

        // PUT: api/Items/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(Item item)
        {
            try
            {
                await itemRepos.Update(item);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();

        }

        // POST: api/Items
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Item>> PostItem(Item item)
        {
            try
            {
                return await itemRepos.Insert(item);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
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
