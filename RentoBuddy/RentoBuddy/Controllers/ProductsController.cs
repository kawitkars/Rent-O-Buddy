using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectMariott.Models;
using ProjectMarriott.Models.HotelViewModels;
using RentoBuddy.Models.ProductViewModels;

namespace ProjectMarriott.Controllers
{
    public class ProductsController : Controller
    {
        //Hosted web API REST Service base url  
        string Baseurl = "http://localhost:61223/";
        ProductClient productClient = new ProductClient("http://localhost:50254");
        public async Task<ActionResult> GetAllProducts()
        {
            List<ProductModel> productsList = new List<ProductModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/products/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var productsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    productsList = JsonConvert.DeserializeObject<List<ProductModel>>(productsResponse);

                }
                //returning the employee list to view  
                return View("Products", productsList);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetSearchedProducts(String searchproduct)
        {
            List<ProductModel> productsList = new List<ProductModel>();
            List<ProductModel> productsList1 = new List<ProductModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/products/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var productsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    productsList1 = JsonConvert.DeserializeObject<List<ProductModel>>(productsResponse);
                    productsList = productsList1.Where(s => s.ProductName.ToLower().Contains(searchproduct.ToLower())).ToList();
                }
                //returning the employee list to view  
                return View("Products", productsList);
            }
        }

        [HttpGet]
        public async Task<ActionResult> SearchProductsByCategory(String category)
        {
            List<ProductModel> productsList = new List<ProductModel>();
            List<ProductModel> productsList1 = new List<ProductModel>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add
                    (new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/products/");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var productsResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    productsList1 = JsonConvert.DeserializeObject<List<ProductModel>>(productsResponse);
                    productsList = productsList1.Where(s => s.ProductCategory.ToLower().Contains(category.ToLower())).ToList();
                }
                //returning the employee list to view  
                return View("Products", productsList);
            }
        }

    }
}