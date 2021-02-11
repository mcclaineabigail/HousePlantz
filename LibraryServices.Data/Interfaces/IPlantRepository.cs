using HousePlantz.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HousePlantz.Data.Interfaces
{
    public interface IPlantRepository
    {
        List<Plant> GetAllPlants();

        Plant GetPlantById(long Id);
    }
}
