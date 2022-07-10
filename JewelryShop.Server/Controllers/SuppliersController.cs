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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService) => this.supplierService = supplierService;

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers() => throw new NotImplementedException();

        // GET: api/Suppliers/5
        //[HttpGet]
        //public async Task<ActionResult<Supplier>> GetSupplierssByIndex([FromQuery] int index)
        //{
        //    int manyInPage = 15;
        //    return Ok(await supplierService.GetByIndex(index, manyInPage));
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            try
            {
                return await supplierService.Get(id);
            }
            catch
            {
                return NotFound();
            }
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> PutSupplier(int id, Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return BadRequest();
            }

            try
            {
                await supplierService.Update(supplier);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Supplier>> PostSupplier(Supplier supplier)
        {
            try
            {
                return await supplierService.Insert(supplier);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteSupplier(int id)
        {
            try
            {
                await supplierService.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
