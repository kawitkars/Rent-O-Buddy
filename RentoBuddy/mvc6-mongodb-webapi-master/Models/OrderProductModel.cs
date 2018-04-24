using OrderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class OrderProductModel
    {
    public List<Product> ProductData { get; set; }

    public int RentalDurationInMonths { get; set; }

    public double RentalDeposit { get; set; }

    public double RentAmount { get; set; }

    public double TotalCostForProduct { get; set; }

    public int Quantity { get; set; }

    public OrderProductModel() => ProductData = new List<Product>();
    }
}
