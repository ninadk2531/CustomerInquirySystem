using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.Model
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public string TransactionDate { get; set; }
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}
