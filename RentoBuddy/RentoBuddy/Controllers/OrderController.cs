using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentoBuddy.HelperMethods;
using RentoBuddy.Models.CartViewModels;
using RentoBuddy.Models.OrderViewModels;
using RentoBuddy.Models.ProductViewModels;

namespace RentoBuddy.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        public static int orderId = 1;

        [HttpPost]
        [Authorize]
        public IActionResult MakePayment(OrderModel orderModel)
        {
            CartViewModel cartViewModel = HttpContext.Session.GetObjectFromJson<CartViewModel>("CartViewModel");

            orderModel.OrderId = orderId++;
            orderModel.OrderProductModel = new List<Models.OrderViewModels.OrderProductModel>();
            orderModel.OrderProductModel = cartViewModel.ProductsInCart;
            orderModel.PaymentModel = new Models.PaymentViewModels.PaymentModel();
            orderModel.DiscountCode = cartViewModel.CouponCodeApplied;
            
            foreach(OrderProductModel orderProductModel in orderModel.OrderProductModel)
            {
                orderProductModel.RentAmount = orderProductModel.ProductData[0].RentPerMonth *
                    orderProductModel.RentalDurationInMonths;
                orderProductModel.RentalDeposit = 0.10 * orderProductModel.RentAmount;
                orderModel.TotalRentAmount += orderProductModel.RentAmount;
                orderModel.TotalRentalDeposit += orderProductModel.RentalDeposit;
            }

            if(orderModel.DiscountCode == "DISCOUNT10")
            {
                orderModel.DiscountApplied = 0.10 * orderModel.TotalRentAmount;
            }
            else if(orderModel.DiscountCode == "DISCOUNT15")
            {
                orderModel.DiscountApplied = 0.15 * orderModel.TotalRentAmount;
            }
            else if (orderModel.DiscountCode == "DISCOUNT20")
            {
                orderModel.DiscountApplied = 0.2 * orderModel.TotalRentAmount;
            }
            else if (orderModel.DiscountCode == "DISCOUNT50")
            {
                orderModel.DiscountApplied = 0.5 * orderModel.TotalRentAmount;
            }

            orderModel.TaxesApplied = 0.05 * orderModel.TotalRentAmount;
            orderModel.TotalCostForOrder = (orderModel.TotalRentAmount - orderModel.DiscountApplied)
                                            + orderModel.TotalRentalDeposit
                                            + orderModel.TaxesApplied;
            
            HttpContext.Session.SetObjectAsJson("OrderModel", orderModel);
            return View("Payment");
        }
        

        [HttpPost]
        [Authorize]
        public IActionResult OrderReceipt(OrderModel orderModel)
        {
            OrderModel orderModelOld = HttpContext.Session.GetObjectFromJson<OrderModel>("OrderModel");

            //Map all the fields except the Payment UI
            orderModel.CustomerModel = orderModelOld.CustomerModel;
            orderModel.DiscountApplied = orderModelOld.DiscountApplied;
            orderModel.DiscountCode = orderModelOld.DiscountCode;
            orderModel.OrderId = orderModelOld.OrderId;
            orderModel.OrderProductModel = orderModelOld.OrderProductModel;
            orderModel.RentEndDate = orderModelOld.RentEndDate;
            orderModel.RentStartDate = orderModelOld.RentStartDate;
            orderModel.TaxesApplied = orderModelOld.TaxesApplied;
            orderModel.TotalCostForOrder = orderModelOld.TotalCostForOrder;
            orderModel.TotalRentalDeposit = orderModelOld.TotalRentalDeposit;
            orderModel.TotalRentAmount = orderModelOld.TotalRentAmount;

            //Generate an unique order receipt number
            orderModel.OrderReceiptNumber = HelperMethods.HelperMethods.RandomString(10);
            orderModel.RentStartDate = DateTime.Now.AddMonths(1);
            orderModel.RentEndDate = orderModel.RentStartDate.AddMonths(orderModel.OrderProductModel[0].RentalDurationInMonths);

            HttpContext.Session.SetObjectAsJson("OrderModel", orderModel);
            return View();
        }

    }
}