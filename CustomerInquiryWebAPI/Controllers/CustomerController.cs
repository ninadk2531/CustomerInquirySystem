﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Model;
using CustomerInquiry.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiryWebAPI.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
            
        }
        // GET api/values
        [HttpGet]
        public async Task<ActionResult<CustomerDto>> GetCustomerDetails(int ? customerId, string customerEmail)
        {
            if (customerId == null && string.IsNullOrWhiteSpace(customerEmail))
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                return await _customerService.CustomersByIdOrEmailId(customerId, customerEmail);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}