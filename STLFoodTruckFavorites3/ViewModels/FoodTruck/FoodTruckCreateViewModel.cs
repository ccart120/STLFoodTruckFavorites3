using STLFoodTruckFavorites3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.ViewModels.FoodTruck
{
    public class FoodTruckCreateViewModel
    {

        private ApplicationDbContext context;

        public FoodTruckCreateViewModel() { }

        public void Persist(ApplicationDbContext context)
        {
            Models.FoodTruck foodTruck = new Models.FoodTruck()
            {
                Name = this.Name,
                Description = this.Description,
            };
            context.FoodTrucks.Add(foodTruck);
            context.SaveChanges();
        }


        //public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

    }
}
