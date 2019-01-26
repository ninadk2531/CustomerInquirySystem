using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerInquiry.Service;
using CustomerInquiryWebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace XUnitTestForCustomerInquiry
{
    public class CustomerControllerUnitTest
    {
        private readonly ICustomerService _customerService;
        [Fact]
        public async Task GetCustomerDetails()
        {
            var controller = new CustomerController(_customerService);

            // Act
            var result = await controller.GetCustomerDetails(1,"abc@xyz.com");

            //    // Assert
            //    var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            //var persons = okResult.Value.Should().BeAssignableTo<IEnumerable<Person>>().Subject;

            //persons.Count().Should().Be(50);
        }
    }
}
