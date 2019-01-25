using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiryWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {
                
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetCustomerDetails(int customerId, string customerEmail)
        {
            return null;
        }
    }
}