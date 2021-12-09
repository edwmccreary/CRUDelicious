using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }

        //[HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.RecentDishes = _context.Dishes.OrderByDescending(d => d.UpdatedAt);
            return View();
        }

        [HttpGet("new_dish")]
        public IActionResult NewDish(){
            return View();
        }

        [HttpPost("add_dish")]
        public IActionResult AddDish(Dish newDish){
            if(ModelState.IsValid){
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("NewDish",newDish);
            }
        }

        [HttpGet("dish/{id}")]
        public IActionResult Dish(int id){
            Dish getDish = _context.Dishes.FirstOrDefault(d => d.DishID == id);
            return View(getDish);
        }

        [HttpGet("edit_dish/{id}")]
        public IActionResult EditDish(int id){
            Dish getDish = _context.Dishes.FirstOrDefault(d => d.DishID == id);
            return View(getDish);
        }

        [HttpPost("update_dish/{id}")]
        public IActionResult UpdateDish(int id, Dish updatedDish)
        {
            updatedDish.DishID = id;
            if(ModelState.IsValid){
                Dish getDish = _context.Dishes.FirstOrDefault(d => d.DishID == id);
                getDish.Name = updatedDish.Name;
                getDish.Chef = updatedDish.Chef;
                getDish.Calories = updatedDish.Calories;
                getDish.Tastiness = updatedDish.Tastiness;
                getDish.Description = updatedDish.Description;
                getDish.UpdatedAt = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            else{
                return View("EditDish",updatedDish);
            }
        }

        [HttpGet("delete_dish/{id}")]
        public IActionResult DeleteDish(int id){
            Dish deleteDish = _context.Dishes.FirstOrDefault(d => d.DishID == id);
            _context.Dishes.Remove(deleteDish);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
