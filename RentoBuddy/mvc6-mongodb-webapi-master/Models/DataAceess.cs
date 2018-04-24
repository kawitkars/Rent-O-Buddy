using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class DataAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        IMongoDatabase _db1;
        
        public DataAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            
           _db1 = _client.GetDatabase("ProductDBDemo");
            
           
        }

        public IEnumerable<Product> GetProducts()
        {
            var collection = _db1.GetCollection<Product>("Products");
            return collection.Find(_ => true).ToList();
        }


        public Product GetProduct(ObjectId id)
        {
            var collection = _db1.GetCollection<Product>("Products");

            Product product = collection.Find<Product>(k => k._id == id).FirstOrDefault();

            return product;

            //var res = Query<Product>.EQ(p => p._id, id);
            //return _db.GetCollection<Product>("Products").FindOne(res);

        }

        public Product Create(Product p)
        {
            var collection = _db1.GetCollection<Product>("Products");
            collection.InsertOneAsync(p);
            //_db.GetCollection<Product>("Products").Save(p);
            return p;
        }

        public void Update(ObjectId id, Product p)
        {
            p._id = id;

            var res = Query<Product>.EQ(pd => pd._id, id);
            var operation = Update<Product>.Replace(p);
            _db.GetCollection<Product>("Products").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var collection = _db1.GetCollection<Product>("Products");
            var operation = collection.FindOneAndDelete(_ => _._id.Equals(id));
            
            //var res = Query<Product>.EQ(e => e._id, id);
            //var operation = _db.GetCollection<Product>("Products").Remove(res);
        }
    }
}
