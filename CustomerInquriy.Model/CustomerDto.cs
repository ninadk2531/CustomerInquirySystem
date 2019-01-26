using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerInquiry.Model
{
    /// <summary>
    /// Customer DTO
    /// </summary>
    public class CustomerDto
    {
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the name of the customer.
        /// </summary>
        /// <value>
        /// The name of the customer.
        /// </value>
        public string CustomerName { get; set; }
        /// <summary>
        /// Gets or sets the contact email.
        /// </summary>
        /// <value>
        /// The contact email.
        /// </value>
        public string ContactEmail { get; set; }
        /// <summary>
        /// Gets or sets the mobile no.
        /// </summary>
        /// <value>
        /// The mobile no.
        /// </value>
        public decimal ? MobileNo { get; set; }

        /// <summary>
        /// The transactions
        /// </summary>
        public List<TransactionDto> Transactions = new List<TransactionDto>();

    }
}
