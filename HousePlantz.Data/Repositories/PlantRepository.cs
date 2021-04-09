using HousePlantz.Data.Interfaces;
using HousePlantz.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HousePlantz.Data.Repositories
{
    public class PlantRepository //: IPlantRepository
    {
        private PlantCatalogContext _context;


        public PlantRepository(PlantCatalogContext context)
        {
            _context = context;
        }

        //public List<Plant> plants = new List<Plant>()
        //{
        //    new Plant {Id = 1, Name = "Arrowhead Vine", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/arrowhead-vine.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Trailing", NickName = ""},
        //    new Plant {Id = 2, Name = "Calathea", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/calathea.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Striking Leaf Pattern", NickName = ""},
        //    new Plant {Id = 3, Name = "Chinese Evergreen", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/chinese-evergreen.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous", NickName = ""},
        //    new Plant {Id = 4, Name = "Cast Iron Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/cast-iron-plant.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Toxic to Cats and Dogs", NickName = ""},
        //    new Plant {Id = 5, Name = "Columnea", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/columnea.PNG?raw=true", Water = "Keep Slighty Moist", Notes = "Bright Orange Flowers", NickName = ""},
        //    new Plant {Id = 6, Name = "Corn Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/corn-plant.PNG?raw=true", Water = "Allow to Dry", Notes = "Large Leaves", NickName = ""},
        //    new Plant {Id = 7, Name = "Dieffenbachia", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/dieffenbachia.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous", NickName = ""},  
        //    new Plant {Id = 8, Name = "English Ivy", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/english-ivy.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Poisonous", NickName = ""},
        //    new Plant {Id = 9, Name = "Grape Ivy", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/grape-ivy.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Trailing", NickName = ""},
        //    new Plant {Id = 10, Name = "Hoya", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/hoya.PNG?raw=true", Water = "Allow to Dry", Notes = "Flowering", NickName = ""},
        //    new Plant {Id = 11, Name = "Jade Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/jade-plant.PNG?raw=true", Water = "Keep Moderately Dry", Notes = "Succulent", NickName = ""},
        //    new Plant {Id = 12, Name = "Kalanchoe", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/kalanchoe.PNG?raw=true", Water = "Allow to Dry", Notes = "Bright Flowers", NickName = ""},
        //    new Plant {Id = 13, Name = "Norfolk Island Pine", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/norfolk-island-pine.PNG?raw=true", Water = "Allow to Dry", Notes = "Festive", NickName = ""},
        //    new Plant {Id = 14, Name = "Peperomia", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/low-medium.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/peperomia.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous", NickName = ""},
        //    new Plant {Id = 15, Name = "Philodendron", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/philodendron.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous", NickName = ""},                      
        //    new Plant {Id = 16, Name = "Ponytail Palm", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/ponytail-palm.PNG?raw=true", Water = "Allow to Dry", Notes = "Drought Tolerant", NickName = ""},
        //    new Plant {Id = 17, Name = "Pothos", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/pothos.PNG?raw=true", Water = "Keep Moderately Dry", Notes = "Poisonous", NickName = ""},
        //    new Plant {Id = 18, Name = "Rubber Tree", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/rubber-tree.PNG?raw=true", Water = "Allow to Dry", Notes = "Latex Allergy", NickName = ""},
        //    new Plant {Id = 19, Name = "Schefflera", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/schefflera.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Flowering", NickName = ""},
        //    new Plant {Id = 20, Name = "Snake Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/snake.PNG?raw=true", Water = "Allow to Dry", Notes = "Beautiful Vertical Shape", NickName = ""},                                   
        //    new Plant {Id = 21, Name = "Spider Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/med-bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/spider-plant.PNG?raw=true", Water = "Keep Evenly Moist", Notes = "Fun Baby Plants", NickName = ""},
        //    new Plant {Id = 22, Name = "Weeping Fig", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/bright.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/weeping-fig.PNG?raw=true", Water = "Allow to Dry", Notes = "Also Known as Ficus", NickName = ""},
        //    new Plant {Id = 23, Name = "ZZ Plant", Sun = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/light/any.png?raw=true",  Image = "https://github.com/mcclaineabigail/PlantCatalog/blob/main/LibraryServices.Data/Images/plant-images/zz-plant.PNG?raw=true", Water = "Allow to Dry", Notes = "Poisonous", NickName = ""}                                
        //};        				

        //public List<Plant> GetAllPlants()
        //{
        //    return plants;
        //}

        //public Plant GetPlantById(long id)
        //{
        //    var plant = plants.FirstOrDefault(x => x.Id == id);
        //    return plant;
        //}



    }
}
