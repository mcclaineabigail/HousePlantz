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
    public class PlantsController : ControllerBase
    {
        private readonly PlantCatalogContext _context;

        public PlantsController(PlantCatalogContext context)
        {
            _context = context;
        }



        // GET: api/Plants1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Plant>>> GetPlants()
        {
            return await _context.Plants.ToListAsync();
        }

        // GET: api/Plants1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Plant>> GetPlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);

            if (plant == null)
            {
                return NotFound();
            }

            return plant;
        }

        // PUT: api/Plants1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlant(int id, Plant plant)
        {
            if (id != plant.Id)
            {
                return BadRequest();
            }

            _context.Entry(plant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plants1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Plant>> PostPlant(Plant plant)
        {
            _context.Plants.Add(plant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlant", new { id = plant.Id }, plant);
        }

        // DELETE: api/Plants1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlant(int id)
        {
            var plant = await _context.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }

            _context.Plants.Remove(plant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlantExists(int id)
        {
            return _context.Plants.Any(e => e.Id == id);
        }



        //// Retreive Plant image by plant id
        //[HttpGet("/image/{id}")]
        //public IActionResult Get(string type)
        //{
        //    Byte[] b;
        //    b = System.IO.File.ReadAllBytes("..\\LibraryServices.Data\\Images\\plant-images\\pothos.png?raw=true");
        //    //b = System.IO.File.ReadAllBytes("c:\\users\\amcclain\\source\\repos\\HousePlantz\\LibraryServices.Data\\Images\\plant-images\\pothos.png");

        ///*https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/pothos.PNG?raw=true     
        //https://github.com/mcclaineabigail/PlantCatalog/blob/main/HousePlantz/Controllers/PlantsController.cs */


        //    //if (type == null)
        //    //{
        //    //    return Content("Hi there is no type value given. Please enter picturefromtext or hostedimagefile in type parameter in url");
        //    //}
        //    //if (type.Equals("picturefromtext"))
        //    //{
        //    //    Image image = DrawText("Kapil Dev Gaur", new Font(FontFamily.GenericSansSerif, 15), Color.DarkBlue, Color.Cornsilk);
        //    //    b = ImageToByteArray(image);
        //    //}
        //    //else if (type.Equals("hostedimagefile"))
        //    //{
        //    //    b = System.IO.File.ReadAllBytes("c:\\users\\amcclain\\source\\repos\\HousePlantz\\LibraryServices.Data\\Images\\plant-images\\pothos.png");
        //    //}
        //    //else
        //    //{
        //    //    return Content("No action is defined for this type value");
        //    //}
        //    return File(b, "image/jpeg");
        //}



        //public Image DrawText(String text, Font font, Color textColor, Color backColor)
        //{
        //    //first, create a dummy bitmap just to get a graphics object  
        //    Image img = new Bitmap(1, 1);
        //    Graphics drawing = Graphics.FromImage(img);

        //    //measure the string to see how big the image needs to be  
        //    SizeF textSize = drawing.MeasureString(text, font);

        //    //free up the dummy image and old graphics object  
        //    img.Dispose();
        //    drawing.Dispose();

        //    //create a new image of the right size  
        //    img = new Bitmap((int)textSize.Width, (int)textSize.Height);

        //    drawing = Graphics.FromImage(img);

        //    //paint the background  
        //    drawing.Clear(backColor);

        //    //create a brush for the text  
        //    Brush textBrush = new SolidBrush(textColor);

        //    drawing.DrawString(text, font, textBrush, 0, 0);

        //    drawing.Save();

        //    textBrush.Dispose();
        //    drawing.Dispose();

        //    return img;

        //}
        //public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //    return ms.ToArray();
        //}
    }
}  
    

