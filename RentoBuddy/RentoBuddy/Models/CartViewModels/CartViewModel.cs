using RentoBuddy.Models.ProductViewModels;
using System.Collections.Generic;

namespace RentoBuddy.Models.CartViewModels
{
    public class CartViewModel
    {
        public List<ProductModel> ProductsInCart { get; set; }
    }
}
