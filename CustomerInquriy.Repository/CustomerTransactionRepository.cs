using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerInquiry.Repository
{
    /// <summary>
    /// CustomerTransactionRepository class
    /// </summary>
    /// <seealso cref="CustomerInquiry.Repository.Interfaces.ICustomerTransactionRepository" />
    public class CustomerTransactionRepository : ICustomerTransactionRepository
    {
        /// <summary>
        /// Retrieves the transactions by transaction ids.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        public async Task<List<CustomerTransaction>> RetrieveTransactionsByTransactionIds(int customerId)
        {
            using (var db = new CustomerDbContext())
            {
                return await db.CustomerTransaction.Where(x => x.CustomerId == customerId).ToListAsync();

            }
        }
    }
}
