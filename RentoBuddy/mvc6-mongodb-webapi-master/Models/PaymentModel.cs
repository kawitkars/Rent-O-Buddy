using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class PaymentModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [BsonElement("PaymentId")]
        public int PaymentId { get; set; }

        [BsonElement("PaymentMode")]
        public string PaymentMode { get; set; }

        [BsonElement("CardNumber")]
        public string CardNumber { get; set; }

        [BsonElement("ExpirationDate")]
        public string ExpirationDate { get; set; }

        [BsonElement("CVVNumber")]
        public string CVVNumber { get; set; }

        [BsonElement("NameOnCard")]
        public string NameOnCard { get; set; }
    }
}
