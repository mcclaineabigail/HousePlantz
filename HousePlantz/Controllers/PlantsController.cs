using HousePlantz.Data.Interfaces;
using HousePlantz.Data.Models;
using HousePlantz.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousePlantz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantsController : ControllerBase
    {
        private IPlantRepository plants = new PlantRepository();
        

        // GET: api/<PlantsController>
        [HttpGet]
        public IEnumerable<Plant> Get()
        {
            return plants.GetAllPlants();
        }

        // GET api/<PlantsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var plant = plants.GetPlantById(id);
            if(plant == null)
            {
                return NotFound();
            }
            return Ok(plant);
        }

        // POST api/<PlantsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlantsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlantsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
