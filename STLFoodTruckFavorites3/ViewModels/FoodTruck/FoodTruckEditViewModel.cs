using STLFoodTruckFavorites3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.ViewModels.FoodTruck
{
    public class FoodTruckEditViewModel
    {
        public FoodTruckEditViewModel() { }

        public FoodTruckEditViewModel(ApplicationDbContext context, int id)
        {
            Models.FoodTruck foodTruck = context.FoodTrucks
                .Single(f => f.ID == id);
            Name = foodTruck.Name;
            Description = foodTruck.Description;
        }

        public void Persist(ApplicationDbContext context, int id)
        {
            Models.FoodTruck foodTruck = new Models.FoodTruck()
            {
                ID = id,
                Name = this.Name,
                Description = this.Description,
            };
            context.Update(foodTruck);
            context.SaveChanges();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}