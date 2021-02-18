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
            new Plant {Id = 1, Name = "Peperomia", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/peperomia.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous"},
            new Plant {Id = 2, Name = "Chinese Evergreen", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/chinese-evergreen.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous"},
            new Plant {Id = 3, Name = "Grape Ivy", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/grape-ivy.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Trailing"},
            new Plant {Id = 4, Name = "Norfolk Island Pine", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/norfolk-island-pine.PNG?raw=true", Water = "Allow to Dry", Notes = "Festive"},
            new Plant {Id = 5, Name = "Dieffenbachia", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/dieffenbachia.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous"},  
            new Plant {Id = 6, Name = "Snake Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/snake.PNG?raw=true", Water = "Allow to Dry", Notes = "Beautiful Vertical Shape"},                                   
            new Plant {Id = 7, Name = "Philodendron", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/philodendron.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous"},                      
            new Plant {Id = 8, Name = "English Ivy", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/english-ivy.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous"},
            new Plant {Id = 9, Name = "ZZ Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/zz-plant.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous"},                                
            new Plant {Id = 10, Name = "Spider Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/spider-plant.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Fun Baby Plants"},
            new Plant {Id = 11, Name = "Arrowhead Vine", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/arrowhead-vine.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Trailing"},
            new Plant {Id = 12, Name = "Hoya", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/hoya.PNG?raw=true", Water = "Allow to Dry", Notes = "Flowering"},
            new Plant {Id = 13, Name = "Rubber Tree", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/rubber-tree.PNG?raw=true", Water = "Allow to Dry", Notes = "Latex Allergy"},
            new Plant {Id = 14, Name = "Corn Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/corn-plant.PNG?raw=true", Water = "Allow to Dry", Notes = "Large Leaves"},
            new Plant {Id = 15, Name = "Pothos", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/pothos.PNG?raw=true", Water = "Keep Moderately Dry", Notes = "Poisonous"},
            new Plant {Id = 16, Name = "Cast Iron Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/cast-iron-plant.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Toxic to Cats and Dogs"},
            new Plant {Id = 17, Name = "Jade Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/jade-plant.PNG?raw=true", Water = "Keep Moderately Dry", Notes = "Succulent"},
            new Plant {Id = 18, Name = "Ponytail Palm", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/ponytail-palm.PNG?raw=true", Water = "Allow to Dry", Notes = "Drought Tolerant"},
            new Plant {Id = 19, Name = "Schefflera", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/schefflera.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Flowering"},
            new Plant {Id = 20, Name = "Calathea", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/calathea.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Striking Leaf Pattern"},
            new Plant {Id = 21, Name = "Weeping Fig", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/weeping-fig.PNG?raw=true", Water = "Allow to Dry", Notes = "Also Known as Ficus"},
            new Plant {Id = 22, Name = "Columnea", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/columnea.PNG?raw=true", Water = "Keep Slighty Moist", Notes = "Bright Orange Flowers"},
            new Plant {Id = 23, Name = "Kalanchoe", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/kalanchoe.PNG?raw=true", Water = "Allow to Dry", Notes = "Bright Flowers"}

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
