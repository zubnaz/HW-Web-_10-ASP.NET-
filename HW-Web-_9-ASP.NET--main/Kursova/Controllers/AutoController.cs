using DataProject.Data;
using DataProject.Data.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    public class AutoController : Controller
    {
        // AutoDbContext adc = new AutoDbContext();
        public readonly AutoDbContext adc;
        public AutoController(AutoDbContext adc)
        {
            this.adc = adc;
        }
        public void Colors()
        {
            this.ViewBag.Colors = new SelectList(adc.Colors.ToList(), "Id", "ColorName");
        }
        public IActionResult Index()
        {
            return View(adc);
        }
        [HttpGet]
        public IActionResult AddCar()
        {
            Colors();
            return View();
        }
        [HttpPost]
        public IActionResult AddCar(Auto auto)
        {
            if (!ModelState.IsValid) { Colors(); return View(auto); }
               

            adc.Autos.Add(auto);
            adc.SaveChanges();
            //this.ViewBag = adc.Colors;
            return RedirectToAction("Index");
        }
        public IActionResult Information(int id,string controllerName)
        {
            this.ViewBag.String = controllerName;
           var car = adc.Autos.Include(c => c.Color);
            foreach (var item in car)
            {
                if(item.Id == id) return View(item);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            adc.Autos.Remove(adc.Autos.Find(id));
            adc.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var car = adc.Autos.Include(c => c.Color);
            Colors();
            foreach (var item in car)
            {
                if (item.Id == id) return View(item);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Edit(Auto auto)
        {
            if (!ModelState.IsValid) { Colors(); return View(auto); }
               

            adc.Autos.Update(auto);
            adc.SaveChanges();
            //this.ViewBag = adc.Colors;
            return RedirectToAction("Index");
        }
    }

}
