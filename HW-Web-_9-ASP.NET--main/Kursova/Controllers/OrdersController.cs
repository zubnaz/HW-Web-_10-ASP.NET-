using DataProject.Data;
using DataProject.Data.Entitys;
using Kursova.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Kursova.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {
        public readonly AutoDbContext adc;
        private string userId => User.FindFirstValue(ClaimTypes.NameIdentifier);
        public OrdersController(AutoDbContext adc)
        {
            this.adc = adc;
        }
        public IActionResult Index()
        {
            
            return View(adc.Orders.Include(o => o.Auto).Where(o=>o.UserId==userId).ToList());
        }
        public IActionResult Buy(int id,string controllerName)
        {
            var order = new Order()
            {
                AutoId = id,
                UserId = userId,
                Date = DateTime.Now
            };
            List<int>? idList = HttpContext.Session.Get<List<int>>("favorites_list");
            if(idList!=null)
                idList.Remove(id);
            HttpContext.Session.Set("favorites_list", idList);
            adc.Orders.Add(order);
            adc.SaveChanges();
            return RedirectToAction($"{controllerName}","Index");
        }
    }
}
