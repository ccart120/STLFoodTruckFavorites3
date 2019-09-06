using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using STLFoodTruckFavorites3.Data;
using STLFoodTruckFavorites3.Models;
using STLFoodTruckFavorites3.ViewModels.FoodTruck;


namespace STLFoodTruckFavorites3.Controllers
{
    public class FoodTruckController : Controller
    {
        private ApplicationDbContext context;
        public List<FoodTruck> foodTrucks = new List<FoodTruck>();

        public FoodTruckController(ApplicationDbContext context)
        {
            this.context = context;
        }
        

        [HttpGet]
        public IActionResult Index(string searchString)
        {
            List<FoodTruckListViewModel> models = FoodTruckListViewModel.GetFoodTruckListViewModels(context, searchString);
            

            
            return View(models);
        }



        //[HttpPost]
        //public string Index(List<FoodTruckListViewModel> models, string searchString)
        //{
        //    var foodTrucks = from f in models
        //             select f;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        foodTrucks = foodTrucks.Where(f => f.Name.Contains(searchString)).ToList();
        //    }
            
        //   // return View(models);
        //   /return "From [HttpPost]Index: filter on " + searchString;
        //}

        //public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        //{
        //    List<FoodTruck> foodTrucks = new List<FoodTruck>();
        //    if (SearchBy == "ID")
        //    {
        //        try
        //        {
        //            int Id = Convert.ToInt32(SearchValue);
        //            foodTrucks = context.FoodTrucks.Where(x => x.ID == Id || SearchValue == null).ToList();
        //        }
        //        catch (FormatException)
        //        {
        //            Console.WriteLine("{0} is not an ID", SearchValue);
        //        }
        //        //return Json(foodTrucks, JsonRequestBehavior.AllowGet);
        //        return Json(foodTrucks);
        //    }
        //    else
        //    {
        //        foodTrucks = context.FoodTrucks.Where(x => x.Name.Contains(SearchValue) || SearchValue == null).ToList();
        //        // return Json(foodTrucks, JsonRequestBehavior.AllowGet);
        //        return Json(foodTrucks);

        //    }
        //}

        public IActionResult Details(int id)
        {
           
            return View(new FoodTruckDetailsViewModel(context, id));
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminIndex(string searchString)
        {
            List<FoodTruckListViewModel> models = FoodTruckListViewModel.GetFoodTruckListViewModels(context, searchString);
            return View(models);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]

        public IActionResult Create()
        {
            FoodTruckCreateViewModel model = new FoodTruckCreateViewModel(context);
            return View(model);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]

        public IActionResult Create(FoodTruckCreateViewModel model)
        {
            model.Persist(context);
            return RedirectToAction(actionName: nameof(Index));
            //return View(model);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]

        public IActionResult Edit(int id)
        {
            return View(model: new FoodTruckEditViewModel(context, id));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]

        public IActionResult Edit(FoodTruckEditViewModel foodTruckEditViewModel, int id)
        {
            foodTruckEditViewModel.Persist(context, id);
            return RedirectToAction(actionName: nameof(Index));

        }
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            foodTrucks = context.FoodTrucks.ToList();
            FoodTruck foodTruck = foodTrucks.SingleOrDefault(f => f.ID == id);
            context.Remove(foodTruck);
            context.SaveChanges();
            return RedirectToAction(actionName: nameof(Index));
        }
    }
}
