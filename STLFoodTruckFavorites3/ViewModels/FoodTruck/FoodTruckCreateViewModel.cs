using Microsoft.AspNetCore.Mvc.Rendering;
using STLFoodTruckFavorites3.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.ViewModels.FoodTruck
{
    public class FoodTruckCreateViewModel
    {

        public FoodTruckCreateViewModel() { }
        //passes in Category objects so i can get the Category.ID
        public FoodTruckCreateViewModel(ApplicationDbContext context)
        {
            this.Categories = new SelectList(context.Categories.ToList(),"ID","CategoryName");
        }

        //have to pass in the category.ID, then assign it to categoryID fk in foodtruck object and save to database
        public void Persist(ApplicationDbContext context)
        {
            Models.Category category = context.Categories.Single(c => c.ID == CategoryID);
            Models.FoodTruck foodTruck = new Models.FoodTruck
            {
                Name = this.Name,
                Description = this.Description,
                Category = category
            };
            context.FoodTrucks.Add(foodTruck);
            context.SaveChanges();
        }
        
       
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public SelectList Categories { get; set; }

    }
}
