using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Models
{
    public class PlantCatalog
    {
        public long Id { get; set; }
        public List<Plant> Plants { get; set; }

    }
}
