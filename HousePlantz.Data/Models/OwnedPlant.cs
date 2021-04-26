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
        public string NickName { get; set; }
        public string Name { get; set; }
        public string Sun { get; set; }
        public string Image { get; set; }
        public string Water { get; set; }
        public string Notes { get; set; }
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

    }
}
