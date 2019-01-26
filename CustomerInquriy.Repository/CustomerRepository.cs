using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CustomerInquiry.Repository
{
    /// <summary>
    /// CustomerRepository class
    /// </summary>
    /// <seealso cref="CustomerInquiry.Repository.Interfaces.ICustomerRepository" />
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Retrieves the customers by customer identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<Customers> RetrieveCustomersByCustomerId(int customerId)
        {
            using (var db = new CustomerDbContext())
            {
                return await db.Customers.FirstOrDefaultAsync(x => x.CustomerId == customerId);
                
            }
        }

        /// <summary>
        /// Retrieves the customers by customer email.
        /// </summary>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns></returns>
        public async Task<Customers> RetrieveCustomersByCustomerEmail(string customerEmail)
        {
            using (var db = new CustomerDbContext())
            {
                return await db.Customers.FirstOrDefaultAsync(x => x.ContactEmail == customerEmail);
            }
        }
    }
}
