using HousePlantz.Data.Models;
using Microsoft.AspNetCore.Mvc;
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
            return System.IO.File.ReadAllText(@"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt");
        }

        [HttpPost]
        public Plant PostLineToTextFile([FromBody] Plant plantToAdd)
        {
            var jsonText = JsonSerializer.Serialize(plantToAdd, new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });
            string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";
            string startingText = System.IO.File.ReadAllText(allPath);
            string newText = startingText + "," + jsonText; //Get rid of Shotty Code ya newb

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
            var plantList = JsonSerializer.Deserialize<List<Plant>>(allText);

        //    List<Plant> plantList = new List<Plant>()
        //{
        //    new Plant {Id = 1, Name = "Peperomia", Sun = "low-medium", Image = "peperomia", Water = "Allow to Dry", Notes = "Poisonous"},
        //    new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "low-medium", Image = "chinese-evergreen", Water = "Keep Evenly Moist", Notes = "Poisonous"},
        //    new Plant {Id = 9, Name = "ZZ Plant", Sun = "any", Image = "zz-plant", Water = "Allow to Dry", Notes = "Poisonous"},
        //    new Plant {Id = 0, Name = "string", Sun = "string", Image = "string", Water = "string", Notes = "string"}

        //};

            var plantToRemove = plantList.FirstOrDefault(x => x.Id == id);
            plantList.Remove(plantToRemove);
            var newText = JsonSerializer.Serialize(plantList);

            string allPath = @"C:\Users\amcclain\source\repos\HousePlantz\LibraryServices.Data\Text\CatalogText.txt";

            using var sw = new StreamWriter(allPath);
            sw.WriteLine(newText);
        }
    }
}