using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class OrderModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

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

        public OrderModel()
        {
            CustomerModel = new CustomerModel();
            PaymentModel = new PaymentModel();
            OrderProductModel = new List<OrderProductModel>();
        }
    }
}
   
