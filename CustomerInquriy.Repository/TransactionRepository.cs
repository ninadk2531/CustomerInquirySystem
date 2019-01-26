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
    /// TransactionRepository class
    /// </summary>
    /// <seealso cref="CustomerInquiry.Repository.Interfaces.ITransactionRepository" />
    public class TransactionRepository : ITransactionRepository
    {
        /// <summary>
        /// Retrieves the transactions by transaction ids.
        /// </summary>
        /// <param name="transactionIds">The transaction ids.</param>
        /// <returns></returns>
        public async Task<List<Transactions>> RetrieveTransactionsByTransactionIds(List<int> transactionIds)
        {
            using (var db = new CustomerDbContext())
            {
                return await db.Transactions.Where(x => transactionIds.Contains(x.TransactionId)).ToListAsync();

            }
        }
    }
}
