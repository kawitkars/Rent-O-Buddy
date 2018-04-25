using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddyAPI.Models
{
    public class ProductManager
    {
        List<ProductModel> _products;
        public static int productId = 1;

        public ProductManager()
        {
            try
            {
                if (File.Exists("products.txt"))
                {
                    _products = ReadProductList().ToList();
                }
                else
                {
                    _products = new List<ProductModel>()
                    {
                        new ProductModel()
                        {
                            ProductId = productId++,
                            ProductCategory = "Living",
                            Availability = 20,
                            Manufacturer = "Rivet Sloane",
                            IsInStock = true,
                            ProductDetails="Sofa set for Living Room",
                            ProductName = "Sofa Set 1",
                            RentPerMonth = 50.0,
                            ProductImageLink = "https://images-na.ssl-images-amazon.com/images/I/31ymbew4cBL._AC_UL255_SR306,255_FMwebp_QL65_.jpg"
                        },
                        new ProductModel()
                        {
                            ProductId = productId++,
                            ProductCategory = "Bedroom",
                            Availability = 50,
                            Manufacturer = "ABCD",
                            IsInStock = true,
                            ProductDetails="Specious bed for BedRoom",
                            ProductName = "Bed 1",
                            RentPerMonth = 150.0,
                            ProductImageLink = "https://images-na.ssl-images-amazon.com/images/I/51THzBxfwhL.jpg"
                        },
                        new ProductModel()
                        {
                            ProductId = productId++,
                            ProductCategory = "Dining",
                            Availability = 10,
                            Manufacturer = "ABCD",
                            IsInStock = true,
                            ProductDetails="Dining Table for Dining Room",
                            ProductName = "Dining Table 1",
                            RentPerMonth = 80.0,
                            ProductImageLink = "https://images-na.ssl-images-amazon.com/images/I/419cDOzZygL._AC_US240_QL65_.jpg"
                        },
                        new ProductModel()
                        {
                            ProductId = productId++,
                            ProductCategory = "Storage",
                            Availability = 20,
                            Manufacturer = "ABCD",
                            IsInStock = true,
                            ProductDetails="Cardboard shelf for Storage",
                            ProductName = "Shelf 1",
                            RentPerMonth = 25.0,
                            ProductImageLink = "https://images-na.ssl-images-amazon.com/images/I/51qh-lzKHzL._AC_US240_QL65_.jpg"
                        },
                        new ProductModel()
                        {
                            ProductId = productId++,
                            ProductCategory = "Study",
                            Availability = 30,
                            Manufacturer = "ABCD",
                            IsInStock = true,
                            ProductDetails="table for Study",
                            ProductName = "Study table 1",
                            RentPerMonth = 50.0,
                            ProductImageLink = "https://images-na.ssl-images-amazon.com/images/I/41QeQIr6ftL._AC_US240_QL65_.jpg"
                        }
                        
                    };
                    WriteProductsList(_products);
                }
            }
            catch (IOException ioe)
            {

            }
        }

        IEnumerable<ProductModel> ReadProductList()
        {
            return JsonConvert.DeserializeObject<List<ProductModel>>(File.ReadAllText("products.txt"));
        }

        void WriteProductsList(IEnumerable<ProductModel> products)
        {
            var output = JsonConvert.SerializeObject(products);
            File.WriteAllText("products.txt", output);
        }

        public IEnumerable<ProductModel> GetAll { get { return _products; } }

        public IEnumerable<ProductModel> GetProductsByProductType(string _productCategory)
        {
            return _products.Where(_ => _.ProductCategory == _productCategory).ToList();
        }

        public IEnumerable<ProductModel> GetProductByProductId(int productId)
        {
            return _products.Where(_ => _.ProductId == productId).ToList();
        }

        public void AddProduct(ProductModel ProductModel)
        {
            _products.Add(ProductModel);
            var output = JsonConvert.SerializeObject(_products);
            File.WriteAllText("products.txt", output);
        }

        public bool RemoveProduct(int productId)
        {
            if (!_products.Any(_ => _.ProductId == productId)) return false;
            _products.RemoveAll(_ => _.ProductId == productId);
            return true;
        }

        public bool EditProduct(ProductModel productModel)
        {
            var _product = _products.FirstOrDefault(_ => _.ProductId == productModel.ProductId);
            if (_product == null) return false;
            //_product.ProductId = productModel.ProductId;
            //_product.Availability = productModel.Availability;
            //_product.ProductsAvailable = productModel.ProductsAvailable;
            //_product.ProductTariff = productModel.ProductTariff;

            return true;
        }
    }
}
