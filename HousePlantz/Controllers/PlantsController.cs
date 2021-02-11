using HousePlantz.Models;
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

        public List<Plant> plants = new List<Plant>()
        {
            new Plant {Id = 1, Name = "Peperomia Change", Sun = "/light/low-med.png",  Image = "/plant-images/peperomia.PNG", Water = "Allow to Dry", Notes = "Poisonous"},
            new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "/light/low-med.png",  Image = "/plant-images/chinese-evergreen.PNG", Water = "Keep Evenly Moist", Notes = "Poisonous"},
            new Plant {Id = 3, Name = "Grape Ivy", Sun = "/light/med.png",  Image = "/plant-images/grape-ivy.PNG", Water = "Keep Evenly Moist", Notes = "Trailing"},
            new Plant {Id = 4, Name = "Norfolk Island Pine", Sun = "/light/bright.png",  Image = "/plant-images/norfolk-island-pine.PNG", Water = "Allow to Dry", Notes = "Festive"}
        };

        // GET: api/<PlantsController>
        [HttpGet]
        public IEnumerable<Plant> Get()
        {
            return plants;
        }

        // GET api/<PlantsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var plant = plants.FirstOrDefault(x => x.Id == id);
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
