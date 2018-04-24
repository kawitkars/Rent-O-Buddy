using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class Product
    {   
        [BsonId]
        public ObjectId _id { get; set; }
        //public ObjectId Id { get; set; }
        [BsonElement("ProductId")]
        public int ProductId { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        //[BsonElement("Price")]
        //public int Price { get; set; }
        //[BsonElement("Category")]
        //public string Category { get; set; }

        [BsonElement("ProductDetails")]
        public string ProductDetails { get; set; }

        [BsonElement("Manufacturer")]
        public string Manufacturer { get; set; }

        [BsonElement("IsInStock")]
        public bool IsInStock { get; set; }

        [BsonElement("Availability")]
        public int Availability { get; set; }

        [BsonElement("ProductCategory")]
        public string ProductCategory { get; set; }

        [BsonElement("RentPerMonth")]
        public double RentPerMonth { get; set; }

        [BsonElement("ProductImageLink")]
        public string ProductImageLink { get; set; }

    }
}
