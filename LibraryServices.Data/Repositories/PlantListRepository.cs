using System;
using System.Collections.Generic;
using System.Text;
using HousePlantz.Data.Repositories;

namespace HousePlantz.Data.Repositories
{
    public class PlantListRepository : IPlantListRepository
    {

        public List<Plant> plants = new List<Plant>()
        {
         
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
