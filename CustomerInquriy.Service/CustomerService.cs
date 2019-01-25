using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Model;
using CustomerInquiry.Repository.Interfaces;

namespace CustomerInquiry.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;

        public CustomerService(ICustomerRepository customerRepository, ITransactionRepository transactionRepository)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<List<CustomerDto>> CustomersByIdOrEmailId(int? customerId, string customerEmail)
        {
            
            if (customerId != null && customerId != 0)
            {
                var custByCustomerId = await _customerRepository.RetrieveCustomersByCustomerId(customerId.Value);

                var transactionOfCustomer =
                    _transactionRepository.RetrieveTransactionsByTransactionIds(custByCustomerId.CustomerTransaction
                        .Select(x => x.CustomerTransactionId).ToList());


                //Create Dto using both the data source.
                return new List<CustomerDto>();


            }

            return new List<CustomerDto>();
        }
    }
}
