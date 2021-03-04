using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Models
{
    public class PlantCatalog
    {
        public long PlantCatalogId { get; set; }
        public List<Plant> Plants { get; set; }

    }
}
