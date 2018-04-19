using RentoBuddy.Models.ProductViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddy.Models.WishlistViewModels
{
    public class WishlistViewModel
    {
        public List<ProductModel> ProductsInWishlist { get; set; }
    }
}
