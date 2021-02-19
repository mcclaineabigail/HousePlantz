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
    public class PlantListController : ControllerBase
    {

        private IPlantRepository plantCatalog = new CatalogRepository();

        // GET: api/<PlantListController>
        [HttpGet]
        public IEnumerable<Plant> Get()
        {
            return plantCatalog.GetAllPlants();
        }

        // GET api/<PlantListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PlantListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PlantListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PlantListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
