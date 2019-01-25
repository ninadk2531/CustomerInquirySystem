using System;
using System.Collections.Generic;

namespace CustomerInquiry.DAL.Entities
{
    public partial class Transactions
    {
        public Transactions()
        {
            CustomerTransaction = new HashSet<CustomerTransaction>();
        }

        public int TransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal? Amount { get; set; }
        public string CurrencyCode { get; set; }
        public decimal? Status { get; set; }

        public ICollection<CustomerTransaction> CustomerTransaction { get; set; }
    }
}
