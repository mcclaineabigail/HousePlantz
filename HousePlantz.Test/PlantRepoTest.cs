using HousePlantz.Data.Models;
using HousePlantz.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HousePlantz.Test
{
    [TestClass]
    public class PlantRepoTest
    {
        private CatalogRepository _catalogRepo = new CatalogRepository();

        [TestMethod]
        public void ShouldBeAbleToGetAllPlants()
        {
            List<Plant> plantCatalog = new List<Plant>()
            {
            new Plant {Id = 1, Name = "Peperomia", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/peperomia.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous"},
            new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/chinese-evergreen.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous"}
             };
        }
    }
}