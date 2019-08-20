﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.Models
{
    public class FoodTruck
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public List<LocationFoodTruck> LocationFoodTrucks { get; set; }
    }
}
