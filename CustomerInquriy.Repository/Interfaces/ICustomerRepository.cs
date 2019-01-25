using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;

namespace CustomerInquiry.Repository.Interfaces
{
    public interface ICustomerRepository
    { 
        Task<Customers> RetrieveCustomersByCustomerId(int customerId);

        Task<Customers> RetrieveCustomersByCustomerEmail(string customerEmail);
    }
}
