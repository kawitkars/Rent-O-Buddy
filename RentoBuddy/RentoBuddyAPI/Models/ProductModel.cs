using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddyAPI.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductDetails { get; set; }

        public string Manufacturer { get; set; }

        public bool IsInStock { get; set; }

        public int Availability { get; set; }

        public string ProductCategory { get; set; }

        public double RentPerMonth { get; set; }

        public string ProductImageLink { get; set; }
    }
}
