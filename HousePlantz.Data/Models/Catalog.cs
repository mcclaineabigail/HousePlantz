using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Models
{
    public class Catalog
    {
        public int Id { get; set; }
        public string User { get; set; }
        public List<OwnedPlant> Plants { get; set; }

    }
}
