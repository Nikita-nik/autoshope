using autttoshope.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(Roles = "employee")]
        public IActionResult Index() => View(_uc.Cars.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Car model)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car { NameCar = model.NameCar, ShortDesc = model.ShortDesc, LongDesc = model.LongDesc, Color = model.Color, Price = model.Price, Category = model.Category };
                _uc.Cars.Add(car);
                _uc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
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
        public async Task<IActionResult> Edit(Car model)
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
        public async Task<ActionResult> Delete(int id)
        {
            Car car = _uc.Cars.Single(h => h.Id == id);
            if (car != null)
            {
                _uc.Cars.Remove(car);
                _uc.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
