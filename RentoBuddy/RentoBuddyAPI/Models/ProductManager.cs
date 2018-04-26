using MongoDB.Driver;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RentoBuddyAPI.Models
{
    public class ProductManager
    {
        

        MongoClient _client;
        //MongoServer _server;
        //MongoDatabase _db;
        IMongoDatabase _db1;

        public ProductManager()
        {
            _client = new MongoClient("mongodb://localhost:27017");

            _db1 = _client.GetDatabase("ProductDBDemo");

           
        }

        public IEnumerable<ProductModel> GetAll()
        {
            var collection = _db1.GetCollection<ProductModel>("Products");
            return collection.Find(_ => true).ToList();
        }
     
    }
}
