using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace autttoshope.Controllers
{
    public class CabinetController : Controller
    {
        public ActionResult Cabinet()
        {
            return View();
        }

        // GET: Gallery/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Gallery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gallery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Cabinet));
            }
            catch
            {
                return View();
            }
        }
    }
}
