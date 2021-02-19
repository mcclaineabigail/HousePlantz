using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Models
{
    public class PlantList
    {
        public List<Plant> Catalog { get; set; }

        public PlantList()
        {
            this.Catalog = new List<Plant>();
        }

        public void addPlant(Plant plantToAdd)
        {
            Catalog.Add(plantToAdd);
        }
    }
}
