using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC6_WEBAPI_MongoDB.Models
{
    public class CustomerModel
    {
        [BsonId]
        public ObjectId _id { get; set; }

        public int CustomerID { get; set; }

        [DisplayName("First Name: ")]
        public string FirstName { get; set; }

        [DisplayName("Last Name: ")]
        public string LastName { get; set; }

        public AddressModel Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
    }
}
