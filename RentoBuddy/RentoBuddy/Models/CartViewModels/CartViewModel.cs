using RentoBuddy.Models.HotelViewModels;
using RentoBuddy.Models.OrderViewModels;
using System.Collections.Generic;

namespace RentoBuddy.Models.CartViewModels
{
    public class CartViewModel
    {
        public List<OrderProductModel> ProductsInCart { get; set; }

        public CustomerModel CustomerModel { get; set; }

        public string CouponCodeApplied { get; set; }
    }
}
