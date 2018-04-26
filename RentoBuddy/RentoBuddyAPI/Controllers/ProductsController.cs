using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RentoBuddyAPI.Models;

namespace RentoBuddyAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductsController : Controller
    {
        ProductManager pm = new ProductManager();
        ProductManager objds;
        private IHostingEnvironment _Env;
        public ProductsController(ProductManager pm, IHostingEnvironment envr)
        {
            objds = pm;
            _Env = envr;
        }

        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            return pm.GetAll();
        }



    }
}