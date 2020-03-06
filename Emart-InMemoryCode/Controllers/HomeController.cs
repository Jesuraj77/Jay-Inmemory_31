using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Emart_InMemoryCode.Models;
using Emart.Models;
using Emart.BusinessLayer.Interfaces;

namespace Emart_InMemoryCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _service;
        public HomeController(IProductServices service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var productId = RandomNumber(1, 999999);
            var productName = "Ps4_" + productId;
            var productTest = new Product { Id = productId, Name = productName };
            await _service.CreateProductAsync(productTest);

            return View();
        }


        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

     
        public  async Task<ActionResult> About()
        {
            var products = await _service.GetAllProductsAsync();
            return View(products);
        
          //  return Json(products);
        }
        


        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
