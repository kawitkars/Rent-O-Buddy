using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddy.Models.ProductViewModels
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDetails { get; set; }

        public double RentalDeposit { get; set; }

        public double RentAmount { get; set; }

        public double TotalCostForProduct { get; set; }
    }
}
