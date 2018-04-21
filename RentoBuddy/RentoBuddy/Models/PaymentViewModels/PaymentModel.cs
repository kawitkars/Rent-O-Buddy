using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentoBuddy.Models.PaymentViewModels
{
    public class PaymentModel
    {
        public int PaymentId { get; set; }

        public string PaymentMode { get; set; }

        public string CardNumber { get; set; }

        public string ExpirationDate { get; set; }

        public string CVVNumber { get; set; }

        public string NameOnCard { get; set; }
    }
}
