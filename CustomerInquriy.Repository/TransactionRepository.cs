using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Repository.Interfaces;

namespace CustomerInquiry.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public List<Transactions> RetrieveTransactionsByTransactionIds(List<int> transactionIds)
        {
            using (CustomerDbContext db = new CustomerDbContext())
            {
                return db.Transactions.Where(x => transactionIds.Contains(x.TransactionId)).ToList();

            }
        }
    }
}
