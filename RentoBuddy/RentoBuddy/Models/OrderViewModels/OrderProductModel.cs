using RentoBuddy.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddy.Models.OrderViewModels
{
    public class OrderProductModel
    {
        public List<ProductModel> ProductData { get; set; }

        public int RentalDurationInMonths { get; set; }

        public double RentalDeposit { get; set; }

        public double RentAmount { get; set; }

        public double TotalCostForProduct { get; set; }

        public int Quantity { get; set; }
    }



}
