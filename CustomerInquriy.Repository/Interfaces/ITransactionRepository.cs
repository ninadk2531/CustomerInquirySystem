using System.Collections.Generic;
using System.Transactions;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    public interface ITransactionRepository
    {
        List<Transactions> RetrieveTransactionsByTransactionIds(List<int> transactionIds);
    }
}