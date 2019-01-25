﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CustomerInquiry.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        public async Task<List<Transactions>> RetrieveTransactionsByTransactionIds(List<int> transactionIds)
        {
            using (var db = new CustomerDbContext())
            {
                return await db.Transactions.Where(x => transactionIds.Contains(x.TransactionId)).ToListAsync();

            }
        }
    }
}
