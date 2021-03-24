﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HousePlantz.Data.Models;

namespace HousePlantz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnedPlantsController : ControllerBase
    {
        private readonly PlantCatalogContext _context;

        public OwnedPlantsController(PlantCatalogContext context)
        {
            _context = context;
        }


        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Plant>> GetCatalog(int id)
        {
            var catalogs = _context.Catalogs.Include(catalog => catalog.Plants);
            var catalog = catalogs.FirstOrDefault(x => x.Id == id);

            return catalog.Plants;
        }




        [HttpGet("{catalogId}/{plantId}")]
        public async Task<ActionResult<Plant>> GetIndvPlantFromCatalog(int catalogId, int plantId)
        {
            var catalogs = _context.Catalogs.Include(catalog => catalog.Plants);
            var catalog = catalogs.FirstOrDefault(x => x.Id == catalogId);

            return catalog.Plants.FirstOrDefault(x => x.Id == plantId);

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
                { return NotFound(); }
                else
                { throw; }
            }

            return NoContent();
        }

        [HttpPatch("catalog{id}/{plantId}")]
        public async Task<IActionResult> Patch(int id, int plantId)
        {
            var catalog = await _context.Catalogs.FindAsync(id);
            var plantToAdd = await _context.Plants.FindAsync(plantId);

            if (catalog.Plants == null)
            {
                catalog.Plants = new List<Plant>();
            }

            catalog.Plants.Add(plantToAdd);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogExists(id))
                { return NotFound(); }
                else
                { throw; }
            }
            return NoContent();
        }




        private bool CatalogExists(int id)
        {
            return _context.Catalogs.Any(e => e.Id == id);
        }
    }
}
