using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HousePlantz.Models
{
    public class Plant
    {

        public int Id { get; set; }

        public string Name { get; set; }
        public string Sun { get; set; }
        public string Image { get; set; }  
        public string Water { get; set; }
        public string Notes { get; set; }
    }
}
