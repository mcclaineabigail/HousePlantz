using HousePlantz.Data.Interfaces;
using HousePlantz.Data.Models;
using HousePlantz.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

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



        // Retreive Plant image by plant id
        [HttpGet("/image/{id}")]
        public IActionResult Get(string type)
        {
            Byte[] b;
            b = System.IO.File.ReadAllBytes("..\\..main\\blob\\LibraryServices.Data\\Images\\plant-images\\pothos.png");
            //b = System.IO.File.ReadAllBytes("c:\\users\\amcclain\\source\\repos\\HousePlantz\\LibraryServices.Data\\Images\\plant-images\\pothos.png");
        
        /*https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/pothos.PNG?raw=true     
        https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz/Controllers/PlantsController.cs */


            //if (type == null)
            //{
            //    return Content("Hi there is no type value given. Please enter picturefromtext or hostedimagefile in type parameter in url");
            //}
            //if (type.Equals("picturefromtext"))
            //{
            //    Image image = DrawText("Kapil Dev Gaur", new Font(FontFamily.GenericSansSerif, 15), Color.DarkBlue, Color.Cornsilk);
            //    b = ImageToByteArray(image);
            //}
            //else if (type.Equals("hostedimagefile"))
            //{
            //    b = System.IO.File.ReadAllBytes("c:\\users\\amcclain\\source\\repos\\HousePlantz\\LibraryServices.Data\\Images\\plant-images\\pothos.png");
            //}
            //else
            //{
            //    return Content("No action is defined for this type value");
            //}
            return File(b, "image/jpeg");
        }

  

        public Image DrawText(String text, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object  
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be  
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object  
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size  
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background  
            drawing.Clear(backColor);

            //create a brush for the text  
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;

        }
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}  
    

