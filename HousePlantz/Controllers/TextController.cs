using HousePlantz.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        private object SerializableAttribute(Plant plantToAdd)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            var allText = GetText();
            var plantList = JsonConvert.DeserializeObject<List<Plant>>(allText);

            var plantToRemove = plantList.FirstOrDefault(x => x.Id == id);
            plantList.Remove(plantToRemove);
            var newText = System.Text.Json.JsonSerializer.Serialize(plantList);

            string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

            using var sw = new StreamWriter(allPath);
            sw.WriteLine(newText);
        }
    }
}



// This version is able to handle one Plant, possibly try to split up the string by , if the deserialize object doesn't work.

//[HttpDelete("{id}")]
//public void Delete(long id)
//{
//    var allText = GetText();

//    var plant = JsonSerializer.Deserialize<Plant>(allText);
//    var plantList = new List<Plant> { plant };

//    var plantToRemove = plantList.FirstOrDefault(x => x.Id == id);
//    plantList.Remove(plantToRemove);
//    var newText = JsonSerializer.Serialize(plantList);

//    string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

//    using var sw = new StreamWriter(allPath);
//    sw.WriteLine(newText);




// Original code

//var allText = GetText();
//var plantList = JsonSerializer.Deserialize<List<Plant>>(allText);

//var plantToRemove = plantList.FirstOrDefault(x => x.Id == id);
//plantList.Remove(plantToRemove);
//var newText = JsonSerializer.Serialize(plantList);

//string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

//using var sw = new StreamWriter(allPath);
//sw.WriteLine(newText);