using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }

        public List<FoodTruck> FoodTrucks { get; set; }

    }
}
