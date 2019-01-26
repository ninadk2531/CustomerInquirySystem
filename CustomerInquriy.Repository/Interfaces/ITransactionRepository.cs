using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    /// <summary>
    /// Transaction Repository Interface
    /// </summary>
    public interface ITransactionRepository
    {
        /// <summary>
        /// Retrieves the transactions by transaction ids.
        /// </summary>
        /// <param name="transactionIds">The transaction ids.</param>
        /// <returns></returns>
        Task<List<Transactions>> RetrieveTransactionsByTransactionIds(List<int> transactionIds);
    }
}