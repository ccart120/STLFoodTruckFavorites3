using STLFoodTruckFavorites3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFoodTruckFavorites3.ViewModels.Category
{
    public class CategoryCreateViewModel
    {
        private ApplicationDbContext context;

        public CategoryCreateViewModel() { }

        public void Persist(ApplicationDbContext context)
        {
            Models.Category category = new Models.Category()
            {
                CategoryName = this.CategoryName
            };
            context.Categories.Add(category);
            context.SaveChanges();
        }

        public string CategoryName { get; set; }
    }
}
