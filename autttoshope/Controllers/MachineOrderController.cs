using autttoshope.Models;
using autttoshope.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult MachineOrder()
        {
            ViewBag.Categories = new SelectList(_uc.Categories.ToList(), nameof(Category.Id), nameof(Category.Name));
            return View();
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> MachineOrder (OrderVM model)
        {
 
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var human = _uc.Users.Single(h => h.Id == userId);

            _uc.MachineOrders.Add(new Models.MachineOrder
            { 
            Car = new Car
            {
                Color = model.Color,
                CategoryId = model.CategoryId,
                IsBestSeller = false,
                OnSale = false,
                NameCar = model.NameCar
            },
            Phone=model.Phone,
            ToBuy = false,
               Person=human
            });
            await _uc.SaveChangesAsync();
            ViewData["message"] = "Заказ получен";
            return RedirectToAction("Index","Car");
        }
        [Authorize(Roles = "user")]
        [HttpGet]
        public IActionResult BuyOrder(int id)
        {
            ViewBag.Categories = new DBhelp(_uc).GetDataSelectListItems<Category>().Result;
            ViewBag.id = id;
            var car = _uc.Cars.Find(id);

            return View(car);
        }
        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IActionResult> BuyOrder(string phone, int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var human = _uc.Users.Single(h => h.Id == userId);
            var car = _uc.Cars.Find(id);
            _uc.MachineOrders.Add(new Models.MachineOrder
            {
                Car = car,
                Phone = phone,
                ToBuy = true,
                Person = human
            });
            await _uc.SaveChangesAsync();
            ViewData["message"] = "Заказ получен";
            return RedirectToAction("Index", "Car");
        }
        [Authorize(Roles = "employee")]
        [HttpGet]
        public async Task<ActionResult> ListOrders()
        {
            var orders = await _uc.MachineOrders
                .AsNoTracking()
                .Include(mo => mo.Person)
                .Include(mo => mo.Car)
                .ThenInclude(c=>c.Category)
                .ToListAsync();
            return View(orders);
        }
        [Authorize(Roles = "employee")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var order = _uc.MachineOrders.Where(mo=>mo.Id==id).Include(mo=>mo.Car);
            if (order != null)
            {
                _uc.Remove(order);
                _uc.SaveChanges();  
            }
            return RedirectToAction("Index");
        }
       
    }
}
