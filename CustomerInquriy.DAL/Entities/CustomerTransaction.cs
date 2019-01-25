using System;
using System.Collections.Generic;

namespace CustomerInquiry.DAL.Entities
{
    public partial class CustomerTransaction
    {
        public int CustomerTransactionId { get; set; }
        public int CustomerId { get; set; }
        public int TransactionId { get; set; }

        public Customers Customer { get; set; }
        public Transactions Transaction { get; set; }
    }
}
