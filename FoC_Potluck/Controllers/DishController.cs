using FoC_Potluck.Models;
using Microsoft.AspNetCore.Mvc;

namespace FoC_Potluck.Controllers
{
    public class DishController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RegisterDish()
        {
            return View();
        }

        public IActionResult Confirmation(Dish dish)
        {
            bool errorFound = false;

            if (dish.DishName == null || dish.DishName.Length <= 2)
            {
                ViewBag.DishNameMessage = "*Please enter a valid dish name";
                errorFound = true;
            }
            
            
            if (dish.DishDesc == null)
            {
                ViewBag.Description = $"Dish Description: not provided";
            }
            else
            {
                ViewBag.Description = $"Dish Description: {dish.DishDesc}";
            }

            if (errorFound)
            {
                ViewBag.ErrorMessage = "Invalid information was provided. Please try again.";
                return View("RegisterDish");
            }
            else
            {
                return View(dish);
            }

        }

    }
}
