using Microsoft.EntityFrameworkCore;
using STLFoodTruckFavorites3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.ViewModels.FoodTruck
{
    public class FoodTruckListViewModel
    {
        public static List<FoodTruckListViewModel> GetFoodTruckListViewModels(ApplicationDbContext context, string searchString)
        {
            
            List<Models.FoodTruck> foodTrucks = context.FoodTrucks.Include(ft => ft.Category).ToList();

            List<FoodTruckListViewModel> foodTruckListViewModels = new List<FoodTruckListViewModel>();
            foreach (Models.FoodTruck foodTruck in foodTrucks)
            {
                FoodTruckListViewModel viewModel = new FoodTruckListViewModel();
                viewModel.ID = foodTruck.ID;
                viewModel.Name = foodTruck.Name;
                viewModel.Description = foodTruck.Description;
                viewModel.Category = foodTruck.Category.CategoryName;
                foodTruckListViewModels.Add(viewModel);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                foodTruckListViewModels = foodTruckListViewModels.Where(f => f.Name.Contains(searchString)).ToList();
            }
            return foodTruckListViewModels;

        }

       
        
            
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        //public List<FoodTruckListViewModel> SearchResults { get; set; }
    }
}
