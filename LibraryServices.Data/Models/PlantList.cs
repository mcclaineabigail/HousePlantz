using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Models
{
    class PlantList
    {
        public List<Plant> List { get; set; }

        public PlantList()
        {
            this.List = new List<Plant>();
        }
    }
}
