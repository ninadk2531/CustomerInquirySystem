using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CustomerInquiry.Common;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Model;
using CustomerInquiry.Repository.Interfaces;

namespace CustomerInquiry.Service
{
    /// <summary>
    /// Customer service class
    /// </summary>
    /// <seealso cref="CustomerInquiry.Service.ICustomerService" />
    public class CustomerService : ICustomerService
    {
        /// <summary>
        /// The customer repository
        /// </summary>
        private readonly ICustomerRepository _customerRepository;
        /// <summary>
        /// The transaction repository
        /// </summary>
        private readonly ITransactionRepository _transactionRepository;
        /// <summary>
        /// The customer transaction repository
        /// </summary>
        private readonly ICustomerTransactionRepository _customerTransactionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        /// <param name="customerRepository">The customer repository.</param>
        /// <param name="transactionRepository">The transaction repository.</param>
        /// <param name="customerTransactionRepository">The customer transaction repository.</param>
        public CustomerService(ICustomerRepository customerRepository, ITransactionRepository transactionRepository, ICustomerTransactionRepository customerTransactionRepository)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _customerTransactionRepository = customerTransactionRepository;
        }

        /// <summary>
        /// Customerses the by identifier or email identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns></returns>
        public async Task<CustomerDto> CustomersByIdOrEmailId(int? customerId, string customerEmail)
        {
            var customerDto = new CustomerDto();
            var customers = new Customers();
            
            //TransactionDto transactionDto = new TransactionDto();
            var transactionDtos  = new List<TransactionDto>();


            if (customerId != null && customerId != 0)
            {
                var customerByCustomerId = await _customerRepository.RetrieveCustomersByCustomerId(customerId.Value);
                customers = customerByCustomerId;
            }
            else
            {
                var customerByCustomerId = await _customerRepository.RetrieveCustomersByCustomerEmail(customerEmail);
                customers = customerByCustomerId;
            }

            if (customers == null)
                return null;
            var customerTransactionIds =
                await _customerTransactionRepository.RetrieveTransactionsByTransactionIds(customers.CustomerId);


            var transactionIdsOfCustomer =
                await _transactionRepository.RetrieveTransactionsByTransactionIds(customerTransactionIds.Select(p => p.TransactionId).ToList());


            customerDto.CustomerId = customers.CustomerId;
            customerDto.ContactEmail = customers.ContactEmail;
            customerDto.CustomerName = customers.CustomerName;
            customerDto.MobileNo = customers.MobileNo;
            customerDto.Transactions = new List<TransactionDto>();
            if (transactionIdsOfCustomer != null)
            {
                
                
                foreach (var itemTransactions in transactionIdsOfCustomer.OrderByDescending(x=>x.TransactionDate))
                {
                    if (customerDto.Transactions.Count == 5)
                        return customerDto;


                    customerDto.Transactions.Add(new TransactionDto() {TransactionId = itemTransactions.TransactionId,
                        TransactionDate = itemTransactions.TransactionDate.Value.ToString("dd/MM/yy HH:MM"),
                        Amount = Decimal.Round(itemTransactions.Amount.Value,2).ToString(),
                        CurrencyCode =  itemTransactions.CurrencyCode,
                        Status = itemTransactions.Status == (int)Status.Success ? Status.Success.ToString() : itemTransactions.Status == (int)Status.Failed ? Status.Failed.ToString() : Status.Canceled.ToString()

                    });
                }
            }


            return customerDto;

        }
    }
}
