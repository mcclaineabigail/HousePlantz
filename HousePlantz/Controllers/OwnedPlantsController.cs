using System;
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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnedPlant>>> GetAllOwnedPlants()
        {
            return await _context.OwnedPlants
                                        .Include(oPlant => oPlant.Plant)
                                        .Include(oPlant => oPlant.Room)
                                        .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnedPlant>> GetOwnedPlant(int id)
        {
            var oPlants = await _context.OwnedPlants
                                         .Include(oPlant => oPlant.Plant)
                                         .Include(oPlant => oPlant.Room)
                                         .ToListAsync();

            return oPlants.FirstOrDefault(x => x.Id == id);
        }





        [HttpPost] //This is not working, see Swagger Error Message
        public async Task<ActionResult<OwnedPlant>> AddPlantToCatalog(OwnedPlant oPlant)
        {
            _context.OwnedPlants.Add(oPlant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalog", new { id = oPlant.Id }, oPlant);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> deletePlantFromCatalog(int id)
        {
            var oPlant = await _context.OwnedPlants.FindAsync(id);
            if (oPlant == null)
            {
                return NotFound();
            }

            _context.OwnedPlants.Remove(oPlant);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCatalog(int id, Catalog catalog)
        //{
        //    if (id != catalog.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(catalog).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CatalogExists(id))
        //        { return NotFound(); }
        //        else
        //        { throw; }
        //    }

        //    return NoContent();
        //}

        //[HttpPatch("catalog{id}/{plantId}")]
        //public async Task<IActionResult> Patch(int id, int plantId)
        //{
        //    var catalog = await _context.Catalogs.FindAsync(id);
        //    var plantToAdd = await _context.OwnedPlants.FindAsync(plantId);

        //    if (catalog.Plants == null)
        //    {
        //        catalog.Plants = new List<OwnedPlant>();
        //    }

        //    catalog.Plants.Add(plantToAdd);

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CatalogExists(id))
        //        { return NotFound(); }
        //        else
        //        { throw; }
        //    }
        //    return NoContent();
        //}




        //private bool CatalogExists(int id)
        //{
        //    return _context.Catalogs.Any(e => e.Id == id);
        //}
    }
}
