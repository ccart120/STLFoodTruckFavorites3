using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            Models.FoodTruck foodTruck = context.FoodTrucks.Include(ft => ft.Category)
                .Single(f => f.ID == id);
            //Models.Category category = context.Categories.Single(c => c.ID == CategoryID);
            Name = foodTruck.Name;
            Description = foodTruck.Description;
            CategoryID = foodTruck.CategoryID;
           // context.Categories.Single(c => c.ID == CategoryID)
            CategoryName = foodTruck.Category.CategoryName;
            //context.Categories.Single(c => c.ID == CategoryID);
            this.Categories = new SelectList(context.Categories.ToList(), "ID", "CategoryName");
        }

        public void Persist(ApplicationDbContext context, int id)
        {
            Models.FoodTruck foodTruck = new Models.FoodTruck()
            {
                ID = id,
                Name = this.Name,
                Description = this.Description,
                //category.CategoryName = this.CategoryName,
                //context.Categories.Single(c => c.ID == CategoryID),
                //Category.CategoryName = this.Category,
                CategoryID = this.CategoryID,
                //categoryID has to equal Category.ID?
            };
            context.Update(foodTruck);
           // Models.Category category = context.Categories.Single(c => c.ID == CategoryID);
                //new Models.Category{ ID = categoryID };
                //CategoryIDs.Select(catID => new Models.CategoryLocation { LocationID = locationID, CategoryID = catID })
            //foodTruck.Category = category;
            context.SaveChanges();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public int CategoryID { get; set; }
        //public Category Category { get; set; }
        public string CategoryName { get; set; }
        public SelectList Categories { get; set; }
    }
}