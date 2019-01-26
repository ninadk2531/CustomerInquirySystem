using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerInquiry.Model;

namespace CustomerInquiry.Service
{
    /// <summary>
    /// ICustomerService interface
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Customerses the by identifier or email identifier.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="customerEmail">The customer email.</param>
        /// <returns></returns>
        Task<CustomerDto> CustomersByIdOrEmailId(int? customerId, string customerEmail);
    }
}