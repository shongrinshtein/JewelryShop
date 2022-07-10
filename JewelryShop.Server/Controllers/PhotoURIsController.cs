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
    public class PhotoURIsController : ControllerBase
    {
        private readonly IPhotoURIRepository photoURIRepository;

        public PhotoURIsController(IPhotoURIRepository photoURIRepository) => this.photoURIRepository = photoURIRepository;

        // GET: api/PhotoURIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PhotoURI>>> GetPhotoURIs() => Ok(await photoURIRepository.GetAll());
        // GET: api/CategoryProducts/5

        // GET: api/PhotoURIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PhotoURI>> GetPhotoURI(int id)
        {
            try
            {
                return await photoURIRepository.Get(id);
            }
            catch
            {
                return NotFound();
            }

        }

        // PUT: api/PhotoURIs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhotoURI(int id, PhotoURI photoURI)
        {
            if (id != photoURI.Id)
            {
                return BadRequest();
            }

            try
            {
                await photoURIRepository.Update(photoURI);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/PhotoURIs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PhotoURI>> PostPhotoURI(PhotoURI photoURI)
        {
            try
            {
                return await photoURIRepository.Insert(photoURI);
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        // DELETE: api/PhotoURIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotoURI(int id)
        {
            try
            {
                await photoURIRepository.Delete(id);
            }
            catch (Exception e)
            {
                throw e;
            }
            return NotFound();
        }

    }
}
