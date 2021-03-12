using HousePlantz.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HousePlantz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TextController : ControllerBase
    {
        public string fileText = System.IO.File.ReadAllText(@"C:\Users\amcclain\source\repos\HousePlantz\HousePlantz.Data\Text\CatalogText.txt");
        public string filePath = @"C:\Users\amcclain\source\repos\HousePlantz\HousePlantz.Data\Text\CatalogText.txt";

        [HttpGet]
        public string GetText()
        {
            return fileText;  // Need to find how to reference file locally.
        }


        [HttpPost]
        public Plant PostLineToTextFile([FromBody] Plant plantToAdd)
        {
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(fileText);
            plantList.Add(plantToAdd);

            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            

            using var sw = new StreamWriter(filePath);
            sw.WriteLine(newText);

            return plantToAdd;
        }

        // PUT api/<Catalog>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Plant updatedPlant)
        {
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(fileText);
            var plantToChange = plantList.FirstOrDefault(x => x.Id == id);
            plantList[plantList.FindIndex(ind => ind.Equals(plantToChange))] = updatedPlant;

            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            using var sw = new StreamWriter(filePath);
            sw.WriteLine(newText);
        }


        [HttpPatch("{NickName}")]
        public IActionResult Patch(string nickName, [FromBody] JsonPatchDocument<Plant> patchEntity)
        {
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(fileText);

            var entity = plantList.FirstOrDefault(x => x.NickName == nickName);
            if (entity == null)
            { return NotFound(); }

            patchEntity.ApplyTo(entity, ModelState);

            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            using var sw = new StreamWriter(filePath);
            sw.WriteLine(newText);

            return Ok(entity);
        }

        [HttpDelete("{NickName}")]
        public Plant Delete(string nickName)
        {
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(fileText);

            var plantToRemove = plantList.FirstOrDefault(x => x.NickName == nickName);
            plantList.Remove(plantToRemove);
            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });


            using var sw = new StreamWriter(filePath);
            sw.WriteLine(newText);

            return plantToRemove;
        }

    }
}

