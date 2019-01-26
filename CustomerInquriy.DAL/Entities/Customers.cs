using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace CustomerInquiry.DAL.Entities
{
    /// <summary>
    /// Customer class
    /// </summary>
    public partial class Customers
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customers"/> class.
        /// </summary>
        public Customers()
        {
            CustomerTransaction = new HashSet<CustomerTransaction>();
        }

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
        public decimal? MobileNo { get; set; }

        /// <summary>
        /// Gets or sets the customer transaction.
        /// </summary>
        /// <value>
        /// The customer transaction.
        /// </value>
        public ICollection<CustomerTransaction> CustomerTransaction { get; set; }
        
    }
}
