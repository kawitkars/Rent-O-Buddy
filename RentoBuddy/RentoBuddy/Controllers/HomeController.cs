using Microsoft.AspNetCore.Mvc;
using RentoBuddy.Models;
using RentoBuddy.Models.ProductViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RentoBuddy.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //public async Task OnGetAsync(string searchproduct)
        //{
        //    ProductModel model = new ProductModel();
            
        //    if (!String.IsNullOrEmpty(searchproduct))
        //    {
        //        model.ProductName.Contains(searchproduct);
        //        Products product = model.Where(s => s.prContains(searchString));
        //    }

        //    products = await products.ToListAsync();
        //}
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
