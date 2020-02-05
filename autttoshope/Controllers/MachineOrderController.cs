using autttoshope.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace autttoshope.Controllers
{
    public class MachineOrderController : Controller
    {
        private readonly ApplicationContext _uc;

        public MachineOrderController(ApplicationContext context)
        {
            this._uc = context;
        }
        [HttpGet]
        public IActionResult MachineOrder()
        {
            ViewBag.Car = new SelectList(_uc.Cars.ToList(), nameof(Car.Id), nameof(Car.NameCar), nameof(Car.Color), nameof(Car.Price));
            ViewBag.Category = new SelectList(_uc.Categories.ToList(), nameof(Category.Id), nameof(Category.CategoryName));
            return View();
        }
        [HttpPost]
        public IActionResult MachineOrder (MachineOrder model, string phone)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var human = _uc.Users.Single(h => h.Id == userId);
            model.Person = human;

            model.Phone = phone;
            var carr = _uc.Cars.Single(h => h.Id == 1);
            model.Car = carr;
            var catt = _uc.Categories.Single(h => h.Id == 1);
            model.Category = catt;
            _uc.MachineOrders.Add(model);
            _uc.SaveChanges();
            ViewData["message"] = "Заказ получен";
            return View("~/View/MachineOrder/MachineOrder.cshtml");
        }
        /*[HttpGet]
        public IActionResult MachineOrder (int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.CarId = id;
            return View();
        }
        [HttpPost]
        public string MachineOrder (MachineOrder machineOrder)
        {
            _uc.MachineOrders.Add(machineOrder);
            _uc.SaveChanges();
            return machineOrder.Person + "с вами свяжутся в течении минуты";
        }*/
    }
}
