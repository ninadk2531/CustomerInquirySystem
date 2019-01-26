using System;
using System.Collections.Generic;

namespace CustomerInquiry.DAL.Entities
{
    /// <summary>
    /// Transactions class
    /// </summary>
    public partial class Transactions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Transactions"/> class.
        /// </summary>
        public Transactions()
        {
            CustomerTransaction = new HashSet<CustomerTransaction>();
        }

        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public int TransactionId { get; set; }
        /// <summary>
        /// Gets or sets the transaction date.
        /// </summary>
        /// <value>
        /// The transaction date.
        /// </value>
        public DateTime? TransactionDate { get; set; }
        /// <summary>
        /// Gets or sets the amount.
        /// </summary>
        /// <value>
        /// The amount.
        /// </value>
        public decimal? Amount { get; set; }
        /// <summary>
        /// Gets or sets the currency code.
        /// </summary>
        /// <value>
        /// The currency code.
        /// </value>
        public string CurrencyCode { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public decimal? Status { get; set; }

        /// <summary>
        /// Gets or sets the customer transaction.
        /// </summary>
        /// <value>
        /// The customer transaction.
        /// </value>
        public ICollection<CustomerTransaction> CustomerTransaction { get; set; }
    }
}
