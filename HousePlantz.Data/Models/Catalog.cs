using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Models
{
    public class Catalog
    {
        public long Id { get; set; }
        public string User { get; set; }
        public List<Plant> Plants { get; set; }

    }
}
