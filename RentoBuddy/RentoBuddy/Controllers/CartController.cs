using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentoBuddy.HelperMethods;
using RentoBuddy.Models.CartViewModels;
using RentoBuddy.Models.OrderViewModels;
using RentoBuddy.Models.ProductViewModels;

namespace RentoBuddy.Controllers
{
    public class CartController : Controller
    {
        public static int orderId = 1;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayProductModel(ProductModel productModel)
        {
            OrderProductModel orderProductModel = null;
            if (ModelState.IsValid)
            {
                orderProductModel = new OrderProductModel();
                orderProductModel.ProductData = new List<ProductModel>();
                orderProductModel.ProductData.Add(productModel);
            }
            HttpContext.Session.SetObjectAsJson("OrderProductModel", orderProductModel);
            return View("ProductDetail", orderProductModel);
        }

        [HttpPost]
        public IActionResult AddToCart(OrderProductModel orderProductModel)
        {
            OrderProductModel orderProductModelOld = HttpContext.Session.GetObjectFromJson<OrderProductModel>("OrderProductModel");
            orderProductModel.ProductData = orderProductModelOld.ProductData;
            CartViewModel cartViewModel = null;
            if(ModelState.IsValid)
            {
                cartViewModel = new CartViewModel();
                cartViewModel.ProductsInCart = new List<OrderProductModel>();
                cartViewModel.ProductsInCart.Add(orderProductModel);
            }
            return View("Cart", cartViewModel);
        }
    }
}