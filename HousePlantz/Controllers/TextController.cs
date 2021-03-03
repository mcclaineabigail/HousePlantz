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
        [HttpGet]
        public string GetText()
        {
            return System.IO.File.ReadAllText(@"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt"); // Need to find how to reference file locally.
        }

        [HttpPost]
        public Plant PostLineToTextFile([FromBody] Plant plantToAdd)
        {
            var allText = GetText();
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(allText);
            plantList.Add(plantToAdd);

            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

            using var sw = new StreamWriter(allPath);
            sw.WriteLine(newText);

            return plantToAdd;
        }

        
        [HttpPatch("{NickName}")]
        public IActionResult Patch(string nickName, [FromBody] JsonPatchDocument<Plant> patchEntity)
        {
            var allText = GetText();
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(allText);

            var entity = plantList.FirstOrDefault(x => x.NickName == nickName);
            if (entity == null)
            { return NotFound(); }

            patchEntity.ApplyTo(entity, ModelState);

            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

            using var sw = new StreamWriter(allPath);
            sw.WriteLine(newText);

            return Ok(entity);
        }

        [HttpDelete("{NickName}")]
        public Plant Delete(string nickName)
        {
            var allText = GetText();
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(allText);

            var plantToRemove = plantList.FirstOrDefault(x => x.NickName == nickName);
            plantList.Remove(plantToRemove);
            var newText = System.Text.Json.JsonSerializer.Serialize(plantList, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

            string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

            using var sw = new StreamWriter(allPath);
            sw.WriteLine(newText);

            return plantToRemove;
        }
    }
}

