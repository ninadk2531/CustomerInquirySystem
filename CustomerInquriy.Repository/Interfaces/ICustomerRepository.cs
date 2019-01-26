using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    /// <summary>
    /// ICustomerRepository interface
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retrieves the customers by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Task<Customers> RetrieveCustomersByCustomerId(int customerId);

        /// <summary>
        /// Retrieves the customers by customer email.
        /// </summary>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns></returns>
        Task<Customers> RetrieveCustomersByCustomerEmail(string customerEmail);
    }
}
