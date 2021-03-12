using System.Collections.Generic;
using System.Linq;
using HousePlantz.Data.Interfaces;
using HousePlantz.Data.Models;

namespace HousePlantz.Data.Repositories

    
{
    public class CatalogRepository : IPlantRepository
    {
        public List<Plant> plantCatalog = new List<Plant>()
        {
            new Plant {Id = 1, Name = "Peperomia", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/peperomia.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous"},
            new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/chinese-evergreen.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous"}
        };


        public List<Plant> GetAllPlants()
        {
            return plantCatalog;
        }

        public Plant GetPlantById(long id)
        {
            var plant = plantCatalog.FirstOrDefault(x => x.Id == id);
            return plant;
        }

        public Plant AddPlant(Plant plantToAdd)
        {
            plantCatalog.Add(plantToAdd);

            return plantToAdd;
        }

        public void DeletePlantById(long id)
        {
            var plant = plantCatalog.FirstOrDefault(x => x.Id == id);
            plantCatalog.Remove(plant);
        }

       
    }
}
