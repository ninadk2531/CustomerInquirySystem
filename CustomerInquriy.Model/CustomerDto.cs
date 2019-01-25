using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.Model
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public decimal ? MobileNo { get; set; }

        public List<TransactionDto> Transactions = new List<TransactionDto>();

    }
}
