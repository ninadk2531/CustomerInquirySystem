using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CustomerInquiry.DAL.Entities
{
    public partial class Customers
    {
        public Customers()
        {
            CustomerTransaction = new HashSet<CustomerTransaction>();
        }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public decimal? MobileNo { get; set; }

        public ICollection<CustomerTransaction> CustomerTransaction { get; set; }
        
    }
}
