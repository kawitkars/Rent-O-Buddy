using System;
using System.Collections;
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
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DisplayProductModel(ProductModel productModel)
        {
            
            OrderProductModel orderProductModel = null;
            //OrderProductModel orderProductModelOld = HttpContext.Session.GetObjectFromJson<OrderProductModel>("OrderProductModel");
            
            if (ModelState.IsValid)
            {
                //if (orderProductModelOld != null)
                //{
                //    orderProductModel = new OrderProductModel();
                //    orderProductModel.ProductData = orderProductModelOld.ProductData;
                //    orderProductModel.Quantity = orderProductModelOld.Quantity;
                //    orderProductModel.RentalDurationInMonths = orderProductModelOld.RentalDurationInMonths;
                //    orderProductModel.ProductData.Add(productModel);
                //}
                //else
                //{
                    orderProductModel = new OrderProductModel();
                    orderProductModel.ProductData = new List<ProductModel>();
                    orderProductModel.ProductData.Add(productModel);
                //}
            }
            HttpContext.Session.SetObjectAsJson("OrderProductModel", orderProductModel);
            return View("ProductDetail", orderProductModel);
        }

        [HttpPost]
        public IActionResult AddToCart(OrderProductModel orderProductModel)
        {
            OrderProductModel orderProductModelOld = HttpContext.Session.GetObjectFromJson<OrderProductModel>("OrderProductModel");
            CartViewModel cartViewModelOld = HttpContext.Session.GetObjectFromJson<CartViewModel>("CartViewModel");
            orderProductModel.ProductData = orderProductModelOld.ProductData;
            CartViewModel cartViewModel = null;
            if(ModelState.IsValid)
            {
                if(cartViewModelOld != null)
                {
                    cartViewModel = new CartViewModel();
                    cartViewModel.CouponCodeApplied = cartViewModelOld.CouponCodeApplied;
                    cartViewModel.CustomerModel = cartViewModelOld.CustomerModel;
                    cartViewModel.ProductsInCart = cartViewModelOld.ProductsInCart;

                    //foreach(OrderProductModel orderPrdModel in cartViewModelOld.ProductsInCart)
                    //{
                        
                    //}

                    cartViewModel.ProductsInCart.Add(orderProductModel);
                }
                else
                {
                    cartViewModel = new CartViewModel();
                    cartViewModel.ProductsInCart = new List<OrderProductModel>();
                    cartViewModel.ProductsInCart.Add(orderProductModel);
                }
                
            }
            HttpContext.Session.SetObjectAsJson("CartViewModel", cartViewModel);
            return View("Cart", cartViewModel);
        }
    }
}