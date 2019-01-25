using System.Collections.Generic;
using System.Threading.Tasks;
using System.Transactions;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        Task<List<Transactions>> RetrieveTransactionsByTransactionIds(List<int> transactionIds);
    }
}