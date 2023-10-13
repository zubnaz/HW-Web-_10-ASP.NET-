using DataProject.Data;
using DataProject.Data.Entitys;
using Kursova.Helper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    public class FavoritesController : Controller
    {
        public readonly AutoDbContext adc;
        public FavoritesController(AutoDbContext adc)
        {
            this.adc = adc;
        }
        public IActionResult Index()
        {
            List<int> idList = null;
            idList = HttpContext.Session.Get<List<int>>("favorites_list");

            List<Auto> autos = new List<Auto>();

            if (idList !=null)
               autos = adc.Autos.Where(a => idList.Contains(a.Id)).ToList();

            return View(autos);
        }
        public IActionResult AddToFavorite(int id)
        {
            List<int>? idList = HttpContext.Session.Get<List<int>>("favorites_list");
            if(idList == null)
            {
                idList = new List<int>();
            }
            idList.Add(id);
            HttpContext.Session.Set("favorites_list", idList);


            return RedirectToAction("Index","Home");
        }
        public IActionResult RemoveFromFavorites(int id,string controllerName)
        {
            List<int>? idList = HttpContext.Session.Get<List<int>>("favorites_list");
            if(idList !=null)
                idList.Remove(id);
            HttpContext.Session.Set("favorites_list", idList);

            return RedirectToAction("Index", $"{controllerName}");
        }
    }
}
