using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RentoBuddy.HelperMethods;
using RentoBuddy.Models.CartViewModels;

namespace RentoBuddy.Controllers
{
    public class OrderController : Controller
    {
        public static int orderId = 1;

        [HttpPost]
        public IActionResult MakePayment(OrderModel orderModel)
        {
            CartViewModel cartViewModel = HttpContext.Session.GetObjectFromJson<CartViewModel>("CartViewModel");

            orderModel.CustomerModel = new Models.HotelViewModels.CustomerModel();
            orderModel.CustomerModel = cartViewModel.CustomerModel;
            orderModel.DiscountCode = cartViewModel.CouponCodeApplied;
            orderModel.OrderId = orderId++;
            orderModel.OrderProductModel = new List<Models.OrderViewModels.OrderProductModel>();
            orderModel.OrderProductModel = cartViewModel.ProductsInCart;
            orderModel.PaymentModel = new Models.PaymentViewModels.PaymentModel();
            orderModel.TaxesApplied = 20.0;
            orderModel.TotalCostForOrder = 400;
            orderModel.TotalRentalDeposit = 200;
            orderModel.TotalRentAmount = 300;

            HttpContext.Session.SetObjectAsJson("OrderModel", orderModel);
            return View("Payment");
        }
        

        [HttpPost]
        public IActionResult OrderReceipt(OrderModel orderModel)
        {
            //OrderModel orderModel = new OrderModel();
            //orderModel.CustomerModel = new Models.HotelViewModels.CustomerModel();
            //orderModel.CustomerModel.Address = new Models.HotelViewModels.AddressModel();
            //orderModel.CustomerModel.Address = cartViewModel.CustomerModel.Address;
            //orderModel.CustomerModel = cartViewModel.CustomerModel;
            //orderModel.DiscountApplied = 

            return View();
        }

    }
}