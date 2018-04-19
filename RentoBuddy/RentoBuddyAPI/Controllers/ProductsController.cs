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
    public class ProductsController : Controller
    {
        ProductManager pm = new ProductManager();
        private IHostingEnvironment _Env;
        public ProductsController(IHostingEnvironment envrnmt)
        {
            _Env = envrnmt;
        }

        // GET api/products
        [HttpGet]
        [Route("api/products")]
        public IEnumerable<ProductModel> GetAsync()
        {
            var webRootInfo = _Env.WebRootPath;
            var file = System.IO.Path.Combine(webRootInfo, "lastaccess.txt");
            System.IO.File.WriteAllText(file, DateTime.Now.ToString());
            return pm.GetAll;
        }

        // GET api/Products/ProductId
        [HttpGet]
        [Route("api/[controller]/{id}")]
        public async Task<IEnumerable<ProductModel>> Get(int productId)
        {
            return await GetAsync(productId);
        }

        private Task<IEnumerable<ProductModel>> GetAsync(int productId)
        {
            return Task.FromResult(pm.GetProductByProductId(productId));
        }

        [HttpPost]
        [Route("api/[controller]/[action]")]
        [ActionName("Post01")]
        public async Task<StatusCodeResult> Post01([FromBody] ProductModel productModel)
        {
            if (productModel == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            if (await PostAsyncPartOne(productModel))
            {
                return await PostAsyncPartTwo(productModel);
            }
            else
            {
                pm.AddProduct(productModel);
                //dbContext.Companies.Add(company);
                //await dbContext.SaveChangesAsync();
                return new StatusCodeResult(201); //created
            }
        }
        private Task<bool> PostAsyncPartOne(ProductModel productModel)
        {
            return Task.FromResult(pm.GetAll.Any(_ => _.ProductId == productModel.ProductId));
        }
        private Task<StatusCodeResult> PostAsyncPartTwo(ProductModel productModel)
        {
            if (pm.EditProduct(productModel))
            {
                return Task.FromResult(new StatusCodeResult(200)); //success
            }
            else
            {
                return Task.FromResult(new StatusCodeResult(404)); //not found
            }
        }

        // add new or edit
        [HttpPut]
        [Route("api/[controller]/[action]")]
        [ActionName("Put01")]
        public async Task<StatusCodeResult> Put01([FromBody] ProductModel productModel)
        {
            if (productModel == null)
            {
                return new Microsoft.AspNetCore.Mvc.BadRequestResult();
            }
            if (await PostAsyncPartOne(productModel))
            {
                return await PostAsyncPartTwo(productModel);
            }
            else
            {
                pm.AddProduct(productModel);
                //dbContext.Companies.Add(company);
                //await dbContext.SaveChangesAsync();
                return new StatusCodeResult(201); //created
            }
        }

        // delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        [Route("api/[controller]/{id}")]
        public async Task<StatusCodeResult> Delete(int productId)
        {
            return await DeleteAsync(productId);
        }
        private Task<StatusCodeResult> DeleteAsync(int productId)
        {
            if (pm.RemoveProduct(productId))
                return Task.FromResult(new StatusCodeResult(200));
            else
                return Task.FromResult(new StatusCodeResult(404));
        }
    }
}