using autttoshope.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Controllers
{
    public class CarController : Controller
    {
        private readonly ApplicationContext _uc;

        public CarController(ApplicationContext context)
        {
            this._uc = context;
        }

        /* [Authorize(Roles = "employee")]*/

        public IActionResult Create()
        {
            ViewBag.Categories = new DBhelp(_uc).GetDataSelectListItems<Category>().Result;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car model)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car {
                    Img = model.Img, 
                    NameCar = model.NameCar, 
                    ShortDesc = model.ShortDesc, 
                    LongDesc = model.LongDesc, 
                    Color = model.Color, 
                    Price = model.Price, 
                    CategoryId = model.CategoryId,
                    IsBestSeller=model.IsBestSeller,
                    OnSale=true
                };
                _uc.Cars.Add(car);
                _uc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            Car car = _uc.Cars.Single(h => h.Id == id);
            if (car == null)
            {
                return NotFound();
            }
            Car model = new Car { Id = car.Id, NameCar = car.NameCar, ShortDesc = car.ShortDesc, LongDesc = car.LongDesc, Color = car.Color, Price = car.Price, Category = car.Category };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Car model)
        {
            if (ModelState.IsValid)
            {
                Car car = _uc.Cars.Single(h => h.Id == model.Id);
                if (car != null)
                {
                    car.NameCar = model.NameCar;
                    car.ShortDesc = model.ShortDesc;
                    car.LongDesc = model.LongDesc;
                    car.Color = model.Color;
                    car.Price = model.Price;
                    car.Category = model.Category;

                    _uc.Update(car);
                    _uc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Car car = _uc.Cars.Single(h => h.Id == id);
            if (car != null)
            {
                _uc.Cars.Remove(car);
                _uc.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            var cars = await _uc.Cars.AsNoTracking().Include(c=>c.Category).ToListAsync();
            return View(cars);
        }
       
       /* [HttpPost]
        public async Task<ActionResult> Buy()
        {
            var cars = await _uc.Cars.AsNoTracking().Include(c => c.Category).ToListAsync();
            return View(cars);
        }*/
    }
}
