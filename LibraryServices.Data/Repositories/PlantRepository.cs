using HousePlantz.Data.Interfaces;
using HousePlantz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlantz.Data.Repositories
{
    public class PlantRepository : IPlantRepository
    {

        public List<Plant> plants = new List<Plant>()
        {
            new Plant {Id = 1, Name = "Peperomia test 4", Sun = "/light/low-med.png",  Image = "/plant-images/peperomia.PNG", Water = "Allow to Dry", Notes = "Poisonous"},
            new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "/light/low-med.png",  Image = "/plant-images/chinese-evergreen.PNG", Water = "Keep Evenly Moist", Notes = "Poisonous"},
            new Plant {Id = 3, Name = "Grape Ivy", Sun = "/light/med.png",  Image = "/plant-images/grape-ivy.PNG", Water = "Keep Evenly Moist", Notes = "Trailing"},
            new Plant {Id = 4, Name = "Norfolk Island Pine", Sun = "/light/bright.png",  Image = "/plant-images/norfolk-island-pine.PNG", Water = "Allow to Dry", Notes = "Festive"},
            new Plant {Id = 5, Name = "Dieffenbachia", Sun = "/light/low-med.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Poisonous"},  
            new Plant {Id = 6, Name = "Snake Plant", Sun = "/light/any.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Beautiful Vertical Shape"},                                   
            new Plant {Id = 7, Name = "Philodendron", Sun = "/light/any.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Poisonous"},                      
            new Plant {Id = 8, Name = "English Ivy", Sun = "/light/med-bright.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Poisonous"},
            new Plant {Id = 9, Name = "ZZ Plant", Sun = "/light/any.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Poisonous"},                                
            new Plant {Id = 10, Name = "Spider Plant", Sun = "/light/med-bright.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Fun Baby Plants"},
            new Plant {Id = 11, Name = "Arrowhead Vine", Sun = "/light/low-med.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Trailing"},
            new Plant {Id = 12, Name = "Hoya", Sun = "/light/med-bright.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Flowering"},
            new Plant {Id = 13, Name = "Rubber Tree", Sun = "/light/med-bright.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Latex Allergy"},
            new Plant {Id = 14, Name = "Corn Plant", Sun = "/light/med-bright.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Large Leaves"},
            new Plant {Id = 15, Name = "Pothos", Sun = "/light/any.png",  Image = "/plant-images/", Water = "Keep Moderately Dry", Notes = "Poisonous"},
            new Plant {Id = 16, Name = "Cast Iron Plant", Sun = "/light/low.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Toxic to Cats and Dogs"},
            new Plant {Id = 17, Name = "Jade Plant", Sun = "/light/bright.png",  Image = "/plant-images/", Water = "Keep Moderately Dry", Notes = "Succulent"},
            new Plant {Id = 18, Name = "Ponytail Palm", Sun = "/light/bright.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Drought Tolerant"},
            new Plant {Id = 19, Name = "Schefflera", Sun = "/light/med-bright.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Flowering"},
            new Plant {Id = 20, Name = "Calathea", Sun = "/light/low.png",  Image = "/plant-images/", Water = "Keep Evenly Moist", Notes = "Striking Leaf Pattern"},
            new Plant {Id = 21, Name = "Weeping Fig", Sun = "/light/bright.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Also Known as Ficus"},
            new Plant {Id = 22, Name = "Columnea", Sun = "/light/bright.png",  Image = "/plant-images/", Water = "Keep Slighty Moist", Notes = "Bright Orange Flowers"},
            new Plant {Id = 23, Name = "Kalanchoe", Sun = "/light/bright.png",  Image = "/plant-images/", Water = "Allow to Dry", Notes = "Bright Flowers"}

        };
        				
				
				
				
				
    			
				
				
				
				
				
			
				
				
				
				
				
				
				


        public List<Plant> GetAllPlants()
        {
            return plants;
        }

        public Plant GetPlantById(long id)
        {
            var plant = plants.FirstOrDefault(x => x.Id == id);
            return plant;
        }
    }
}
