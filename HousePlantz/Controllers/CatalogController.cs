using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HousePlantz.Data.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousePlantz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {

        private readonly PlantCatalogContext _context;

        public CatalogController(PlantCatalogContext context)
        {
            _context = context;
        }

        // GET: api/<Catalog>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalog>>> GetPlantCatalogs()
        {
            return await _context.Catalogs.ToListAsync();
        }

        // GET api/<Catalog>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> PutCatalog(int id, Catalog catalog)
        {
            if (id != catalog.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantCatalogExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // POST api/<Catalog>
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlantCatalog(Catalog catalog)
        {
            _context.Catalogs.Add(catalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlantCatalog", new { id = catalog.Id }, catalog);
        }

        // PUT api/<Catalog>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Catalog>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlantCatalog(int id)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            if (catalog == null)
            {
                return NotFound();
            }

            _context.Catalogs.Remove(catalog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantCatalogExists(int id)
        {
            return _context.Plants.Any(e => e.Id == id);
        }

    }
}
