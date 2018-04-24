using RentoBuddy.Models.HotelViewModels;
using RentoBuddy.Models.OrderViewModels;
using RentoBuddy.Models.PaymentViewModels;
using RentoBuddy.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddy.Models.CartViewModels
{
    public class OrderModel
    {
        public int OrderId { get; set; }

        public CustomerModel CustomerModel { get; set; }

        public PaymentModel PaymentModel { get; set; }

        public List<OrderProductModel> OrderProductModel { get; set; }

        public double TotalRentalDeposit { get; set; }

        public double TotalRentAmount { get; set; }

        public double TotalCostForOrder { get; set; }

        public double TaxesApplied { get; set; }

        public string DiscountCode { get; set; }

        public double DiscountApplied { get; set; }
		
		public DateTime RentStartDate { get; set; }
		
		public DateTime RentEndDate { get; set; }
    }
}
