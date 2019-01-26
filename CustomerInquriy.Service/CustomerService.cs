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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerTransactionRepository _customerTransactionRepository;

        public CustomerService(ICustomerRepository customerRepository, ITransactionRepository transactionRepository, ICustomerTransactionRepository customerTransactionRepository)
        {
            _customerRepository = customerRepository;
            _transactionRepository = transactionRepository;
            _customerTransactionRepository = customerTransactionRepository;
        }

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
                
                
                foreach (var itemTransactions in transactionIdsOfCustomer)
                {
                    customerDto.Transactions.Add(new TransactionDto() {TransactionId = itemTransactions.TransactionId,
                        TransactionDate = itemTransactions.TransactionDate.Value.ToString("dd/MM/YY HH:MM"),
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
