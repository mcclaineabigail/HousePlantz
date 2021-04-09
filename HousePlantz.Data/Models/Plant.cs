using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Enumeration;

namespace HousePlantz.Data.Models
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
