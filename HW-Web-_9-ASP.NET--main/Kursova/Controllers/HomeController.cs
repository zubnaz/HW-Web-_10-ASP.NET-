using DataProject.Data;
using Kursova.Helper;
using Kursova.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    public class HomeController : Controller
    {
        public readonly AutoDbContext adc;
        public HomeController(AutoDbContext adc)
        {
            this.adc = adc;
        }

        public IActionResult Index()
        {
            List<int> idFavorites = HttpContext.Session.Get<List<int>>("favorites_list");

            this.ViewBag.Ids = idFavorites;

                return View(adc);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
