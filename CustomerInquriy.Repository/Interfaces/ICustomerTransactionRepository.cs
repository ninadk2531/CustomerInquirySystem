using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    public interface ICustomerTransactionRepository
    {

        Task<List<CustomerTransaction>> RetrieveTransactionsByTransactionIds(int customerId);
    }
}
