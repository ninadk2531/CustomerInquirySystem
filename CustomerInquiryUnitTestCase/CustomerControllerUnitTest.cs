using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerInquiry.Common;
using CustomerInquiry.DAL.Entities;
using CustomerInquiry.Model;
using CustomerInquiry.Repository.Interfaces;
using CustomerInquiry.Service;
using CustomerInquiryWebAPI.Controllers;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CustomerInquiryUnitTestCase
{
    /// <summary>
    /// Unit Test Case for Customer Controlller class
    /// </summary>
    [TestClass]
    public class CustomerControllerTest
    {
        /// <summary>
        /// The controller
        /// </summary>
        private CustomerControllerTest _controller;

        /// <summary>
        /// Initializes the test.
        /// </summary>
        [TestInitialize]
        public void InitializeTest()
        {
            _controller = new CustomerControllerTest();
        }

        /// <summary>
        /// Gets the customer details unit test.
        /// </summary>
        [TestMethod]
        public void GetCustomerDetailsUnitTest()
        {
            
            var currentDate = DateTime.Now;
            var mockCustomerRepository = new Mock<ICustomerRepository>();
            var mockCustomerTransactionRepository = new Mock<ICustomerTransactionRepository>();
            var mockTransactionRepository = new Mock<ITransactionRepository>();
            var mockCustomerService = new Mock<ICustomerService>();


            var customerDto = new CustomerDto()
            {
                ContactEmail = "abc@xyz.com",
                CustomerId = 1,
                CustomerName = "Ninad",
                MobileNo = 13423423,
                Transactions = new List<TransactionDto>()

            };
            customerDto.Transactions.Add(new TransactionDto()
            {
                Amount = "500.00",
                TransactionId = 1,
                TransactionDate = currentDate.ToString("dd/MM/YY HH:MM"),
                Status = Status.Canceled.ToString(),
                CurrencyCode = "INR"
            });

            var customerEntitiy = new Customers()
            {
                ContactEmail = "abc@xyz.com",
                CustomerId = 1,
                CustomerName = "Ninad",
                MobileNo = 13423423


            };

            var customerTransaction = new List<CustomerTransaction>();
            customerTransaction.Add(new CustomerTransaction()
            {
                CustomerId = 1,
                TransactionId = 1
            });

            var transactionList = new List<Transactions>();
            transactionList.Add(new Transactions()
            {
                Amount = 500,
                TransactionId = 1,
                TransactionDate = currentDate,
                Status = (int)Status.Canceled,
                CurrencyCode = "INR"
            });

            CustomerController controller = new CustomerController(mockCustomerService.Object);

           

            mockCustomerService.Setup(p => p.CustomersByIdOrEmailId(It.IsAny<int>(), string.Empty)).ReturnsAsync(customerDto);
            mockCustomerRepository.Setup(p => p.RetrieveCustomersByCustomerEmail(It.IsAny<string>())).ReturnsAsync(customerEntitiy);
            mockCustomerTransactionRepository.Setup(p => p.RetrieveTransactionsByTransactionIds(It.IsAny<int>())).ReturnsAsync(customerTransaction);
            mockTransactionRepository.Setup(p => p.RetrieveTransactionsByTransactionIds(It.IsAny<List<int>>()))
                .ReturnsAsync(transactionList);


            Assert.AreEqual(customerDto.CustomerId, customerEntitiy.CustomerId);
        }
    }
}
