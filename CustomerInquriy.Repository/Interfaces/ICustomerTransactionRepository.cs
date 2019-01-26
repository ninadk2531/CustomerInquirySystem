using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    /// <summary>
    /// ICustomerTransactionRepository interface
    /// </summary>
    public interface ICustomerTransactionRepository
    {

        /// <summary>
        /// Retrieves the transactions by transaction ids.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns></returns>
        Task<List<CustomerTransaction>> RetrieveTransactionsByTransactionIds(int customerId);
    }
}
