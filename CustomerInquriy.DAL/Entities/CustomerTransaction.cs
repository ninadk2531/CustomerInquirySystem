using System;
using System.Collections.Generic;

namespace CustomerInquiry.DAL.Entities
{
    /// <summary>
    /// CustomerTransaction class
    /// </summary>
    public partial class CustomerTransaction
    {
        /// <summary>
        /// Gets or sets the customer transaction identifier.
        /// </summary>
        /// <value>
        /// The customer transaction identifier.
        /// </value>
        public int CustomerTransactionId { get; set; }
        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        /// <value>
        /// The customer identifier.
        /// </value>
        public int CustomerId { get; set; }
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>
        /// The customer.
        /// </value>
        public Customers Customer { get; set; }
        /// <summary>
        /// Gets or sets the transaction.
        /// </summary>
        /// <value>
        /// The transaction.
        /// </value>
        public Transactions Transaction { get; set; }
    }
}
