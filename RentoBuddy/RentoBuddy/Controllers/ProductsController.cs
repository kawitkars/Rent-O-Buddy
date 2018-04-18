using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RentoBuddy.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult GetAllProducts()
        {
            return View("Product");
        }
    }
}