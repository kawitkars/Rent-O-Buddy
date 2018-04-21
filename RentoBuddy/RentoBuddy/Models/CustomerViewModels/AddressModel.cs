using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddy.Models.HotelViewModels
{
    public class AddressModel
    {
        public string AddressLine1_Billing { get; set; }

        public string AddressLine2_Billing { get; set; }

        public string City_Billing { get; set; }

        public string State_Billing { get; set; }

        public string ZipCode_Billing { get; set; }

        public string Country_Billing { get; set; }

        public string AddressLine1_Shipping { get; set; }

        public string AddressLine2_Shipping { get; set; }

        public string City_Shipping { get; set; }

        public string State_Shipping { get; set; }

        public string ZipCode_Shipping { get; set; }

        public string Country_Shipping { get; set; }

        public bool IsSameAsBilling { get; set; }
    }


}
