using HousePlantz.Data.Interfaces;
using HousePlantz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlantz.Data.Repositories
{
    public class PlantRepository : IPlantRepository
    {

        public List<Plant> plants = new List<Plant>()
        {
            new Plant {Id = 1, Name = "Peperomia Change", Sun = "/light/low-med.png",  Image = "/plant-images/peperomia.PNG", Water = "Allow to Dry", Notes = "Poisonous"},
            new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "/light/low-med.png",  Image = "/plant-images/chinese-evergreen.PNG", Water = "Keep Evenly Moist", Notes = "Poisonous"},
            new Plant {Id = 3, Name = "Grape Ivy", Sun = "/light/med.png",  Image = "/plant-images/grape-ivy.PNG", Water = "Keep Evenly Moist", Notes = "Trailing"},
            new Plant {Id = 4, Name = "Norfolk Island Pine", Sun = "/light/bright.png",  Image = "/plant-images/norfolk-island-pine.PNG", Water = "Allow to Dry", Notes = "Festive"}
        };

        public List<Plant> GetAllPlants()
        {
            return plants;
        }

        public Plant GetPlantById(long id)
        {
            var plant = plants.FirstOrDefault(x => x.Id == id);
            return plant;
        }
    }
}
