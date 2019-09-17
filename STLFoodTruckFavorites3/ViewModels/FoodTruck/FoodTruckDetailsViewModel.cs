using STLFoodTruckFavorites3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace STLFoodTruckFavorites3.ViewModels.FoodTruck
{
    public class FoodTruckDetailsViewModel
    {
        //need to pass the id of the food truck object that was clicked on
        //need to get the Location and Category of the selected food truck and properties associated with them

        public FoodTruckDetailsViewModel() { }

        public FoodTruckDetailsViewModel(ApplicationDbContext context, int id)
        {
            //Models.FoodTruck foodTruck = context.FoodTrucks
                //.Single(f => f.ID == id);
            Models.FoodTruck foodTruck = context.FoodTrucks.Include(ft => ft.Category).Single(ft => ft.ID == id);

            FoodTruckDetailsViewModel model = new FoodTruckDetailsViewModel();
            Name = foodTruck.Name;
            Description = foodTruck.Description;
            Category = foodTruck.Category.CategoryName;

            //LocationFoodTrucks = foodTruck.LocationFoodTrucks;
            //LocationNames = model.GetLocationNames(foodTruck);
            //FtCategoryID = model.GetCategoryID(foodTruck);
        }
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }



        //public string LocationNames { get; set; }
        //public int FtCategoryID { get; set; }

        //public List<Models.LocationFoodTruck> LocationFoodTrucks { get; set; }

        //Try this method to get the location objects and location names

        //private string GetLocationNames(Models.FoodTruck foodTruck)
        //{

        //    return string.Join(",", foodTruck.LocationFoodTrucks
        //        //.Where(lft => lft.LocationID == lft.foodTruck.ID)
        //        .Select(lft => lft.Location.Name)
        //        .Distinct());

        //}

        //private int GetCategoryID(Models.FoodTruck foodTruck)
        //{
        //    //then, get the category for the food truck id that was passed in
        //    //find the food truck where the CategoryID property of that food truck is the same as
        //    //the Category object's ID

        //    //that same food truck object is passed in, so we need to get the category and catID associated with that food truck
        //    Models.Category category = context.Categories
        //        .Include(c => c.FoodTrucks)
        //        .Single(c => c.ID == c.FoodTrucks.CategoryID);
        //    return Models.FoodTruck.CategoryID;
        //}





    }
}
