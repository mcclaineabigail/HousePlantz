using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HousePlantz.Data.Models
{
    public class OwnedPlant
    {
        public int Id { get; set; }
        public Plant Plant { get; set; }
        public string NickName { get; set; }
        public Room Room { get; set; }

    }
}
