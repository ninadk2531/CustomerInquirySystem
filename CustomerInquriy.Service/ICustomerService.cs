using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerInquiry.Model;

namespace CustomerInquiry.Service
{
    public interface ICustomerService
    {
        Task<List<CustomerDto>> CustomersByIdOrEmailId(int? customerId, string customerEmail);
    }
}