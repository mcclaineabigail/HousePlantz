using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HousePlantz.Data.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace HousePlantz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogsController : ControllerBase
    {
        private readonly PlantCatalogContext _context;

        public CatalogsController(PlantCatalogContext context)
        {
            _context = context;
        }

        [HttpGet]//Only one catalog at the moment, so code is written to retreive catalog 1
        public async Task<ActionResult<Catalog>> GetCatalogs()
        {
            var catalog = _context.Catalogs.Include(catalog => catalog.Plants).FirstOrDefaultAsync();

            if (catalog == null)
            {
                return NotFound();
            }

            return await catalog;



            //return await _context.Catalogs.Include(catalog => catalog.Plants).ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Catalog>> GetCatalog(int id)
        {
            var catalog = _context.Catalogs.Include(catalog => catalog.Plants).FirstOrDefaultAsync(x => x.Id == id);

            if (catalog == null)
            {
                return NotFound();
            }

            return await catalog;
        }



        [HttpPost]
        public async Task<ActionResult<Catalog>> PostCatalog(Catalog catalog)
        {
            _context.Catalogs.Add(catalog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog", new { id = catalog.Id }, catalog);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCatalog(int id)
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


        [HttpPut("{id}")]
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
                if (!CatalogExists(id))
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





        private bool CatalogExists(int id)
        {
            return _context.Catalogs.Any(e => e.Id == id);
        }
    }
}
