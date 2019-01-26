using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Model;
using CustomerInquiry.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiryWebAPI.Controllers
{
    /// <summary>
    /// CustomerController class
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        /// <summary>
        /// The customer service
        /// </summary>
        private readonly ICustomerService _customerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerController"/> class.
        /// </summary>
        /// <param name="customerService">The customer service.</param>
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
            
        }
        // GET api/values
        /// <summary>
        /// Gets the customer details.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GetCustomerDetails")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult<CustomerDto>> GetCustomerDetails(int ? customerId, string customerEmail)
        {
            if (customerId == null && string.IsNullOrWhiteSpace(customerEmail))
            {
                return BadRequest("No inquiry criteria");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            try
            {
                var result = await _customerService.CustomersByIdOrEmailId(customerId, customerEmail);
                if (result == null)
                {
                    return NotFound("Not Found!");
                }
                return Ok(result.Transactions.OrderByDescending(x=>x.TransactionId));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
    }
}